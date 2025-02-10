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
            // Join with Sundry_Note table to get the actual note text
            var deliveryNotes = await _context.Outgoing
                                            .Where(o => o.ProductID == product.ProductID)
                                            .Join(
                                                _context.Sundry_Note,
                                                outgoing => outgoing.Sundry_Note_ID,
                                                sundryNote => sundryNote.Sundry_Notes_ID,
                                                (outgoing, sundryNote) => new ReportProduct
                                                {
                                                    Product_Name = product.Product_Name,
                                                    DeliveryNote = sundryNote.Sundry_Note, // Using the actual note text
                                                    OutgoingDate = outgoing.Outgoing_Date.Value
                                                }
                                            )
                                            .ToListAsync();

            return deliveryNotes;
        }
    }
}
