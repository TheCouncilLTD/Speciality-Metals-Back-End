using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.AllDeliveriesWeighed;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllDeliveriesWeighedController : ControllerBase
    {
        private readonly IAllDeliveriesWeighedRepository _repository;

        public AllDeliveriesWeighedController(IAllDeliveriesWeighedRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllDeliveriesWeighed>>> GetIncomingWeightDetails()
        {
            var details = await _repository.GetIncomingWeightDetailsAsync();
            return Ok(details);
        }
    }
}
