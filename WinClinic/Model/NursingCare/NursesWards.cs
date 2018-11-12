using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.NursingCare
{
    public class NursesWards
    {
        public int NursesWardsID { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        public string WardName { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Wards Wards { get; set; }
    }
}
