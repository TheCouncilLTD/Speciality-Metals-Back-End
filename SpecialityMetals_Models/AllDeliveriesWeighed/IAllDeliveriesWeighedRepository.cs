namespace Speciality_Metals_Back_End.SpecialityMetals_Models.AllDeliveriesWeighed
{
    public interface IAllDeliveriesWeighedRepository
    {
        Task<IEnumerable<AllDeliveriesWeighed>> GetIncomingWeightDetailsAsync();
    }
}
