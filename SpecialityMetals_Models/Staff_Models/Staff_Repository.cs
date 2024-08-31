using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models
{
    public class Staff_Repository : IStaff_Repository
    {
        private readonly Staff_Context _context;

        public Staff_Repository(Staff_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _context.Staff.ToListAsync();
        }

        public async Task<Staff?> GetStaffByIdAsync(int id)
        {
            return await _context.Staff.FindAsync(id);
        }

        public async Task<Staff> AddStaffAsync(Staff staff)
        {
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff?> UpdateStaffAsync(Staff staff)
        {
            var existingStaff = await _context.Staff.FindAsync(staff.StaffID);
            if (existingStaff == null)
            {
                return null;
            }

            existingStaff.Employee_Name = staff.Employee_Name;
            existingStaff.Employee_Age = staff.Employee_Age;
            existingStaff.ID_Number = staff.ID_Number;
            existingStaff.Employee_Code = staff.Employee_Code;
            existingStaff.Employee_Type_ID = staff.Employee_Type_ID;

            await _context.SaveChangesAsync();

            return existingStaff;
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return false;
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}