using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.GRV;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Speciality_Metals_Back_End.SpecialityMetals_Models.GRV
{
    public class GRVRepository : IGRVRepository
    {
        private readonly GRVDbContext _context;

        public GRVRepository(GRVDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GRVS>> GetAllGRVsAsync()
        {
            return await _context.GRVs.ToListAsync();
        }

        public async Task<GRVS> GetGRVByIdAsync(int id)
        {
            return await _context.GRVs.FindAsync(id);
        }

        public async Task<GRVS> AddGRVAsync(GRVS grv)
        {
            var result = await _context.GRVs.AddAsync(grv);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        
        public async Task<GRVS> UpdateGRVAsync(GRVS grv)
        {
            _context.Entry(grv).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return grv;
        }

        public async Task<bool> DeleteGRVAsync(int id)
        {
            var grv = await _context.GRVs.FindAsync(id);
            if (grv == null)
            {
                return false;
            }

            _context.GRVs.Remove(grv);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
