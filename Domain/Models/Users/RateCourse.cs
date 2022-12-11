using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class RateCourse
    {
        [Key]

        public int RateCourseId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CourseId { get; set; }
        public bool Like { get; set; } 
        public int Rate { get; set; }

        #region Relations

        public User User { get; set; }
        public Course.Course Course { get; set; }

        #endregion
    }
}
