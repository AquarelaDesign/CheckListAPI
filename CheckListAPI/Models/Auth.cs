namespace CheckListAPI.Models
{
    public class Auth
    {
        public int Id { get; set; }
        public Users? User { get; set; }
        public string? Token { get; set; }
    }
}
