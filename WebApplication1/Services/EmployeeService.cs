using Microsoft.AspNetCore.Mvc;
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
                    employee = new FullTimeEmployee(newId, createEmployeeDTO.Name, createEmployeeDTO.Rate);
                    employees.Add(employee);
                    break;
                case EmployeeType.PARTTIME:
                    employee = new PartTimeEmployee(newId, createEmployeeDTO.Name, createEmployeeDTO.Rate);
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

    }
}
