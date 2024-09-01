using System.ComponentModel.DataAnnotations;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Supplier
{
    public class Supplier
    {
        [Key]

        public int SupplierID { get; set; }

        public string? Supplier_Name { get; set; }

        public string? Phone_Number { get; set; }

        public int? ProductID { get; set; }
    }
}
