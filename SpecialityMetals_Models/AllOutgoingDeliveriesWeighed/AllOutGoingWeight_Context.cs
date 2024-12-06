using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.AllOutgoingDeliveriesWeighed
{
    public class AllOutGoingWeight_Context : DbContext
    {
        public AllOutGoingWeight_Context(DbContextOptions<AllOutGoingWeight_Context> options) : base(options) { }
        
        public DbSet<Outgoing> Outgoing { get; set; }
        public DbSet<Product> Product { get; set; } // Products table
    }
}

