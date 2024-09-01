using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Incoming_Models
{
    public class IncomingRepository : IIncoming_Repository
    {
        private readonly Incoming_Context _context;

        public IncomingRepository(Incoming_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Incoming>> GetAllIncomingsAsync()
        {
            return await _context.Incoming.ToListAsync();
        }

        public async Task<Incoming> GetIncomingByIdAsync(int incomingId)
        {
            return await _context.Incoming.FindAsync(incomingId);
        }

        public async Task<Incoming> AddIncomingAsync(Incoming incoming)
        {
            _context.Incoming.Add(incoming);
            await _context.SaveChangesAsync();
            return incoming;
        }

        public async Task<Incoming> UpdateIncomingAsync(Incoming incoming)
        {
            _context.Incoming.Update(incoming);
            await _context.SaveChangesAsync();
            return incoming;
        }

        public async Task<bool> DeleteIncomingAsync(int incomingId)
        {
            var incoming = await _context.Incoming.FindAsync(incomingId);
            if (incoming == null)
            {
                return false;
            }

            _context.Incoming.Remove(incoming);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

