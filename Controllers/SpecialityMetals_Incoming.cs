using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            // Check if the incoming entity exists before updating
            var existingIncoming = await _incomingRepository.GetIncomingByIdAsync(id);
            if (existingIncoming == null)
            {
                return NotFound("Incoming entity not found");
            }

            // Update the existing entity's properties
            existingIncoming.Incoming_Date = incoming.Incoming_Date;
            existingIncoming.Gross_Weight = incoming.Gross_Weight;
            existingIncoming.Tare_Weight = incoming.Tare_Weight;
            existingIncoming.Net_Weight = incoming.Net_Weight;
            existingIncoming.GRV_Number = incoming.GRV_Number;
            existingIncoming.SupplierID = incoming.SupplierID;
            existingIncoming.ProductID = incoming.ProductID;

            try
            {
                // Pass the updated entity to the repository's update method
                var updatedIncoming = await _incomingRepository.UpdateIncomingAsync(existingIncoming);
                return Ok(updatedIncoming);
            }
            catch (DbUpdateException ex)
            {
                // Handle any database-related errors
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other errors
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred: " + ex.Message);
            }
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

