using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingProduct
{
    public class ReportProduct_Repository : IReportProduct_Repository
    {
        private readonly ReportProduct_Context _context;

        public ReportProduct_Repository(ReportProduct_Context context)
        {
            _context = context;
        }

        // Fetch delivery notes for a product by product name
        public async Task<IEnumerable<ReportProduct>> GetProductDeliveryNotesAsync(string productName)
        {
            // Step 1: Get the productId from the Product table based on productName
            var product = await _context.Product
                                        .Where(p => p.Product_Name.ToLower() == productName.ToLower())
                                        .FirstOrDefaultAsync();

            if (product == null)
            {
                return null; // Return null if no product found
            }

            // Step 2: Get delivery notes from the Outgoing table using the productId
            var deliveryNotes = await _context.Outgoing
                                              .Where(o => o.ProductID == product.ProductID)
                                              .Select(o => new ReportProduct
                                              {
                                                  Product_Name = product.Product_Name,
                                                  DeliveryNote = o.Del_Note,
                                                  OutgoingDate = o.Outgoing_Date.Value // Ensure non-nullable
                                              })
                                              .ToListAsync();

            return deliveryNotes;
        }
    }
}
