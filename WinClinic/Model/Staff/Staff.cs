using bStudioHospital.Model.Records;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace bStudioHospital.Model.Staff
{
    public class Staff
    {
        [Key]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Select a {0}")]
        [StringLength(30)]
        public string UserName { get; set; }

        
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Select a {0}")]
        [StringLength(20)]
        [Remote("BranchCheck", "Helpers")]
        public string Branch { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200, ErrorMessage = "{0} should not exceed {1} characters")]
        public string Description { get; set; }

        public virtual Branches Branches { get; set; }
    }
}
