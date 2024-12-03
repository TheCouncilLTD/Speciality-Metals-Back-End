using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models
{
    public class Outgoing_Context : DbContext
    {
        public Outgoing_Context(DbContextOptions<Outgoing_Context> options) : base(options) { }

        public DbSet<Outgoing> Outgoing { get; set; }
    }
    
    
}
