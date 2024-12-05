using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.AllDeliveriesWeighed
{
    public class AllDeliveriesWeighedRepository : IAllDeliveriesWeighedRepository
    {
        private readonly AllDeliveriesWeighedContext _context;

        public AllDeliveriesWeighedRepository(AllDeliveriesWeighedContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllDeliveriesWeighed>> GetIncomingWeightDetailsAsync()
        {
            var query = from incoming in _context.Incoming
                        join product in _context.Product // Assuming Products DbSet is present in DbContext
                        on incoming.ProductID equals product.ProductID
                        select new AllDeliveriesWeighed
                        {
                            ProductID = product.ProductID,
                            ProductName = product.Product_Name,
                            IncomingGrossWeight = incoming.Gross_Weight,
                            IncomingTareWeight = incoming.Tare_Weight,
                            IncomingNetWeight = incoming.Net_Weight
                        };

            return await query.ToListAsync();
        }
    }
}