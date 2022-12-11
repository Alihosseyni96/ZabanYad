using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Cart
{
    public class Cart
    {
        [Key]

        public int CartId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool IsFinal { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        #region Relation

        public List<CartDetail> CartDetails { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        #endregion
    }
}
