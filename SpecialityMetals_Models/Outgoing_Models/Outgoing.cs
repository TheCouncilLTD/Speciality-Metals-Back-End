using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models
{
    public class Outgoing
    {
       
       
            [Key]
            public int OutgoingID { get; set; }

            public DateTime? Outgoing_Date { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? Gross_Weight { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? Tare_Weight { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? Net_Weight { get; set; }

            public int? CustomerID { get; set; }
            public int? ProductID { get; set; }
            public int? EmployeeID { get; set; }
            public int? Sundry_Note_ID { get; set; }  // New foreign key property
        
    }
}
