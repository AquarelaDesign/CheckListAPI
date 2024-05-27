namespace CheckListAPI.Models
{
    public class UsersAddDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string[] Roles { get; set; }
    }
}
