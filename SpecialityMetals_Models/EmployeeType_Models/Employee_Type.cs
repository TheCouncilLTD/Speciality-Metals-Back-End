using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.EmployeeType_Models
{
    public class Employee_Type
    {
        [Key]
        public int Employee_Type_ID { get; set; }

        public string? Employee_Type_Name { get; set; }


    }
}
