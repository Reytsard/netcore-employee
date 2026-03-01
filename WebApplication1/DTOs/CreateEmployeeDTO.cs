using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class CreateEmployeeDTO
    {
        public string Name { get; set; }
        public float Rate { get; set; }
        public EmployeeType Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
