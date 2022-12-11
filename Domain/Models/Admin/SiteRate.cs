using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Admin
{
    public class SiteRate
    {
        [Key]

        public int SiteRateId { get; set; }
        [Required]
        public int TotalDayRate { get; set; }
        [Required]
        public int UserCount { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
