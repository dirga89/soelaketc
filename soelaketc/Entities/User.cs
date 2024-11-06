namespace soelaketc.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
