namespace WebApplication1.Models
{
    public class Employee
    {
        public static List<Employee> employees = new List<Employee>();
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
        public EmployeeType Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Employee(int id, string name, float hourlyRate, EmployeeType type, string email, string password)
        {
            Id = id;
            Name = name;
            Type = type;
            Rate = hourlyRate;
            Email = email;
            Password = password;
            IsActive = true;
        }
        public virtual float ComputeMonthlySalary()
        {
            return 0;
        }
    }
}
