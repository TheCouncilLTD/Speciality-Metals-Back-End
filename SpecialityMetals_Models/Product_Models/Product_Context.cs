using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models
{
    public class Product_Context : DbContext
    {
        public Product_Context(DbContextOptions<Product_Context> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}

