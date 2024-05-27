namespace CheckListAPI.Models
{
    public class Users
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string[] Roles { get; set; }
    }
}
