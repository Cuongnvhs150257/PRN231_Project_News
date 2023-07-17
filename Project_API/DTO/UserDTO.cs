namespace Project_API.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
    }
}
