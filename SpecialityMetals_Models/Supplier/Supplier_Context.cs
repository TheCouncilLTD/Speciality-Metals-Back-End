using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Supplier
{
    public class Supplier_Context : DbContext
    {
        public Supplier_Context(DbContextOptions<Supplier_Context> options) : base(options) { }

        public DbSet<Supplier> Supplier { get; set; }
    }
}
