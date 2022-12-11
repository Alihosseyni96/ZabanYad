using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Course
{
    public class CourseGroup
    {
        [Key]

        public int GroupId { get; set; }


        [Display(Name = "نام گروه ")]
        [MaxLength(150, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GroupTitle { get; set; }

        public string MainGroupImage { get; set; }
        public int? ParenetId { get; set; }

        #region Relations
        [ForeignKey("ParenetId")]
        public List<CourseGroup> CourseGroups { get; set; }
        public List<CourseToGroup> CourseToGroups { get; set; }

        #endregion
    }
}
