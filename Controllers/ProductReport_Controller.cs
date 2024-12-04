using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingProduct;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReport_Controller : ControllerBase
    {
        private readonly IReportProduct_Repository _repository;

        public ProductReport_Controller(IReportProduct_Repository repository)
        {
            _repository = repository;
        }

        // Endpoint to get delivery notes by product name
        [HttpGet("deliverynotes/{productName}")]
        public async Task<IActionResult> GetDeliveryNotesByProductName(string productName)
        {
            var deliveryNotes = await _repository.GetProductDeliveryNotesAsync(productName);

            if (deliveryNotes == null || !deliveryNotes.Any())
            {
                return NotFound("No delivery notes found for this product.");
            }

            return Ok(deliveryNotes);
        }
    }
}
