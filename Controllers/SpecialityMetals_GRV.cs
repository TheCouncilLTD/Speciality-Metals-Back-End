using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.GRV;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_GRV : ControllerBase
    {
        private readonly IGRVRepository _grvRepository;

        public SpecialityMetals_GRV(IGRVRepository grvRepository)
        {
            _grvRepository = grvRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GRVS>>> GetAllGRVs()
        {
            var grvs = await _grvRepository.GetAllGRVsAsync();
            return Ok(grvs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GRVS>> GetGRVById(int id)
        {
            var grv = await _grvRepository.GetGRVByIdAsync(id);
            if (grv == null)
            {
                return NotFound();
            }
            return Ok(grv);
        }

        [HttpPost]
        public async Task<ActionResult<GRVS>> AddGRV(GRVS grv)
        {
            var newGRV = await _grvRepository.AddGRVAsync(grv);
            return CreatedAtAction(nameof(GetGRVById), new { id = newGRV.GRV_ID }, newGRV);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GRVS>> UpdateGRV(int id, GRVS grv)
        {
            if (id != grv.GRV_ID)
            {
                return BadRequest("GRV ID mismatch");
            }

            var existingGRV = await _grvRepository.GetGRVByIdAsync(id);
            if (existingGRV == null)
            {
                return NotFound("GRV not found");
            }

            try
            {
                var updatedGRV = await _grvRepository.UpdateGRVAsync(grv);
                return Ok(updatedGRV);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating data: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGRV(int id)
        {
            var result = await _grvRepository.DeleteGRVAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
