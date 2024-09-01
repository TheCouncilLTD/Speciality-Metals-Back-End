using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry
{
    public class SundryContext : DbContext
    {
        public SundryContext(DbContextOptions<SundryContext> options) : base(options) { }

        public DbSet<Sundry> Sundry { get; set; }
    }
}