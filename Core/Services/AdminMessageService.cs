using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using Domain.Models.AdminMessage;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AdminMessageService : IAdminMessageService
    {
        private IAdminMessageRepository _adminMessageRepository;
        private IAdminMessageToUserRepository _adminMessageToUserRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserRepository _userRepository;
        private IUserRoleRepository _userRoleRepository;
        private IRoleRepository _roleRepository;

        public AdminMessageService(IAdminMessageRepository adminMessageRepository,
            IAdminMessageToUserRepository adminMessageToUserRepository, IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository, IUserRoleRepository userRoleRepository,IRoleRepository roleRepository)
        {
            _adminMessageRepository = adminMessageRepository;
            _adminMessageToUserRepository = adminMessageToUserRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public void DeleteAdminMessage(int messageId)
        {
            #region Delete Message From AdminMessage
            AdminMessage adminMessage = _adminMessageRepository.Get(m => m.AdminMessageId == messageId). Single();
            adminMessage.IsDelete = true;
            _adminMessageRepository.UpdateEntity(adminMessage);

            #endregion

            #region Delete Message From AdminMessageToUser
            List<AdminMessageToUser> adminMessageToUsers = _adminMessageToUserRepository.
               Get(m => m.AdminMessageId == messageId).ToList();

            foreach (var item in adminMessageToUsers)
            {
                item.IsDelete = true;
                _adminMessageToUserRepository.UpdateEntity(item);
            }

            #endregion
        }

        public ShowAdminMessageBodyViewModel GetAdminMessageBody(int messageId)
        {
            return _adminMessageRepository.Get(m => m.AdminMessageId == messageId).Select(m =>
            new ShowAdminMessageBodyViewModel()
            {
                CreateDate = m.CreateDate,
                MessageBody = m.MessageBody,
                Messagetitle = m.MessageTitle,
                ReceiverGroups = m.ReceiverGroup,
                SenderName = m.SenderName,
            }).Single();
        }

        public Tuple<List<ShowAdminMessageViewModel>, int> GetAllAdminMessages(int pageId =1)
        {
            #region Paging
            int take = 4;
            int skip = (pageId - 1) * take;
            int totalNumberOfMessages = _adminMessageRepository.Get().Count();
            int pageNumbers = totalNumberOfMessages / take;
            if (totalNumberOfMessages % take != 0)
            {
                pageNumbers = pageNumbers + 1;
            }
            #endregion

            List<ShowAdminMessageViewModel> list = _adminMessageRepository.Get().Select(m => new ShowAdminMessageViewModel()
            {
                AdminMessageId = m.AdminMessageId,
                CreateDate = m.CreateDate,
                IsDelete = m.IsDelete,
                MessageBody = m.MessageBody,
                MessageTitle = m.MessageTitle,
                ReceiverGroups = m.ReceiverGroup,
                SenderName = m.SenderName,
                SenderRoles = m.SenderRole
            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(list, pageNumbers);
        }

        public void ReturnAdminMessage(int messageId)
        {
            #region Return AdminMessage
            AdminMessage adminMessage = _adminMessageRepository.Get(m => m.AdminMessageId == messageId).Single();
            adminMessage.IsDelete = false;
            _adminMessageRepository.UpdateEntity(adminMessage);

            #endregion

            #region Return AdminMessageToUsers
            List<AdminMessageToUser> adminMessageToUsers = _adminMessageToUserRepository.Get(m =>
              m.AdminMessageId == messageId).ToList();

            foreach (var item in adminMessageToUsers)
            {
                item.IsDelete = false;
                _adminMessageToUserRepository.UpdateEntity(item);
            }

            #endregion
        }

        public void SendAdminMessage(CreateAdminMessageViewModel message)
        {
            #region Add Message To AdminMessage
            string senderName = _httpContextAccessor.HttpContext.User.Identity.Name;

            int senderId = _userRepository.Get(u => u.UserName == senderName).Single().UserId;

            List<string> receiverRoles = _roleRepository.Get(r => message.RecieverRoles.Contains(r.RoleId)).
                Select(r => r.RoleTitle).ToList();

            List<string> rolesTitle = _userRoleRepository.Get(ur => ur.UserId == senderId).Include(ur => ur.Role).
                Select(ur => ur.Role.RoleTitle).ToList();

            AdminMessage adminMessage = new AdminMessage()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                MessageBody = message.MessageBody,
                MessageTitle = message.MessageTitle,
                SenderId = senderId,
                SenderName = senderName,
            };
            foreach (var item in receiverRoles)
            {
                adminMessage.ReceiverGroup += item + "-";
            }

            foreach (var item in rolesTitle)
            {
                adminMessage.SenderRole += item + "-";
            }
            _adminMessageRepository.AddEntity(adminMessage);
            #endregion

            #region Add Message To AdminMessageToUser
            List<int> recieverIds = _userRoleRepository.Get(ur => message.RecieverRoles.Contains(ur.RoleId)).
                 Select(ur => ur.UserId).Distinct().ToList();
            foreach (var item in recieverIds)
            {
                _adminMessageToUserRepository.AddEntity(new AdminMessageToUser()
                {
                    RecieverId = item,
                    CreateDate = DateTime.Now,
                    AdminMessageId = adminMessage.AdminMessageId,
                    MessageBody = adminMessage.MessageBody,
                    MessageTitle = adminMessage.MessageTitle,
                });
            }


            #endregion
        }
    }
}
