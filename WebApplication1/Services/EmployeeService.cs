using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EmployeeService
    {
        private static List<Employee> employees = new List<Employee>();
        private static int IDNUM = 0;

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee AddEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            int newId = EmployeeService.IDNUM++;
            Employee employee;
            switch (createEmployeeDTO.Type)
            {
                case EmployeeType.FULLTIME:
                    employee = new FullTimeEmployee(newId, createEmployeeDTO.Name, createEmployeeDTO.Rate, createEmployeeDTO.Email, createEmployeeDTO.Password); //make sure to hash password
                    employees.Add(employee);
                    break;
                case EmployeeType.PARTTIME:
                    employee = new PartTimeEmployee(newId, createEmployeeDTO.Name, createEmployeeDTO.Rate, createEmployeeDTO.Email, createEmployeeDTO.Password);
                    employees.Add(employee);
                    break;
                default:
                    throw new Exception("Type Not Indicated");
            }
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.Where(e => e.Id == id).First();
        }

        public Employee UpdateEmployeeProfile(UpdateProfileDTO updateProfileDTO)
        {
            Employee user = employees.Where(e => e.Id == updateProfileDTO.Id).First();
            int index = EmployeeService.employees.IndexOf(user);
            user = UpdateUser(user, updateProfileDTO);
            employees.Insert(index, user);
            return user;
        }

        public void DeleteEmployee(int id)
        {
            Employee user = employees.Where(e => e.Id == id).First();
            int index = employees.IndexOf(user);
            user.IsActive = false;
            employees.Insert(index,user);
        }

        private static Employee UpdateUser(Employee user, UpdateProfileDTO updateProfileDTO)
        {
            if (user.Id != updateProfileDTO.Id)
            {
                throw new ArgumentException("Mismatched Id");
            }
            user.Name = updateProfileDTO.Name;
            user.Rate = updateProfileDTO.Rate;
            user.Type = updateProfileDTO.Type;
            user.Email = updateProfileDTO.Email;
            user.Password = updateProfileDTO.Password;

            return user;
        }

    }
}
