using Domain.Models.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Cart
{
    public class CartDetail
    {
        [Key]

        public int CartDetailId { get; set; }
        [Required]
        public int CartId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        public bool IsDelete { get; set; }


        #region Relations

        [ForeignKey("CourseId")]
        public Course.Course Course { get; set; }

        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        #endregion
    }
}
