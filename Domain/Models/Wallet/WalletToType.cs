using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Wallet
{
    public class WalletToType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeId { get; set; }

        [Required]
        public string TypeTitle { get; set; }


        #region Relation

        public List<Wallet> Wallets { get; set; }

        #endregion

    }
}
