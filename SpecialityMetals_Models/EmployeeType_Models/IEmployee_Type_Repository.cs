namespace Speciality_Metals_Back_End.SpecialityMetals_Models.EmployeeType_Models
{
    public interface IEmployee_Type_Repository
    {
        Task<IEnumerable<Employee_Type>> GetAllEmployeeTypesAsync();
        Task<Employee_Type?> GetEmployeeTypeByIdAsync(int id);
        Task<Employee_Type> AddEmployeeTypeAsync(Employee_Type employeeType);
        Task<Employee_Type?> UpdateEmployeeTypeAsync(Employee_Type employeeType);
        Task<bool> DeleteEmployeeTypeAsync(int id);
    }
}
