using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry_Notes_Models
{
    public class Sundry_Notes_Context: DbContext
    {
        public Sundry_Notes_Context(DbContextOptions<Sundry_Notes_Context> options) : base(options) { }
        public DbSet<Sundry_Notes> Sundry_Notes { get; set; }
    }
}
