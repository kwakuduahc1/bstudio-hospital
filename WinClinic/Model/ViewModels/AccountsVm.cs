using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace bStudioHospital.Model.ViewModels
{
    public class AccountsVm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
        [Display(Name = "Patient ID")]
        [Remote("VerifyUniqueID", "Helpers")]
        public string PatientID { get; set; }
    }


    public class DailySales
    {
        public string Item { get; set; }

        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal? Sales { get; set; }
    }
}
