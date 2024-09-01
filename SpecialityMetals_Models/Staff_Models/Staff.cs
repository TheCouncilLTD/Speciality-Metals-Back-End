using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models
{
    public class Staff
    {
        [Key]

        public int StaffID { get; set; }

        public string? Employee_Name { get; set; }

        public int? Employee_Age { get; set; }

        public string? ID_Number { get; set; }
        public string? Employee_Code { get; set; }
        public int? Employee_Type_ID { get; set; }

    }
}
