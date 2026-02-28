namespace WebApplication1.Models
{
    public class FullTimeEmployee(int id, string name, float hourlyRate) : Employee(id, name, hourlyRate, EmployeeType.FULLTIME)
    {
        public override float ComputeMonthlySalary()
        {
            return this.Rate * 40 * 4;
        }
    }
}
