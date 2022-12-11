using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Course
{
    public class CourseToGroup
    {
        [Key]

        public int CG_Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        public int CourseGroupId { get; set; }

        #region MyRegion

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("CourseGroupId")]
        public CourseGroup CourseGroup { get; set; }

        #endregion
    }
}
