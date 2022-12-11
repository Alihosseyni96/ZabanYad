using Domain.Models.Course;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Cart
{
    public class UserToCourse
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }


        #region Relations

        public User User { get; set; }

        public Course.Course Course { get; set; }

        #endregion
    }
}
