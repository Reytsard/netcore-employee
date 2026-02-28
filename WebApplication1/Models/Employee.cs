using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class Employee
    {
        public static List<Employee> employees = new List<Employee>();
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
        public EmployeeType Type { get; set; }
        public Employee(int id, string name, float hourlyRate, EmployeeType type)
        {
            Id = id;
            Name = name;
            Type = type;
            Rate = hourlyRate;
        }
        public virtual float ComputeMonthlySalary() {
            return 0;
        }
    }
}
