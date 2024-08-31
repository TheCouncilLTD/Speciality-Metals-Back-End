using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.EmployeeType_Models
{
    public class Employee_Type_Context : DbContext
    {
        public Employee_Type_Context(DbContextOptions<Employee_Type_Context> options) : base(options)
        {
        }

        public DbSet<Employee_Type> Employee_Type { get; set; }
    }
}

