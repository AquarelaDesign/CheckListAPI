namespace CheckListAPI.Models.Dtos
{
    public class UsersDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string[] Roles { get; set; }
    }
}
