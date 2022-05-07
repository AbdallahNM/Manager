using Manager.Models;
using Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {

        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        ////public string Index(int i)
        ////{
        ////    Employee employee = _employeeRepository.GetEmployee(i);
        ////    return $" Controller/Index{i}"; 


        [Route("")]
        [Route("/")]
        [Route("Index")]

        public ViewResult Index()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAllEmployee();
            return View(employees);

        }
        [Route("Details/{id?}")]
        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()

            {
                Employee = _employeeRepository.GetEmployee(id),
                PageTitle = "Employee List",
                Path = "This PC",
            };
            return View(homeDetailsViewModel);


        }
        public ViewResult Create()
        {
            
            return View();

        }
    }
}
