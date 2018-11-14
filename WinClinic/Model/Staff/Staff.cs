using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.Staff
{
    public class Staff
    {
        [Key]
        [Required(ErrorMessage = "Select a {0}")]
        [StringLength(30)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Select a {0}")]
        [StringLength(20)]
        public string Branch { get; set; }

        [StringLength(200, ErrorMessage = "{0} should not exceed {1} characters")]
        public string Description { get; set; }
    }
}
