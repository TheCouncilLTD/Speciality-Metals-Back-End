using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_Sundry : ControllerBase
    {
        private readonly ISundryRepository _sundryRepository;

        public SpecialityMetals_Sundry(ISundryRepository sundryRepository)
        {
            _sundryRepository = sundryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sundry>>> GetAllSundries()
        {
            var sundries = await _sundryRepository.GetAllSundriesAsync();
            return Ok(sundries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sundry>> GetSundryById(int id)
        {
            var sundry = await _sundryRepository.GetSundryByIdAsync(id);
            if (sundry == null)
            {
                return NotFound();
            }
            return Ok(sundry);
        }

        [HttpPost]
        public async Task<ActionResult<Sundry>> AddSundry(Sundry sundry)
        {
            var newSundry = await _sundryRepository.AddSundryAsync(sundry);
            return CreatedAtAction(nameof(GetSundryById), new { id = newSundry.SundryID }, newSundry);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Sundry>> UpdateSundry(int id, Sundry sundry)
        {
            try
            {
                if (id != sundry.SundryID)
                {
                    return BadRequest("Sundry ID mismatch");
                }

                var updatedSundry = await _sundryRepository.UpdateSundryAsync(sundry);
                if (updatedSundry == null)
                {
                    return NotFound($"Sundry with ID {id} not found");
                }

                return Ok(updatedSundry);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSundry(int id)
        {
            var result = await _sundryRepository.DeleteSundryAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
