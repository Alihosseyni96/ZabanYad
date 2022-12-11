using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Users;
using Data.Repositories;
using Core.Generators;
using System.IO;
using Domain.Models.Wallet;
using Core.Security;
using System.Data;

namespace Core.Services
{
    public class UserAdminService : IUserAdminService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IWalletRepository _walletRepository;
        private IUserRoleRepository _userRoleRepository;

        public UserAdminService(IUserRepository userRepository, IRoleRepository roleRepository,
            IWalletRepository walletRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _walletRepository = walletRepository;
            _userRoleRepository = userRoleRepository;
        }

        public void CreateUser(CreateUserViewModel createUser)
        {
            #region Add User
            User user = new User();

            user.ActiveCode = NameGenerator.GenerateUniqeCode();
            user.Email = createUser.Email;
            user.IsActive = true;
            user.IsDelete = false;
            user.PassWord = PasswordHelper.EncodePasswordMd5(createUser.Password);
            user.PhoneNumber = createUser.PhoneNumber;
            user.RegisterDate = DateTime.Now;
            user.ImageName = "default.jpg";
            user.UserName = createUser.UserName;
            //Add User Image
            if (createUser.UserImage != null)
            {
                user.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(createUser.UserImage.FileName);
                string imgSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImg", user.ImageName);
                using (var stream = new FileStream(imgSavePath, FileMode.Create))
                {
                    createUser.UserImage.CopyTo(stream);
                }
            }
            //Add User Image
            _userRepository.AddEntity(user);

            #endregion
            #region AddWallet
            if (createUser.WalletCharge!=null)
            {
                _walletRepository.AddEntity(new Domain.Models.Wallet.Wallet()
                {
                    Amount = int.Parse(createUser.WalletCharge),
                    Description = "هدیه از ادمین",
                    CreateDate = DateTime.Now,
                    IsFinal = true,
                    TypeId = 1,
                    TransactionNumber = 101,
                    UserId = user.UserId,

                });
            }

            #endregion
            #region AddRoles
            if (createUser.RolesId!=null)
            {
                foreach (var role in createUser.RolesId)
                {
                    _userRoleRepository.AddEntity(new UserRole()
                    {
                        RoleId = role,
                        UserId = user.UserId
                    });
                }

            }
            else
            {
                _userRoleRepository.AddEntity(new UserRole()
                {
                    RoleId = 1,
                    UserId = user.UserId
                });

            }

            #endregion

        }

        public void DeleteUser(int userId)
        {
            User user = _userRepository.GetEntity(u => u.UserId == userId);
            user.IsDelete = true;
            _userRepository.UpdateEntity(user);
        }


        public void EditUser(UserForEditAdminViewModel userForEdit)
        {
            #region Update User
            User user = _userRepository.Get(u => u.UserId == userForEdit.UserId).Single();
            user.UserId = userForEdit.UserId;
            user.UserName = userForEdit.UserName;
            user.PhoneNumber = userForEdit.PhoneNumber;
            user.Email = userForEdit.Email;
            if (userForEdit.Password != null && userForEdit.Password == userForEdit.RePassword)
            {
                user.PassWord = PasswordHelper.EncodePasswordMd5(userForEdit.Password);
            }
            #region SaveImage
            if (userForEdit.UserImage != null)
            {
                #region Remove Previous Image IF Exists
                if (userForEdit.ImageName != "default.jpg")
                {
                    string previousImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImg",
                                                                             userForEdit.ImageName);
                    System.IO.File.Delete(previousImgPath);
                }

                #endregion
                user.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(userForEdit.UserImage.FileName);
                string newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImg", user.ImageName);
                using (var stream = new FileStream(newImagePath, FileMode.Create))
                {
                    userForEdit.UserImage.CopyTo(stream);
                }

            }
            #endregion
            _userRepository.UpdateEntity(user);

            #endregion
            #region Add New Wallet
            Wallet wallet = new Wallet()
            {
                CreateDate = DateTime.Now,
                Amount = userForEdit.WalletCharge,
                IsFinal = true,
                TransactionNumber = 101,
                Description = "شارژ هدیه از مدیریت ",
                TypeId = 1,
                UserId = user.UserId,

            };
            _walletRepository.AddEntity(wallet);

