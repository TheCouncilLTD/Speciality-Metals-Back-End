using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Incoming_Models;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_Incoming : ControllerBase
    {
        private readonly IIncoming_Repository _incomingRepository;

        public SpecialityMetals_Incoming(IIncoming_Repository incomingRepository)
        {
            _incomingRepository = incomingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incoming>>> GetAllIncomings()
        {
            var incomings = await _incomingRepository.GetAllIncomingsAsync();
            return Ok(incomings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Incoming>> GetIncomingById(int id)
        {
            var incoming = await _incomingRepository.GetIncomingByIdAsync(id);
            if (incoming == null)
            {
                return NotFound();
            }
            return Ok(incoming);
        }

        [HttpPost]
        public async Task<ActionResult<Incoming>> AddIncoming(Incoming incoming)
        {
            var newIncoming = await _incomingRepository.AddIncomingAsync(incoming);
            return CreatedAtAction(nameof(GetIncomingById), new { id = newIncoming.IncomingID }, newIncoming);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Incoming>> UpdateIncoming(int id, Incoming incoming)
        {
            if (id != incoming.IncomingID)
            {
                return BadRequest("Incoming ID mismatch");
            }

            var updatedIncoming = await _incomingRepository.UpdateIncomingAsync(incoming);
            return Ok(updatedIncoming);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIncoming(int id)
        {
            var result = await _incomingRepository.DeleteIncomingAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

