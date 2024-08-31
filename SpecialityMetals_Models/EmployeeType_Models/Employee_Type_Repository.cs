using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.EmployeeType_Models
{
    public class Employee_Type_Repository : IEmployee_Type_Repository
    {
        private readonly Employee_Type_Context _context;

        public Employee_Type_Repository(Employee_Type_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee_Type>> GetAllEmployeeTypesAsync()
        {
            return await _context.Employee_Type.ToListAsync();
        }

        public async Task<Employee_Type?> GetEmployeeTypeByIdAsync(int id)
        {
            return await _context.Employee_Type.FindAsync(id);
        }

        public async Task<Employee_Type> AddEmployeeTypeAsync(Employee_Type employeeType)
        {
            _context.Employee_Type.Add(employeeType);
            await _context.SaveChangesAsync();
            return employeeType;
        }

        public async Task<Employee_Type?> UpdateEmployeeTypeAsync(Employee_Type employeeType)
        {
            var existingEmployeeType = await _context.Employee_Type.FindAsync(employeeType.Employee_Type_ID);
            if (existingEmployeeType == null)
            {
                return null;
            }

            existingEmployeeType.Employee_Type_Name = employeeType.Employee_Type_Name;
            await _context.SaveChangesAsync();

            return existingEmployeeType;
        }

        public async Task<bool> DeleteEmployeeTypeAsync(int id)
        {
            var employeeType = await _context.Employee_Type.FindAsync(id);
            if (employeeType == null)
            {
                return false;
            }

            _context.Employee_Type.Remove(employeeType);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
