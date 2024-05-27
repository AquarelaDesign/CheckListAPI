namespace CheckListAPI.Models.Dtos
{
    public class CheckListVehicleAddDto
    {
        public int? OwnerId { get; set; }
        public required string LicensePlate { get; set; }
        public required int Year { get; set; }
        public required string Model { get; set; }
        public int? Mileage { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
