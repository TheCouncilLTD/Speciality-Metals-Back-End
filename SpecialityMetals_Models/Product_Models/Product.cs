using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public string? Product_Name  { get; set; }

        public string? Product_Code { get; set; }
    }
}
