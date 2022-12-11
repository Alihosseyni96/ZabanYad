using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IAdminMessageService
    {
        void SendAdminMessage(CreateAdminMessageViewModel message);
        Tuple<List<ShowAdminMessageViewModel>,int> GetAllAdminMessages(int pageId = 1);
        void DeleteAdminMessage(int messageId);
        void ReturnAdminMessage(int messageId);
        ShowAdminMessageBodyViewModel GetAdminMessageBody(int messageId);

    }
}
