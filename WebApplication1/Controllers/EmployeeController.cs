using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("employee/[controller]")]
    public class EmployeeController : Controller
    {
        EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get")]
        public Employee GetEmployeeById([FromQuery] int id)
        {
            return _service.GetEmployeeById(id);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(
                IFormFile file
            )
        {
            Console.WriteLine("file");
            Console.WriteLine(file);
            if(file == null)
            {
                return BadRequest("Empty File Detected");
            }
            return Ok(new
            {
                file = file.FileName
            });
        }


        [HttpGet("get-list")]
        public List<Employee> GetEmployees()
        {
            return _service.GetEmployees();
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            try
            {
                Employee emp =  _service.AddEmployee(createEmployeeDTO);
                return Ok(new
                {
                    emp.Id,
                    emp.Name,
                    emp.Rate
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("salary")]
        public float GetEmployeeSalaryById([FromQuery]int id)
        {
            var emp = _service.GetEmployeeById(id);
            return emp.ComputeMonthlySalary();
        }
        
        //// GET: EmployeeController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: EmployeeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: EmployeeController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: EmployeeController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EmployeeController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: EmployeeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EmployeeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
