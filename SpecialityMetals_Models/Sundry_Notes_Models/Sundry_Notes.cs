using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry_Notes_Models
{
    [Table("Sundry_Note")] // Map to the correct table name
    public class Sundry_Notes
    {
        [Key]
        [Column("Sundry_Note_ID")] // Map to the correct column name
        public int Sundry_Notes_ID { get; set; }

        [Column("Sundry_Note")] // Map to the correct column name
        public string Sundry_Note { get; set; }
    }
}
