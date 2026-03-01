namespace WebApplication1.Models
{
    public class FullTimeEmployee(int id, string name, float hourlyRate, string email, string password) : Employee(id, name, hourlyRate, EmployeeType.FULLTIME, email, password)
    {
        public override float ComputeMonthlySalary()
        {
            return this.Rate * 40 * 4;
        }
    }
}
