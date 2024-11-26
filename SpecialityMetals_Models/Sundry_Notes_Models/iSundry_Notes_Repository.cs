namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry_Notes_Models
{
    public interface iSundry_Notes_Repository
    {
        Task<IEnumerable<Sundry_Notes>> GetAllSundryNotesAsync();
        Task<Sundry_Notes> GetSundryNotesByIdAsync(int sundry_Notes_Id);
        Task<Sundry_Notes> AddSundryNotesAsync(Sundry_Notes sundry_Notes);
        Task<Sundry_Notes> UpdateSundryNotesAsync(Sundry_Notes sundry_Notes);
        Task<bool> DeleteSundryNoteAsync(int sundry_Notes_Id);
    }

}
