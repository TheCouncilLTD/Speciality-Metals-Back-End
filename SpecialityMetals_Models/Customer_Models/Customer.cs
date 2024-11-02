using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Customer_Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string? Customer_Name { get; set; }

        public string? Phone_number { get; set; }

        public string? Customer_Code { get; set; }

    }
}
