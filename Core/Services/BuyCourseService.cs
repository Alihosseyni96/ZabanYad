using Core.IServices;
using Core.ViewModels;
using Data.Repositories;
using Domain.IRepositories;
using Domain.Models.Cart;
using Domain.Models.Course;
using Domain.Models.Users;
using Domain.Models.Wallet;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZarinpalSandbox.Models;

namespace Core.Services
{

    public class BuyCourseService : IBuyCourseService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private ICartDetailRepository _cartDetailRepository;
        private ICartRepository _cartRepository;
        private ICourseRepository _courseRepository;
        private IWalletRepository _walletRepository;
        private IUserToCourseRepository _userToCourseRepository;
        private IDirectBuyRepository _directBuyRepository;


        public BuyCourseService(IHttpContextAccessor httpContextAccessor,
            ICartDetailRepository cartDetailRepository, ICartRepository cartRepository,
            ICourseRepository courseRepository, IWalletRepository walletRepository,
            IUserToCourseRepository userToCourseRepository, IDirectBuyRepository directBuyRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartDetailRepository = cartDetailRepository;
            _cartRepository = cartRepository;
            _courseRepository = courseRepository;
            _walletRepository = walletRepository;
            _userToCourseRepository = userToCourseRepository;
            _directBuyRepository = directBuyRepository;
        }



