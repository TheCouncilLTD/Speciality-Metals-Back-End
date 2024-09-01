using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing
{
    public class Outgoing
    {

        [Key]

        public int OutgoingID { get; set; }

        public DateTime? Outgoing_Date { get; set; }

        public int? Gross_Weight { get; set; }

        public int? Tare_Weight { get; set; }

        public int? Net_Weight { get; set; }

        public string? Del_Note { get; set; }
        public int? SupplierID { get; set; }
        public int? ProductID { get; set; }
    }
}
