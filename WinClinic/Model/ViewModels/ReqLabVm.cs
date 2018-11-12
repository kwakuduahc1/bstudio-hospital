using System.ComponentModel.DataAnnotations;

namespace bStudioHospital
{
    public class ReqLabVm
    {
        [Required]
        [StringLength(20, MinimumLength = 15)]
        public string PatientID { get; set; }

        [Required]
        public short LabGroupsID { get; set; }

        [Required]
        public string GroupName { get; set; }
    }
}