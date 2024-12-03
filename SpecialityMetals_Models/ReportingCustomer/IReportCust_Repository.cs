namespace Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingCustomer
{
    public interface IReportCust_Repository
    {
        Task<IEnumerable<ReportCust>> GetCustomerDeliveryNotesAsync(string customerName);
    }
}
