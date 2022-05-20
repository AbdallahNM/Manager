using Manager.Models;
using Manager.ViewModels;

using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Manager.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {

        private IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
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
        [HttpGet]
        [Route("Create")]
        public ViewResult Create()
        {
            
            return View();

        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(EmployeeImageDataUpload model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Image != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "-" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create)); 
                }
                Employee newemployee = new Employee
                {
                    Name = model.Name, Age = model.Age, Department = model.Department, PhoneNumber = model.PhoneNumber, Email = model.Email, ImagePath= uniqueFileName
                };
                _employeeRepository.Add(newemployee);
                return RedirectToAction("Details",new { id = newemployee.Id });
            }
                return View();

        }
    }
}
