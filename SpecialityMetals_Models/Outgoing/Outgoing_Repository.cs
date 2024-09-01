using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing
{
    public class Outgoing_Repository : IOutgoing_Repository
    {
        private readonly Outgoing_Context _context;

        public Outgoing_Repository(Outgoing_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Outgoing>> GetAllOutgoingsAsync()
        {
            return await _context.Outgoing.ToListAsync();
        }

        public async Task<Outgoing> GetOutgoingByIdAsync(int outgoingId)
        {
            return await _context.Outgoing.FindAsync(outgoingId);
        }

        public async Task<Outgoing> AddOutgoingAsync(Outgoing outgoing)
        {
            _context.Outgoing.Add(outgoing);
            await _context.SaveChangesAsync();
            return outgoing;
        }

        public async Task<Outgoing> UpdateOutgoingAsync(Outgoing outgoing)
        {
            _context.Outgoing.Update(outgoing);
            await _context.SaveChangesAsync();
            return outgoing;
        }

        public async Task<bool> DeleteOutgoingAsync(int outgoingId)
        {
            var outgoing = await _context.Outgoing.FindAsync(outgoingId);
            if (outgoing == null)
            {
                return false;
            }

            _context.Outgoing.Remove(outgoing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
