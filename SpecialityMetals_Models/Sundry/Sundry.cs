using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry
{
    public class Sundry
    {
        [Key]

        public int SundryID { get; set; }

        public DateTime? Sundry_Date { get; set; }
        public TimeSpan Time { get; set; }  // Add this
        public int? Gross_Weight { get; set; }

        public int? Tare_Weight { get; set; }
        public int? Net_Weight { get; set; }

        public int? ProductID { get; set; }
        public int? EmployeeID { get; set; }
        public string? Comments { get; set; }
        public int? Sundry_Note_ID { get; set; }
    }
}

