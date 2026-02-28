namespace WebApplication1.Models
{
    public class PartTimeEmployee(int id, string name, float rate):Employee(id, name, rate, EmployeeType.PARTTIME)
    {
        public override float ComputeMonthlySalary()
        {
            return this.Rate * 20 * 4;
        }
    }
}
