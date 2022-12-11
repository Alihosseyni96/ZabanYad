using Core.Generators;
using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using Domain.Models.Wallet;
using ZarinpalSandbox.Models;
using Core.Security;
using System.Security.Claims;
using Domain.Models.AdminMessage;

namespace Core.Services
{
    public class UserPanelService : IUserPanelService
    {
        private IUserRepository _userRepository;
        private IMessageRepository _messageRepository;
        private IWalletRepository _walletRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private IAdminMessageToUserRepository _adminMessageToUserRepository;
        private IDirectBuyRepository _directBuyRepository;
        private IUserToCourseRepository _userToCourseRepository;

        public UserPanelService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor,
            IMessageRepository messageRepository, IWalletRepository walletRepository,
            IAdminMessageToUserRepository adminMessageToUserRepository,
            IDirectBuyRepository directBuyRepository, IUserToCourseRepository userToCourseRepository)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _messageRepository = messageRepository;
            _walletRepository = walletRepository;
            _adminMessageToUserRepository = adminMessageToUserRepository;
            _directBuyRepository = directBuyRepository;
            _userToCourseRepository = userToCourseRepository;
        }

        public int BalanceWallet()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = _userRepository.GetEntity(u => u.UserName == userName, u => u.Wallets);
            int positiveWallet = user.Wallets.Where(w => w.TypeId == 1 && w.IsFinal).Sum(w => w.Amount);
            int minusWallet = user.Wallets.Where(w => w.TypeId == 2 && w.IsFinal).Sum(w => w.Amount);
            return positiveWallet - minusWallet;
        }

        public void EditUserDetials(UserPanelEditViewModel userEdit)
        {
            User user = _userRepository.GetEntity(u => u.UserId == userEdit.UserId);
            user.UserId = userEdit.UserId;
            user.PhoneNumber = userEdit.PhoneNumber;
            user.UserName = userEdit.UserName;
            user.ImageName = userEdit.ImageName;
            if (userEdit.Password!=null && userEdit.Password==userEdit.Repassword)
            {
                user.PassWord = PasswordHelper.EncodePasswordMd5(userEdit.Password);
            }

            #region Save Image
            if (userEdit.NewUserImage != null)
            {
                if (user.ImageName != "default.jpg")
                {
                    string removeImgPath = Path.Combine(Directory.GetCurrentDirectory(),
                                           "wwwroot/UserImg", userEdit.ImageName);
                    File.Delete(removeImgPath);
                }
                user.ImageName = NameGenerator.GenerateUniqeCode() +
                    Path.GetExtension(userEdit.NewUserImage.FileName);
                string saveImgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/UserImg", user.ImageName);
                using (var stream = new FileStream(saveImgPath, FileMode.Create))
                {
                    userEdit.NewUserImage.CopyTo(stream);
                }
            }

            #endregion
            _userRepository.UpdateEntity(user);
            _httpContextAccessor.HttpContext.SignOutAsync();
        }

        public List<ShowAllTransaction> GetAllTransaction()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            int userId = _userRepository.GetEntity(u => u.UserName == userName).UserId;
            List<ShowAllTransaction> transactionList = new List<ShowAllTransaction>();

            var directTransactions = _directBuyRepository.Get(d => d.UserId == userId).Select(d => new ShowAllTransaction()
            {
                Amount = d.Price,
                CreateDate = d.CreateDate,
                Description = d.Description,
                IsFinal = d.IsFinal,
                TransactionNumber = d.TransactionNumber,
                type = "خرید مستقیم از بانک"
            });
            transactionList.AddRange(directTransactions);
            var walletTransactions = _walletRepository.Get(w => w.UserId == userId).Select(w => new ShowAllTransaction()
            {
                Amount = w.Amount,
                Description = w.Description,
                IsFinal = w.IsFinal,
                TransactionId = w.WalletId,
                CreateDate = w.CreateDate,
                TransactionNumber = w.TransactionNumber,
                type = "کیف پول"
            });

            transactionList.AddRange(walletTransactions);
            return transactionList.OrderByDescending(l => l.CreateDate).ToList();


            //return _walletRepository.Get(w => w.UserId == userId).Select(w => new ShowAllTransaction()
            //{
            //    Amount = w.Amount,
            //    Description = w.Description,
            //    IsFinal = w.IsFinal,
            //    TransactionId = w.WalletId,
            //    CreateDate = w.CreateDate,
            //    TransactionNumber = w.TransactionNumber,
            //    type = "کیف پول"
            //}).OrderByDescending(w => w.CreateDate).ToList();
        }

        public ShowRecievedMessageBodyViewModel GetRecievedMessageBody(int messageId)
        {
            Message message = _messageRepository.GetEntity(m => m.MessageId == messageId, m => m.Sender);
            message.Read = true;
            _messageRepository.UpdateEntity(message);
            return new ShowRecievedMessageBodyViewModel()
            {
                MessageId = message.MessageId,
                CreateDate = message.CreateDate,
                MessageTitle = message.MessageTitle,
                MesssageBody = message.MessageBody,
                RecieverId = message.ReceiverId,
                SenderImageName = message.Sender.ImageName,
                SenderId = message.SenderId,
                SenderName = message.Sender.UserName
            };
        }

        public Tuple<List<ShowRecievedMessageViewModel>, int> GetRecievedMessage(int pageId = 1)
        {

            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            int userId = _userRepository.GetEntity(u => u.UserName == userName).UserId;
            #region Paging
            int take = 4;
            int skip = (pageId - 1) * take;
            int totalNumberOfMessages = _messageRepository.Get(m => m.ReceiverId == userId).Include( m => m.Sender).Count();
            int pageNumbers = totalNumberOfMessages / take;
            if (totalNumberOfMessages % take != 0)
            {
                pageNumbers = pageNumbers + 1;
            }

            #endregion

            List<ShowRecievedMessageViewModel> result = _messageRepository.Get(m =>
            m.ReceiverId == userId && !m.IsDelete).Include( m => m.Sender).OrderByDescending(m => m.CreateDate).
                Select(m => new ShowRecievedMessageViewModel()
                {
                    MessageId = m.MessageId,
                    CreateDate = m.CreateDate,
                    MessageBody = m.MessageBody,
                    MessageTitle = m.MessageTitle,
                    Read = m.Read,
                    SenderImageName = m.Sender.ImageName,
                    SenderName = m.Sender.UserName
                }).Skip(skip).Take(take).ToList();

            return Tuple.Create(result, pageNumbers);

        }

        public Tuple<List<ShowSentMessageViewModel>, int> GetSentMessage(int pageId = 1)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            int userId = _userRepository.GetEntity(u => u.UserName == userName).UserId;
            #region Paging
            int take = 4;
            int skip = (pageId - 1) * take;
            int totalNumberOfMessages = _messageRepository.Get(m => m.SenderId == userId).Include(m => m.Receiver).Count();
            int pageNumbers = totalNumberOfMessages / take;
            if (totalNumberOfMessages % take != 0)
            {
                pageNumbers = pageNumbers + 1;
            }

            #endregion

            List<ShowSentMessageViewModel> result = _messageRepository.Get(m =>
            m.SenderId == userId).Include(m => m.Receiver).OrderByDescending(m => m.CreateDate).
                Select(m => new ShowSentMessageViewModel()
                {
                    MessageId = m.MessageId,
                    CreateDate = m.CreateDate,
                    MessageBody = m.MessageBody,
                    MessageTitle = m.MessageTitle,
                    Read = m.Read,
                    RecieverImageName = m.Receiver.ImageName,
                    RecieverName = m.Receiver.UserName
                }).Skip(skip).Take(take).ToList();

            return Tuple.Create(result, pageNumbers);

        }

        public UserPanelEditViewModel GetUserDetailsForEdit()
        {
            string username = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = _userRepository.GetEntity(u => u.UserName == username);
            return new UserPanelEditViewModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageName = user.ImageName
            };
        }

        public UserPanelDetailsViewModel GetUserPanelDetials()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            User user = _userRepository.GetEntity(u => u.UserName == userName, u => u.Wallets);
            return new UserPanelDetailsViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                ImageName = user.ImageName,
                PhoneNumber = user.PhoneNumber,
                WalletRest = BalanceWallet(),
                RegisterDate = user.RegisterDate
            };
        }

        public bool SendMessage(SendMessageViewModel message)
        {
            if (!_userRepository.IsExist(u => u.UserName == message.RecieverName))
            {
                return false;
            }
            int recieverId = _userRepository.GetEntity(u => u.UserName == message.RecieverName).UserId;
            string senderName = _httpContextAccessor.HttpContext.User.Identity.Name;
            int senderId = _userRepository.GetEntity(u => u.UserName == senderName).UserId;

            _messageRepository.AddEntity(new Message()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                MessageBody = message.MessageBody,
                MessageTitle = message.MessageTitle,
                Read = false,
                ReceiverId = recieverId,
                SenderId = senderId,
            });
            return true;
        }

        public int UnReadMessages()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            int userId = _userRepository.GetEntity(u => u.UserName == userName).UserId;
            return _messageRepository.Get(m => m.ReceiverId == userId && !m.Read && !m.IsDelete).Count();
        }

        public ShowSentMessageBodyViewModel GetsentMessageBody(int messageId)
        {
            Message message = _messageRepository.GetEntity(m => m.MessageId == messageId, m => m.Receiver);
            return new ShowSentMessageBodyViewModel()
            {
                CreateDate = message.CreateDate,
                MessageTitle = message.MessageTitle,
                MesssageBody = message.MessageBody,
                RecieverImageName = message.Receiver.ImageName,
                RecieverName = message.Receiver.UserName,
            };

        }

        public Task<ZarinpalSandbox.Models.PaymentRequestResponse> ChargeWallet(int amount)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            int userId = _userRepository.GetEntity(u => u.UserName == userName).UserId;
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                IsFinal = false,
                Description = "شارژ کیف پول",
                UserId = userId,
                TypeId = 1
            };
            _walletRepository.AddEntity(wallet);
            var payment = new ZarinpalSandbox.Payment(amount);
            var response = payment.PaymentRequest("شارژ کیف پول", "https://localhost:44395/UserPanel/Wallet/FinalWalletCharge/" + wallet.WalletId);
            return response;


        }

        public PaymentVerificationResponse FinalChargeWallet(int walletId)
        {
            Wallet wallet = _walletRepository.GetEntity(w => w.WalletId == walletId);
            string authority = _httpContextAccessor.HttpContext.Request.Query["Authority"];
            var payment = new ZarinpalSandbox.Payment(wallet.Amount);
            PaymentVerificationResponse response = payment.Verification(authority).Result;
            wallet.TransactionNumber = response.RefId;

            if (_httpContextAccessor.HttpContext.Request.Query["status"] != "" &&
                _httpContextAccessor.HttpContext.Request.Query["status"].ToString().ToLower() == "ok" &&
                _httpContextAccessor.HttpContext.Request.Query["Authority"] != "")
            {
                wallet.IsFinal = true;
            }
            _walletRepository.UpdateEntity(wallet);
            return response;
            

        }

        public Tuple<List<AdminMessageViewModel>, int> GetAdminMessageForUserPanel(int pageId=1)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => 
            c.Type == ClaimTypes.NameIdentifier).Value);
            #region Paging
            int take = 4;
            int skip = (pageId - 1) * take;
            int totalNumberOfMessages = _adminMessageToUserRepository.Get(m => m.RecieverId == userId && !m.IsDelete).Count();
            int pageNumbers = totalNumberOfMessages / take;
            if (totalNumberOfMessages % take != 0)
            {
                pageNumbers = pageNumbers + 1;
            }

            #endregion

            List<AdminMessageViewModel> list = _adminMessageToUserRepository.Get(m => m.RecieverId == userId && !m.IsDelete).
                Include(m => m.AdminMessage).OrderByDescending(m => m.CreateDate).Select(m => new AdminMessageViewModel()
                {
                    CreateDate = m.CreateDate,
                    id = m.Id,
                    MessageBody = m.MessageBody,
                    MessageTitle = m.MessageTitle,
                    SenderRole = m.AdminMessage.SenderRole,
                    IsRead = m.IsRead

                }).Skip(skip).Take(take).ToList();

            return Tuple.Create(list, pageNumbers);
        }

        public AdminMessageBodyViewModel GetAdminMessageBody(int messageId)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => 
            c.Type == ClaimTypes.NameIdentifier).Value);

            #region IsRead = true
            AdminMessageToUser adminMessageToUser = _adminMessageToUserRepository.Get(m =>
             m.RecieverId == userId && !m.IsDelete && m.Id == messageId).Single();

            adminMessageToUser.IsRead = true;
            _adminMessageToUserRepository.UpdateEntity(adminMessageToUser);

            #endregion

            return _adminMessageToUserRepository.Get(m => m.RecieverId == userId && m.Id == messageId && !m.IsDelete).
                Include(m=> m.AdminMessage).Select(m => new AdminMessageBodyViewModel()
            {
                CreateDate = m.CreateDate,
                MessageBody = m.MessageBody,
                MesssageTitle = m.MessageTitle,
                SenderRole = m.AdminMessage.SenderRole
            }).Single();
        }

        public int UnReadAdminMessage()
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c =>
            c.Type == ClaimTypes.NameIdentifier).Value);

            return _adminMessageToUserRepository.Get(m => !m.IsDelete && !m.IsRead && m.RecieverId == userId).Count();
        }

        public List<ShowPurchesedCoursesViewMode> GetPurchasedCourses()
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c =>
            c.Type == ClaimTypes.NameIdentifier).Value);

            return _userToCourseRepository.Get(uc => uc.UserId == userId).Include(uc => uc.Course).ThenInclude(c => c.User).Select(uc => new ShowPurchesedCoursesViewMode()
            {
                CourseId = uc.CourseId,
                CourseImageName = uc.Course.CourseImageName,
                CourseName = uc.Course.CourseTitle,
                TeacherName = uc.Course.User.UserName,
                UpdateDate = uc.Course.UpdateDate
            }).ToList();
        }
    }
}
