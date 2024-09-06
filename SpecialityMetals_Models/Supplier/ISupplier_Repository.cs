namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Supplier
{
    public interface ISupplier_Repository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(int supplierId);
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<Supplier> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int supplierId);




        Task<string?> GetProductNameBySupplierIdAsync(int supplierId);
    }
}
