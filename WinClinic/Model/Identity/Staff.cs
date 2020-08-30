using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinClinic.Models.Identity
{
    public class Staff : IdentityUser
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public override string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 6)]
        [NotMapped]
        public string Password { get; set; }

        [StringLength(15, MinimumLength = 2)]
        [DefaultValue("Local")]
        public string Branch { get; set; }
    }
}
