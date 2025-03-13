namespace RentCar.Api.Models
{
    public class RentOffer
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int CarYear { get; set; }
        public FuelType FuelType { get; set; }
        public GearBoxType GearBoxType { get; set; }
        public int Horsepower { get; set; }
        public decimal Price { get; set; }
        public string[] PhotoPaths { get; set; }
    }
}