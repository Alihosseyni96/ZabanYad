using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Wallet
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Display(Name = "مبلغ ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }
        public bool IsFinal { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public long TransactionNumber { get; set; }


        #region Relation

        public User User { get; set; }

        [ForeignKey("TypeId")]
        public WalletToType WalletToType { get; set; }

        #endregion
    }
}
