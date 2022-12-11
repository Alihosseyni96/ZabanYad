using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Comment
{
    public class ReplyComment
    {
        [Key]

        public int ReplyCommentId { get; set; }
        [Required]
        public int CommentId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ReplyBody { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        public bool IsAnswer { get; set; }

        #region Relations

        public Comment Comment { get; set; }
        public User User { get; set; }

        #endregion
    }
}
