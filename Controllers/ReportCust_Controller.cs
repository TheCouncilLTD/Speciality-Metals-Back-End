using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingCustomer;
using System.Threading.Tasks;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportCust_Controller : ControllerBase
    {
        private readonly IReportCust_Repository _repository;

        public ReportCust_Controller(IReportCust_Repository repository)
        {
            _repository = repository;
        }

        // Endpoint to get delivery notes by customer name
        [HttpGet("deliverynotes/{customerName}")]
        public async Task<IActionResult> GetDeliveryNotesByCustomerName(string customerName)
        {
            var deliveryNotes = await _repository.GetCustomerDeliveryNotesAsync(customerName);

            if (deliveryNotes == null || !deliveryNotes.Any())
            {
                return NotFound("No delivery notes found for this customer.");
            }

            return Ok(deliveryNotes);
        }
    }
}
