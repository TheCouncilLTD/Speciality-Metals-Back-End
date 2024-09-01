namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry
{
    public interface ISundryRepository
    {
        Task<IEnumerable<Sundry>> GetAllSundriesAsync();
        Task<Sundry> GetSundryByIdAsync(int sundryId);
        Task<Sundry> AddSundryAsync(Sundry sundry);
        Task<Sundry> UpdateSundryAsync(Sundry sundry);
        Task<bool> DeleteSundryAsync(int sundryId);
    }

}
