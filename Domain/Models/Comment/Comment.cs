using Domain.Models.Course;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Comment
{
    public class Comment
    {
        [Key]

        public int CommentId { get; set; }
          [Required]
        public int UserId { get; set; }
          [Required]

        public int CourseId { get; set; }
          [Required]
        public string CommentBody { get; set; }
        public int CommentLike { get; set; }
          [Required]
        public DateTime CreateDate { get; set; }
        public bool Show { get; set; }
        public bool IsDelete { get; set; }


        #region Relations

        public User User { get; set; }
        public Course.Course Course { get; set; }

        public List<ReplyComment> ReplyComments { get; set; }
        #endregion

    }
}
