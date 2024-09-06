using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Supplier
{
    public class Supplier_Repository : ISupplier_Repository
    {
        private readonly Supplier_Context _context;

        public Supplier_Repository(Supplier_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Supplier.ToListAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(int supplierId)
        {
            return await _context.Supplier.FindAsync(supplierId);
        }

        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            _context.Supplier.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> UpdateSupplierAsync(Supplier supplier)
        {
            _context.Supplier.Update(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var supplier = await _context.Supplier.FindAsync(supplierId);
            if (supplier == null)
            {
                return false;
            }

            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<string?> GetProductNameBySupplierIdAsync(int supplierId)
        {
            var query = from supplier in _context.Supplier
                        join product in _context.Product on supplier.ProductID equals product.ProductID
                        where supplier.SupplierID == supplierId
                        select product.Product_Name;

            return await query.FirstOrDefaultAsync();
        }
    }
}
