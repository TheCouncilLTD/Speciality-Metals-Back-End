using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry_Notes_Models
{
    public class Sundry_Notes_Repository : iSundry_Notes_Repository
    {
        private readonly Sundry_Notes_Context _context;

        public Sundry_Notes_Repository(Sundry_Notes_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sundry_Notes>> GetAllSundryNotesAsync()
        {
            return await _context.Sundry_Notes.ToListAsync();
        }

        public async Task<Sundry_Notes> GetSundryNotesByIdAsync(int sundry_Notes_Id)
        {
            return await _context.Sundry_Notes.FindAsync(sundry_Notes_Id);
        }

        public async Task<Sundry_Notes> AddSundryNotesAsync(Sundry_Notes sundry_Notes)
        {
            _context.Sundry_Notes.Add(sundry_Notes);
            await _context.SaveChangesAsync();
            return sundry_Notes;
        }

        public async Task<Sundry_Notes> UpdateSundryNotesAsync(Sundry_Notes sundry_Notes)
        {
            _context.Sundry_Notes.Update(sundry_Notes);
            await _context.SaveChangesAsync();
            return sundry_Notes;
        }

        public async Task<bool> DeleteSundryNoteAsync(int sundry_Notes_Id)
        {
            var sundry = await _context.Sundry_Notes.FindAsync(sundry_Notes_Id);
            if (sundry == null)
            {
                return false;
            }

            _context.Sundry_Notes.Remove(sundry);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
