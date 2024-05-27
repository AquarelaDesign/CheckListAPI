namespace CheckListAPI.Models
{
    public class CheckListItens
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public required string Description { get; set; }
        public string? Comments { get; set; }
        public bool Status { get; set; } = false;
    }
}
