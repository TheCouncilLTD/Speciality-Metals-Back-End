namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models
{
    public interface IProduct_Repository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}

