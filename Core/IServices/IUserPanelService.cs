using Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarinpalSandbox.Models;

namespace Core.IServices
{
	public interface IUserPanelService
	{

        UserPanelDetailsViewModel GetUserPanelDetials();

        UserPanelEditViewModel GetUserDetailsForEdit();

        void EditUserDetials(UserPanelEditViewModel userEdit);
        List<ShowPurchesedCoursesViewMode> GetPurchasedCourses();



        #region Message
        Tuple<List<ShowRecievedMessageViewModel>, int> GetRecievedMessage(int pageId = 1);

        ShowRecievedMessageBodyViewModel GetRecievedMessageBody(int messageId);
        ShowSentMessageBodyViewModel GetsentMessageBody(int messageId);
        bool SendMessage(SendMessageViewModel message);
        Tuple<List<ShowSentMessageViewModel>, int> GetSentMessage(int pageId = 1);
        int UnReadMessages();
        Tuple<List<AdminMessageViewModel>,int> GetAdminMessageForUserPanel(int pageId = 1);

        AdminMessageBodyViewModel GetAdminMessageBody(int messageId);

        int UnReadAdminMessage();
        #endregion

        #region Wallet
        int BalanceWallet();
        List<ShowAllTransaction> GetAllTransaction();

        Task<ZarinpalSandbox.Models.PaymentRequestResponse> ChargeWallet(int amount);
        PaymentVerificationResponse FinalChargeWallet(int walletId);

        #endregion

    }
}
