using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class UpdateProfileDTO
    {
        public int Id;
        public string Name;
        public EmployeeType Type;
        public string Email;
        public string Password;
        public float Rate;
    }
}
