using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Cart
{
    public class DirectBuy
    {
        [Key]

        public int DirectBuyId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CourseIds { get; set; }

        [Required]
        public int Price { get; set; }
        public long TransactionNumber { get; set; }
        public DateTime CreateDate { get; set; }

        public string Description { get; set; }
        public bool IsFinal { get; set; }

        #region Relation

        public User User { get; set; }

        #endregion

    }
}
