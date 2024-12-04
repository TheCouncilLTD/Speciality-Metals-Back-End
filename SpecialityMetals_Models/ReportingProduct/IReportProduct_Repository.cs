namespace Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingProduct
{
    public interface IReportProduct_Repository
    {
        Task<IEnumerable<ReportProduct>> GetProductDeliveryNotesAsync(string productName);
    }
}
