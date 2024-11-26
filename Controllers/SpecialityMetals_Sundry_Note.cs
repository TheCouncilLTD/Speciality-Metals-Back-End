using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry_Notes_Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_Sundry_Note : ControllerBase
    {
        private readonly iSundry_Notes_Repository _sundryNotesRepository;

        public SpecialityMetals_Sundry_Note(iSundry_Notes_Repository sundryNotesRepository)
        {
            _sundryNotesRepository = sundryNotesRepository;
        }

        // GET: api/SpecialityMetals_Sundry_Note
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sundry_Notes>>> GetAllSundryNotes()
        {
            var notes = await _sundryNotesRepository.GetAllSundryNotesAsync();
            return Ok(notes);
        }

        // GET: api/SpecialityMetals_Sundry_Note/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Sundry_Notes>> GetSundryNoteById(int id)
        {
            var note = await _sundryNotesRepository.GetSundryNotesByIdAsync(id);
            if (note == null)
            {
                return NotFound($"Sundry Note with ID {id} not found.");
            }

            return Ok(note);
        }

        // POST: api/SpecialityMetals_Sundry_Note
        [HttpPost]
        public async Task<ActionResult<Sundry_Notes>> AddSundryNote([FromBody] Sundry_Notes newNote)
        {
            if (newNote == null || string.IsNullOrWhiteSpace(newNote.Sundry_Note))
            {
                return BadRequest("Sundry Note cannot be null or empty.");
            }

            var createdNote = await _sundryNotesRepository.AddSundryNotesAsync(newNote);
            return CreatedAtAction(nameof(GetSundryNoteById), new { id = createdNote.Sundry_Notes_ID }, createdNote);
        }

        // PUT: api/SpecialityMetals_Sundry_Note/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSundryNote(int id, [FromBody] Sundry_Notes updatedNote)
        {
            if (id != updatedNote.Sundry_Notes_ID)
            {
                return BadRequest("Sundry Note ID mismatch.");
            }

            var existingNote = await _sundryNotesRepository.GetSundryNotesByIdAsync(id);
            if (existingNote == null)
            {
                return NotFound($"Sundry Note with ID {id} not found.");
            }

            await _sundryNotesRepository.UpdateSundryNotesAsync(updatedNote);
            return NoContent();
        }

        // DELETE: api/SpecialityMetals_Sundry_Note/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSundryNoteById(int id)
        {
            var success = await _sundryNotesRepository.DeleteSundryNoteAsync(id);
            if (!success)
            {
                return NotFound($"Sundry Note with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
