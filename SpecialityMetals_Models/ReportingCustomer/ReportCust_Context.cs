using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Customer_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingCustomer
{
    public class ReportCust_Context : DbContext
    {
        public ReportCust_Context(DbContextOptions<ReportCust_Context> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Outgoing> Outgoing { get; set; } // The Outgoing DbSet representing the Outgoing table
    }
}
