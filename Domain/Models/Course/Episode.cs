using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Course
{
    public class Episode
    {
        [Key]

        public int EpisodeId { get; set; }


        [Required]
        public int CourseId { get; set; }


        [Required]
        public string Title { get; set; }


        [Required]
        public string FileName { get; set; }

        public bool IsDelete { get; set; }
        public bool IsFree { get; set; }


        [Required]
        public TimeSpan Time { get; set; }



        #region Relations

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        #endregion
    }
}
