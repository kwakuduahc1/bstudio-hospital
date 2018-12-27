using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinClinic.Model.Staff
{
    public class Staff : IdentityUser
    {
        [Required]
        [StringLength(15, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Password { get; set; }
    }
}