        public void AddDetailToCart(int courseId)
        {
            Course course = _courseRepository.Get(c => c.CourseId == courseId).Single();
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
            u.Type == ClaimTypes.NameIdentifier).Value);

            Cart cart = _cartRepository.Get(c => c.UserId == userId && !c.IsFinal).SingleOrDefault();
            if (cart != null)
            {
                CartDetail detailExist = _cartDetailRepository.Get(d => d.CourseId == courseId && d.CartId == cart.CartId).FirstOrDefault();
                if (detailExist != null)
                {
                    if (detailExist.IsDelete)
                    {
                        detailExist.IsDelete = false;
                    }
                    detailExist.Count += 1;
                    _cartDetailRepository.UpdateEntity(detailExist);
                }
                else
                {
                    _cartDetailRepository.AddEntity(new CartDetail()
                    {
                        CartId = cart.CartId,
                        UnitPrice = course.CoursePrice,
                        Count = 1,
                        CourseId = courseId,
                        IsDelete = false,
                    });
                }
            }
            else
            {
                Cart newCart = new Cart()
                {
                    CreateDate = DateTime.Now,
                    IsFinal = false,
                    UserId = userId
                };
                _cartRepository.AddEntity(newCart);
                CartDetail newDetail = new CartDetail()
                {
                    CartId = newCart.CartId,
                    Count = 1,
                    CourseId = courseId,
                    UnitPrice = course.CoursePrice,
                    IsDelete = false,
                };
                _cartDetailRepository.AddEntity(newDetail);

            }

        }

        public Task<PaymentRequestResponse> BuyCourseDirectly(int amount)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                                   u.Type == ClaimTypes.NameIdentifier).Value);
            Cart cart = _cartRepository.Get(c => c.UserId == userId && !c.IsFinal).Single();
            List<CartDetail> details = _cartDetailRepository.Get(d => d.CartId == cart.CartId && !d.IsDelete).ToList();
            string courseIds = "";
            foreach (var detail in details)
            {
                for (int i = 1; i <= detail.Count; i++)
                {
                    courseIds += detail.CourseId + "-";
                }
            }
            DirectBuy newBuy = new DirectBuy()
            {
                Description = "خرید دوره",
                IsFinal = false,
                UserId = userId,
                CourseIds = courseIds,
                Price = amount,
                CreateDate=DateTime.Now
            };
            _directBuyRepository.AddEntity(newBuy);

            var payment = new ZarinpalSandbox.Payment(amount);
            var response = payment.PaymentRequest("شارژ کیف پول", "https://localhost:44395/BuyCourse/FinalBuyCourseDirectly/" + newBuy.DirectBuyId);
            return response;

        }

        public long BuyWithWallte()
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
            u.Type == ClaimTypes.NameIdentifier).Value);

            Cart cart = _cartRepository.Get(c => c.UserId == userId && !c.IsFinal).Single();

            List<CartDetail> details = _cartDetailRepository.Get(d => d.CartId == cart.CartId && !d.IsDelete).ToList();
            #region Total Price
            int totalPrice = 0;
            foreach (var detail in details)
            {
                totalPrice += detail.Count * detail.UnitPrice;
            }
            #endregion
            #region Add New Wallet 
            Wallet newWallet = new Wallet()
            {
                Amount = totalPrice,
                CreateDate = DateTime.Now,
                Description = "خرید دوره",
                IsFinal = true,
                TransactionNumber = cart.CartId,
                TypeId = 2,
                UserId = userId,
            };
            _walletRepository.AddEntity(newWallet);

            #endregion
            #region Add To UserCourse Table
            foreach (var detail in details)
            {
                for (int i = 1; i <= detail.Count; i++)
                {
                    _userToCourseRepository.AddEntity(new UserToCourse()
                    {
                        CourseId = detail.CourseId,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    });
                }
            }
            #endregion
            #region purchase Final

            cart.IsFinal = true;
            _cartRepository.UpdateEntity(cart);

            #endregion
            return newWallet.TransactionNumber;

        }

        public PaymentVerificationResponse FinalBuyCourse(int directBuyId)
        {
            DirectBuy directBuy = _directBuyRepository.Get(d => d.DirectBuyId == directBuyId).SingleOrDefault();
            string authority = _httpContextAccessor.HttpContext.Request.Query["Authority"];
            var payment = new ZarinpalSandbox.Payment(directBuy.Price);
            PaymentVerificationResponse response = payment.Verification(authority).Result;
            directBuy.TransactionNumber = response.RefId;

            if (_httpContextAccessor.HttpContext.Request.Query["status"] != "" &&
                _httpContextAccessor.HttpContext.Request.Query["status"].ToString().ToLower() == "ok" &&
                _httpContextAccessor.HttpContext.Request.Query["Authority"] != "")
            {
                directBuy.IsFinal = true;
            }
            #region Add Courses To UserToCourse Table
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                  u.Type == ClaimTypes.NameIdentifier).Value);
            Cart cart = _cartRepository.Get(c => c.UserId == userId && !c.IsFinal).Single();

            List<CartDetail> details = _cartDetailRepository.Get(d =>
            d.CartId == cart.CartId && !d.IsDelete).ToList();

            foreach (var detail in details)
            {
                for (int i = 1; i <= detail.Count; i++)
                {
                    _userToCourseRepository.AddEntity(new UserToCourse()
                    {
                        CourseId = detail.CourseId,
                        CreateDate = DateTime.Now,
                        UserId = userId
                    });
                }
            }
            cart.IsFinal = true;
            _cartRepository.UpdateEntity(cart);

            #endregion
            _directBuyRepository.UpdateEntity(directBuy);


            return response;

        }

        public Tuple<List<ShowCartDetailsViewMode>, int> GetCartDetails()
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
            u.Type == ClaimTypes.NameIdentifier).Value);

            Cart cart = _cartRepository.Get(c => c.UserId == userId && !c.IsFinal).SingleOrDefault();
            if (cart == null)
            {
                return null;
            }
            #region Total Price
            IQueryable<CartDetail> details = _cartDetailRepository.Get(d => d.CartId == cart.CartId && !d.IsDelete);
            int totalPrice = 0;
            foreach (var detail in details)
            {
                totalPrice += detail.UnitPrice * detail.Count;
            }


            #endregion
            var result = _cartDetailRepository.Get(d => d.CartId == cart.CartId && !d.IsDelete).Include(d => d.Course)
                .Select(d => new ShowCartDetailsViewMode()
                {
                    Count = d.Count,
                    CourseId = d.CourseId,
                    CourseName = d.Course.CourseTitle,
                    CourseImageName = d.Course.CourseImageName,
                    UnitPrice = d.Course.CoursePrice
                }).ToList();
            return Tuple.Create(result, totalPrice);

        }

        public void RemoveDetail(int courseId)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
            u.Type == ClaimTypes.NameIdentifier).Value);

            Cart cart = _cartRepository.Get(c => c.UserId == userId && !c.IsFinal).Single();
            CartDetail detail = _cartDetailRepository.Get(d =>
            d.CartId == cart.CartId && d.CourseId == courseId).Single();

            if (detail.Count > 1)
            {
                detail.Count -= 1;
                _cartDetailRepository.UpdateEntity(detail);
            }
            else
            {
                detail.IsDelete = true;
                detail.Count = 0;
                _cartDetailRepository.UpdateEntity(detail);
            }
        }

        public bool UserExistInCourse(int courseId)
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                    u.Type == ClaimTypes.NameIdentifier).Value);
                return _userToCourseRepository.Get(uc => uc.CourseId == courseId && uc.UserId == userId).Any();
            }
            return false;

        }
    }
}
