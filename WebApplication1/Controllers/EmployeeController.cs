using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : Controller
    {
        EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("get")]
        public List<Employee> GetEmployees([FromQuery] FilterEmployeeDTO filter) {
            return _service.GetEmployees(filter);
        }

        [Authorize]
        [HttpGet("salary")]
        public float GetEmployeeSalaryById([FromQuery] int id)
        {
            var emp = _service.GetEmployeeById(id);
            return emp.ComputeMonthlySalary();
        }

        [Authorize]
        [HttpGet("get-list")]
        public List<Employee> GetAllEmployees()
        {
            return _service.GetAllEmployees();
        }

        [Authorize]
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(
                IFormFile file
            )
        {
            Console.WriteLine("file");
            Console.WriteLine(file);
            if (file == null)
            {
                return BadRequest("Empty File Detected");
            }
            return Ok(new
            {
                file = file.FileName
            });
        }




        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            try
            {
                Employee emp = _service.AddEmployee(createEmployeeDTO);
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

        [HttpPatch("update")]
        public IActionResult UpdateProfile(UpdateProfileDTO newProfile)
        {
            try
            {
                Employee emp = _service.UpdateEmployeeProfile(newProfile);
                return Ok(new
                {
                    message = "Update Successful"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _service.DeleteEmployee(id);
                return Ok(new
                {
                    message = "User Deleted"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
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
