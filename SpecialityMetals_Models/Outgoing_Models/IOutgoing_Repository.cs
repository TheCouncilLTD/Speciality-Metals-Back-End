namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models
{
    public interface IOutgoing_Repository
    {
        Task<IEnumerable<Outgoing>> GetAllOutgoingsAsync();
        Task<Outgoing> GetOutgoingByIdAsync(int outgoingId);
        Task<Outgoing> AddOutgoingAsync(Outgoing outgoing);
        Task<Outgoing> UpdateOutgoingAsync(Outgoing outgoing);
        Task<bool> DeleteOutgoingAsync(int outgoingId);
    }
}
