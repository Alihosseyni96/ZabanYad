using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarinpalSandbox.Models;

namespace Core.IServices
{
    public interface IBuyCourseService
    {
        void AddDetailToCart(int courseId);
        Tuple<List<ShowCartDetailsViewMode>, int> GetCartDetails();
        void RemoveDetail(int courseId);

        long BuyWithWallte();
        bool UserExistInCourse(int courseId);
        Task<ZarinpalSandbox.Models.PaymentRequestResponse> BuyCourseDirectly(int amount);

        PaymentVerificationResponse FinalBuyCourse(int directBuyId);
    }
}
