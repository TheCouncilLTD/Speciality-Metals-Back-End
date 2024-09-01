using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry
{
    public class SundryRepository : ISundryRepository
    {
        private readonly SundryContext _context;

        public SundryRepository(SundryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sundry>> GetAllSundriesAsync()
        {
            return await _context.Sundry.ToListAsync();
        }

        public async Task<Sundry> GetSundryByIdAsync(int sundryId)
        {
            return await _context.Sundry.FindAsync(sundryId);
        }

        public async Task<Sundry> AddSundryAsync(Sundry sundry)
        {
            _context.Sundry.Add(sundry);
            await _context.SaveChangesAsync();
            return sundry;
        }

        public async Task<Sundry> UpdateSundryAsync(Sundry sundry)
        {
            _context.Sundry.Update(sundry);
            await _context.SaveChangesAsync();
            return sundry;
        }

        public async Task<bool> DeleteSundryAsync(int sundryId)
        {
            var sundry = await _context.Sundry.FindAsync(sundryId);
            if (sundry == null)
            {
                return false;
            }

            _context.Sundry.Remove(sundry);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

