namespace WebApplication1.Models
{
    public class User
    {
        public static int IdNumber = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; } = "User";

        public User(string username, string email)
        {
            this.Id = User.IdNumber++;
            this.Username = username;
            this.Email = email;
            this.Name = "";
            this.HashedPassword = "";
        }
    }
}
