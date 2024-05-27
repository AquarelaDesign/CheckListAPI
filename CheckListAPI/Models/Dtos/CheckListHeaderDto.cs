namespace CheckListAPI.Models.Dtos
{
    public class CheckListHeaderDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? VeichleId { get; set; }
        public int? VeichleItensId { get; set; }
        public int? OwnerId { get; set; }
        public int? SupervisorId { get; set; }
        public string? Comments { get; set; }
        public bool Status { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
