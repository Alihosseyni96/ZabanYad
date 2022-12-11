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
    public class AdminMessageToUser
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public int AdminMessageId { get; set; }
        [Required]
        public int RecieverId { get; set; }
        [Required]
        public string MessageBody { get; set; }
        [Required]
        public string MessageTitle { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsRead { get; set; }


        #region Relations

        [ForeignKey("RecieverId")]
        public User User { get; set; }

        [ForeignKey("AdminMessageId")]
        public AdminMessage AdminMessage { get; set; }

        #endregion
    }
}
