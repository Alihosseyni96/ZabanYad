using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }


        [Required]
        public int ReceiverId { get; set; }
        
        [Required]
        public int SenderId { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Display(Name = "عنوان پیام ")]
        public string MessageTitle { get; set; }


        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string MessageBody { get; set; }

        public DateTime CreateDate { get; set; }
        public bool Read { get; set; }
        public bool IsDelete { get; set; }

        #region Relations

        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        #endregion
    }
}