            #endregion
            #region Delete Previous Roles and Add New Roles
            List<UserRole> userRoles = _userRoleRepository.Get(ur => ur.UserId == userForEdit.UserId).ToList();
            foreach (var userRole in userRoles)
            {
                _userRoleRepository.Delete(userRole);
            }
            foreach (var roleId in userForEdit.RolesId)
            {
                _userRoleRepository.AddEntity(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userForEdit.UserId
                });
            }

            #endregion
        }


        public List<ShowRolesForAdminPanelViewMode> GetRolesForShow()
        {
            return _roleRepository.Get().Select(r => new ShowRolesForAdminPanelViewMode()
            {
                RoleId = r.RoleId,
                RoleTitle = r.RoleTitle
            }).ToList();
        }

        public UserForEditAdminViewModel GetUserForEdit(int userId)
        {
            User user = _userRepository.Get(u => u.UserId == userId).Include(u => u.Wallets).Include(u => u.UserRoles).Single();
            return new UserForEditAdminViewModel()
            {
                
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserId = user.UserId,
                ImageName = user.ImageName,
                UserName = user.UserName,

                WalletCharge = (user.Wallets.Where(w => w.UserId == user.UserId && w.IsFinal && w.TypeId == 1).Sum(w => w.Amount)) -
                (user.Wallets.Where(w => w.UserId == user.UserId && w.IsFinal && w.TypeId == 2).Sum(w => w.Amount)),

                RolesId = user.UserRoles.Select(u => u.RoleId).ToList(),
            };

        }

        public Tuple<List<ShowUsersForAdminPanelViewModel>, int, int> GetUsersForAdminPanel(int pageId = 1, string searchBox = "")
        {
            int take;
            int skip;
            int totalNumberOfUsers;
            int pageNumbers;

            if (searchBox != null)
            {
                #region Paging
                take = 4;
                skip = (pageId - 1) * take;
                totalNumberOfUsers = _userRepository.Get(u => u.UserName.Contains(searchBox) ||
                                        u.Email.Contains(searchBox) || u.PhoneNumber.Contains(searchBox)).Count();
                if (pageId != 1 && totalNumberOfUsers <= take)
                {
                    skip = 0;
                    pageId = 1;
                }
                pageNumbers = totalNumberOfUsers / take;
                if (totalNumberOfUsers % take != 0)
                {
                    pageNumbers = pageNumbers + 1;
                }

                #endregion

                #region Get User With Search Filter
                List<ShowUsersForAdminPanelViewModel> resultWithSearchBox = _userRepository.Get(u => u.UserName.Contains(searchBox) ||
u.Email.Contains(searchBox) || u.PhoneNumber.Contains(searchBox)).Include(u => u.Wallets).
 Include(u => u.UserRoles).ThenInclude(ur => ur.Role).
 Select(u => new ShowUsersForAdminPanelViewModel()
 {
     UserId = u.UserId,
     Email = u.Email,
     IsActive = u.IsActive,
     IsDelete = u.IsDelete,
     PhoneNumber = u.PhoneNumber,
     RegisterDate = u.RegisterDate,
     RolesName = u.UserRoles.Select(r => r.Role.RoleTitle).ToList(),

     WalletReminded = (u.Wallets.Where(w => w.TypeId == 1).Sum(w => w.Amount)) -
     (u.Wallets.Where(w => w.TypeId == 2).Sum(w => w.Amount)),

     UserImageName = u.ImageName,
     UserName = u.UserName
 }).Skip(skip).Take(take).ToList();
                return Tuple.Create(resultWithSearchBox, pageNumbers, pageId);

                #endregion
            }
            #region Paging
            take = 4;
            skip = (pageId - 1) * take;
            totalNumberOfUsers = _userRepository.Get().Count();
            pageNumbers = totalNumberOfUsers / take;
            if (totalNumberOfUsers % take != 0)
            {
                pageNumbers = pageNumbers + 1;
            }

            #endregion

            #region Get User Without Search Filter
            List<ShowUsersForAdminPanelViewModel> result = _userRepository.Get().Include(u => u.Wallets).
    Include(u => u.UserRoles).ThenInclude(ur => ur.Role).
    Select(u => new ShowUsersForAdminPanelViewModel()
    {
        UserId = u.UserId,
        Email = u.Email,
        IsActive = u.IsActive,
        IsDelete = u.IsDelete,
        PhoneNumber = u.PhoneNumber,
        RegisterDate = u.RegisterDate,
        RolesName = u.UserRoles.Select(r => r.Role.RoleTitle).ToList(),

        WalletReminded = (u.Wallets.Where(w => w.TypeId == 1).Sum(w => w.Amount)) -
        (u.Wallets.Where(w => w.TypeId == 2).Sum(w => w.Amount)),

        UserImageName = u.ImageName,
        UserName = u.UserName
    }).Skip(skip).Take(take).ToList();
            return Tuple.Create(result, pageNumbers, pageId);

            #endregion
        }

        public void ReturnUser(int userId)
        {
            User user = _userRepository.GetEntity(u => u.UserId == userId);
            user.IsDelete = false;
            _userRepository.UpdateEntity(user);

        }
    }
}
