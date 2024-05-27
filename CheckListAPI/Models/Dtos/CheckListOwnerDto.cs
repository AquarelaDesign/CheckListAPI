namespace CheckListAPI.Models.Dtos
{
    public class CheckListOwnerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Cpf { get; set; }
        public required string Phone { get; set; }
    }
}
