using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_Outgoing : ControllerBase
    {
        private readonly IOutgoing_Repository _outgoingRepository;

        public SpecialityMetals_Outgoing(IOutgoing_Repository outgoingRepository)
        {
            _outgoingRepository = outgoingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Outgoing>>> GetAllOutgoings()
        {
            var outgoings = await _outgoingRepository.GetAllOutgoingsAsync();
            return Ok(outgoings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Outgoing>> GetOutgoingById(int id)
        {
            var outgoing = await _outgoingRepository.GetOutgoingByIdAsync(id);
            if (outgoing == null)
            {
                return NotFound();
            }
            return Ok(outgoing);
        }

        [HttpPost]
        public async Task<ActionResult<Outgoing>> AddOutgoing(Outgoing outgoing)
        {
            var newOutgoing = await _outgoingRepository.AddOutgoingAsync(outgoing);
            return CreatedAtAction(nameof(GetOutgoingById), new { id = newOutgoing.OutgoingID }, newOutgoing);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Outgoing>> UpdateOutgoing(int id, Outgoing outgoing)
        {
            if (id != outgoing.OutgoingID)
            {
                return BadRequest("Outgoing ID mismatch");
            }

            var updatedOutgoing = await _outgoingRepository.UpdateOutgoingAsync(outgoing);
            return Ok(updatedOutgoing);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOutgoing(int id)
        {
            var result = await _outgoingRepository.DeleteOutgoingAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}