using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.EmployeeType_Models;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_EmployeeType : ControllerBase
    {
        private readonly IEmployee_Type_Repository _repository;

        public SpecialityMetals_EmployeeType(IEmployee_Type_Repository repository)
        {
            _repository = repository;
        }

        // GET: api/SpecialityMetals_EmployeeType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee_Type>>> GetAllEmployeeTypes()
        {
            var employeeTypes = await _repository.GetAllEmployeeTypesAsync();
            return Ok(employeeTypes);
        }

        // GET: api/SpecialityMetals_EmployeeType/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee_Type>> GetEmployeeTypeById(int id)
        {
            var employeeType = await _repository.GetEmployeeTypeByIdAsync(id);
            if (employeeType == null)
            {
                return NotFound();
            }

            return Ok(employeeType);
        }

        // POST: api/SpecialityMetals_EmployeeType
        [HttpPost]
        public async Task<ActionResult<Employee_Type>> AddEmployeeType(Employee_Type employeeType)
        {
            var createdEmployeeType = await _repository.AddEmployeeTypeAsync(employeeType);
            return CreatedAtAction(nameof(GetEmployeeTypeById), new { id = createdEmployeeType.Employee_Type_ID }, createdEmployeeType);
        }

        // PUT: api/SpecialityMetals_EmployeeType/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeType(int id, Employee_Type employeeType)
        {
            if (id != employeeType.Employee_Type_ID)
            {
                return BadRequest();
            }

            var updatedEmployeeType = await _repository.UpdateEmployeeTypeAsync(employeeType);
            if (updatedEmployeeType == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/SpecialityMetals_EmployeeType/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeType(int id)
        {
            var result = await _repository.DeleteEmployeeTypeAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
    
