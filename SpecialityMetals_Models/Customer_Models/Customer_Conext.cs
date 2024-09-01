using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Customer_Models
{
    public class Customer_Conext : DbContext
    {
        public Customer_Conext(DbContextOptions<Customer_Conext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
    }


    }

