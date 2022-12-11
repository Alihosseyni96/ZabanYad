using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AdminMessage
{
    public class AdminMessage
    {
        [Key]

        public int AdminMessageId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public string SenderName { get; set; }
        [Required]
        public string SenderRole { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string ReceiverGroup { get; set; }
        [Required]
        public string MessageTitle { get; set; }
        [Required]
        public string MessageBody { get; set; }
        public bool IsDelete { get; set; }

        #region Relations
        [ForeignKey("SenderId")]
        public User User { get; set; }


        public List<AdminMessageToUser> AdminMessageToUsers { get; set; }

        #endregion
    }
}
