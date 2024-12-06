using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.AllOutgoingDeliveriesWeighed;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllOutGoingWeight_Controller : ControllerBase
    {
        private readonly IAllOutGoingWeight_Repository _repository;

        public AllOutGoingWeight_Controller(IAllOutGoingWeight_Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllOutGoingWeight>>> GetOutgoingWeightDetails()
        {
            var details = await _repository.GetOutgoingWeightDetailsAsync();
            return Ok(details);
        }
    }
}
   