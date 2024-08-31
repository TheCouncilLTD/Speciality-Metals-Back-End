using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models
{
    public class Product_Repository : IProduct_Repository
    {
        private readonly Product_Context _context;

        public Product_Repository(Product_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            var existingProduct = await _context.Product.FindAsync(product.ProductID);
            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Product_Name = product.Product_Name;
            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
