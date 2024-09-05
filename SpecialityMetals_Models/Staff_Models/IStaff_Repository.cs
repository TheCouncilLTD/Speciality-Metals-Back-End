namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models
{
    public interface IStaff_Repository
    {
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<Staff?> GetStaffByIdAsync(int id);
        Task<Staff> AddStaffAsync(Staff staff);
        Task<Staff?> UpdateStaffAsync(Staff staff);
        Task<bool> DeleteStaffAsync(int id);

        Task<Staff> GetStaffByEmployeeCodeAsync(string employeeCode);

        Task<string?> GetEmployeeTypeNameByStaffIdAsync(int staffId);
    }
}
