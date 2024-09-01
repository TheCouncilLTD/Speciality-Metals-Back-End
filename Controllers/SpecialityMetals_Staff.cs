using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_Staff : ControllerBase
    {
        private readonly IStaff_Repository _repository;

        public SpecialityMetals_Staff(IStaff_Repository repository)
        {
            _repository = repository;
        }

        // GET: api/SpecialityMetals_Staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllStaff()
        {
            var staff = await _repository.GetAllStaffAsync();
            return Ok(staff);
        }

        // GET: api/SpecialityMetals_Staff/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffById(int id)
        {
            var staff = await _repository.GetStaffByIdAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // POST: api/SpecialityMetals_Staff
        [HttpPost]
        public async Task<ActionResult<Staff>> AddStaff(Staff staff)
        {
            var createdStaff = await _repository.AddStaffAsync(staff);
            return CreatedAtAction(nameof(GetStaffById), new { id = createdStaff.StaffID }, createdStaff);
        }

        // PUT: api/SpecialityMetals_Staff/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(int id, Staff staff)
        {
            if (id != staff.StaffID)
            {
                return BadRequest();
            }

            var updatedStaff = await _repository.UpdateStaffAsync(staff);
            if (updatedStaff == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/SpecialityMetals_Staff/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var result = await _repository.DeleteStaffAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var staff = await _repository.GetStaffByEmployeeCodeAsync(loginDto.EmployeeCode);

            if (staff == null)
            {
                return Unauthorized("Invalid Employee Code.");
            }

            // Here, you might want to generate a token or set a session, etc.
            // For now, we just return a successful message.

            return Ok(new { message = "Login successful!", staff });
        }
    }

    public class LoginDto
    {
        public string EmployeeCode { get; set; }
    }
}

