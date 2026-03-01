namespace WebApplication1.Models
{
    public class PartTimeEmployee(int id, string name, float rate, string email, string password) : Employee(id, name, rate, EmployeeType.PARTTIME, email, password)
    {
        public override float ComputeMonthlySalary()
        {
            return this.Rate * 20 * 4;
        }
    }
}
