using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Add this

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.GRV
{
    [Table("GRV")]
    public class GRVS
    {
        [Key]
        public int GRV_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string GRV { get; set; }
    }
}
