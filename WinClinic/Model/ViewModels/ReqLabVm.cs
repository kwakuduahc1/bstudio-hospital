using System.ComponentModel.DataAnnotations;

namespace bStudioHospital
{
    public class ReqLabVm
    {
        [Required]
        public string PatientID { get; set; }

        [Required]
        public short LabGroupsID { get; set; }

        [Required]
        public string GroupName { get; set; }
    }
}