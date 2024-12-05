using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Incoming_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.AllDeliveriesWeighed
{
    public class AllDeliveriesWeighedContext : DbContext
    {
        public AllDeliveriesWeighedContext(DbContextOptions<AllDeliveriesWeighedContext> options) : base(options) { }

         public DbSet<Incoming> Incoming { get; set; }
        public DbSet<Product> Product { get; set; } // New DbSet for Product table
    }
}
