namespace Speciality_Metals_Back_End.SpecialityMetals_Models.AllOutgoingDeliveriesWeighed
{
    public interface IAllOutGoingWeight_Repository
    {
        Task<IEnumerable<AllOutGoingWeight>> GetOutgoingWeightDetailsAsync();
    }
}
