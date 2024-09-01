namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Incoming_Models
{
    public interface IIncoming_Repository
    {
        Task<IEnumerable<Incoming>> GetAllIncomingsAsync();
        Task<Incoming> GetIncomingByIdAsync(int incomingId);
        Task<Incoming> AddIncomingAsync(Incoming incoming);
        Task<Incoming> UpdateIncomingAsync(Incoming incoming);
        Task<bool> DeleteIncomingAsync(int incomingId);
    }
}
