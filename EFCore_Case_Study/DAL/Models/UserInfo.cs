using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        [StringLength(50)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string UserName { get; set; }

        [Required]
        public string Role { get; set; } // Admin or Participant

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
