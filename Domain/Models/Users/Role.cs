using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }

        [Required]
        public string RoleTitle { get; set; }

        #region Relations

        public List<UserRole> UserRoles { get; set; }

        #endregion
    }
}
