namespace Speciality_Metals_Back_End.SpecialityMetals_Models.AllDeliveriesWeighed
{
    public class AllDeliveriesWeighed
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; } // Product name from the product table
        public decimal? IncomingGrossWeight { get; set; }
        public decimal? IncomingTareWeight { get; set; }
        public decimal? IncomingNetWeight { get; set; }
    }
}
