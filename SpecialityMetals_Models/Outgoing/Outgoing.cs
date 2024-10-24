using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing
{
    public class Outgoing
    {
        [Key]
        public int OutgoingID { get; set; }

        public DateTime? Outgoing_Date { get; set; }

        public decimal? Gross_Weight { get; set; } // Change from int to decimal
        public decimal? Tare_Weight { get; set; } // Change from int to decimal
        public decimal? Net_Weight { get; set; } // Change from int to decimal

        public string? Del_Note { get; set; }
        public int? CustomerID { get; set; }
        public int? ProductID { get; set; }
        public int? EmployeeID { get; set; } // Add this property if it's missing
    }
}
