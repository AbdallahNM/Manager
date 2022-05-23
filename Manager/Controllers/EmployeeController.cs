
using Manager.Models;
using Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Manager.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
       
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        //public ViewResult Index()
        //{
        //    ViewData["PageTitle"] = "EmployeeList";
        //    return View();
        //}
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(int id, Employee employee)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
