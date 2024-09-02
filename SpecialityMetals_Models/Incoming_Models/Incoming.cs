using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Incoming_Models
{
    public class Incoming
    {

        [Key]

        public int IncomingID { get; set; }

        public DateTime? Incoming_Date { get; set; }

        public decimal? Gross_Weight { get; set; }

        public decimal? Tare_Weight { get; set; }

        public decimal? Net_Weight { get; set; }

        public string? GRV_Number { get; set; }
        public int? SupplierID { get; set; }
        public int? ProductID { get; set; }
    }
}
