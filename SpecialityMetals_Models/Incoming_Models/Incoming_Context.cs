using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Incoming_Models
{
    public class Incoming_Context : DbContext
    {
        public Incoming_Context(DbContextOptions<Incoming_Context> options) : base(options) { }

        public DbSet<Incoming> Incoming { get; set; }
    }
    
    
}
