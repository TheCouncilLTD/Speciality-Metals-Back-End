using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.JWT;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_Staff : ControllerBase
    {
        private readonly IStaff_Repository _repository;
        private readonly JwtHelper _jwtHelper;
        public SpecialityMetals_Staff(IStaff_Repository repository, JwtHelper jwtHelper)
        {
            _repository = repository;
            _jwtHelper = jwtHelper;
        }

        [Authorize]
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            return Ok("This is secure data only accessible with a valid token!");
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

            // Assuming you have injected JwtHelper into this controller
            var jwtToken = _jwtHelper.GenerateJwtToken(loginDto.EmployeeCode);  // Correct method name

            return Ok(new { message = "Login successful!", token = jwtToken });
        }
        [HttpGet("{staffId}/employeeTypeName")]
        public async Task<ActionResult<string?>> GetEmployeeTypeNameByStaffId(int staffId)
        {
            var employeeTypeName = await _repository.GetEmployeeTypeNameByStaffIdAsync(staffId);
            if (employeeTypeName == null)
            {
                return NotFound("Employee type not found.");
            }

            return Ok(employeeTypeName);
        }

    }

    public class LoginDto
    {
        public string EmployeeCode { get; set; }
    }
}

