namespace CheckListAPI.Models
{
    public class CheckListOwner
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Cpf { get; set; }
        public required string Phone { get; set; }

    }
}
