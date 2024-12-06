using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.AllDeliveriesWeighed;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.AllOutgoingDeliveriesWeighed
{
    public class AllOutGoingWeight_Repository : IAllOutGoingWeight_Repository
    {
        private readonly AllOutGoingWeight_Context _context;

        public AllOutGoingWeight_Repository(AllOutGoingWeight_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllOutGoingWeight>> GetOutgoingWeightDetailsAsync()
        {
            var query = from outgoing in _context.Outgoing
                        join product in _context.Product
                        on outgoing.ProductID equals product.ProductID
                        select new AllOutGoingWeight
                        {
                            ProductID = product.ProductID,
                            ProductName = product.Product_Name,
                            OutgoingGrossWeight = outgoing.Gross_Weight,
                            OutgoingTareWeight = outgoing.Tare_Weight,
                            OutgoingNetWeight = outgoing.Net_Weight
                        };

            return await query.ToListAsync();
        }
    }
}
   

