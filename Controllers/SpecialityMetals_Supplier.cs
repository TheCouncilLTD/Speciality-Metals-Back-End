using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Supplier;

namespace Speciality_Metals_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityMetals_Supplier : ControllerBase
    {
        private readonly ISupplier_Repository _supplierRepository;

        public SpecialityMetals_Supplier(ISupplier_Repository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliers()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplierById(int id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> AddSupplier(Supplier supplier)
        {
            var newSupplier = await _supplierRepository.AddSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetSupplierById), new { id = newSupplier.SupplierID }, newSupplier);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Supplier>> UpdateSupplier(int id, Supplier supplier)
        {
            if (id != supplier.SupplierID)
            {
                return BadRequest("Supplier ID mismatch");
            }

            var updatedSupplier = await _supplierRepository.UpdateSupplierAsync(supplier);
            return Ok(updatedSupplier);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            var result = await _supplierRepository.DeleteSupplierAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("{supplierId}/productName")]
        public async Task<ActionResult<string?>> GetProductNameBySupplierId(int supplierId)
        {
            var productName = await _supplierRepository.GetProductNameBySupplierIdAsync(supplierId);
            if (productName == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(productName);
        }
    
}
}
