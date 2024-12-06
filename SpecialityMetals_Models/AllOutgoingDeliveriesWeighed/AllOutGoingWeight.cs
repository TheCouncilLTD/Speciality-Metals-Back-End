namespace Speciality_Metals_Back_End.SpecialityMetals_Models.AllOutgoingDeliveriesWeighed
{
    public class AllOutGoingWeight
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal? OutgoingGrossWeight { get; set; }
        public decimal? OutgoingTareWeight { get; set; }
        public decimal? OutgoingNetWeight { get; set; }
    }
}
