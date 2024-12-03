using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Customer_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingCustomer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingCustomer
{
    public class ReportCust_Repository : IReportCust_Repository
    {
        private readonly ReportCust_Context _context;
        private readonly Customer_Conext _customerContext;

        // Inject both contexts for accessing Customer and Outgoing tables
        public ReportCust_Repository(ReportCust_Context context, Customer_Conext customerContext)
        {
            _context = context;
            _customerContext = customerContext;
        }

        // Fetch customer delivery notes based on customer name
        public async Task<IEnumerable<ReportCust>> GetCustomerDeliveryNotesAsync(string customerName)
        {
            // Step 1: Get the customerId from the Customer table based on customerName
            var customer = await _customerContext.Customer
                                                  .Where(c => c.Customer_Name.ToLower() == customerName.ToLower())
                                                  .FirstOrDefaultAsync();

            if (customer == null)
            {
                return null; // Return null if no customer found
            }

            // Step 2: Get delivery notes from the Outgoing table using the customerId
            var deliveryNotes = await _context.Outgoing
                                              .Where(o => o.CustomerID == customer.CustomerID)
                                              .Select(o => new ReportCust
                                              {
                                                  CustomerName = customer.Customer_Name,
                                                  DeliveryNote = o.Del_Note,
                                                  Outgoing_Date = (DateTime)o.Outgoing_Date
                                              })
                                              .ToListAsync();

            return deliveryNotes;
        }
    }
}
