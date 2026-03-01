using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class FilterEmployeeDTO
    {
        public EmployeeType? type { get; set; }
        public float? minRate{get;set;}
        public float? maxRate{get;set;}

    }
}
