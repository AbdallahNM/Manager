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

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
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
            Employee employee = _employeeRepository.GetEmployee(id);
            if (employee is null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee List",
                Path = "This PC",
            };
            return View(homeDetailsViewModel);


        }
        [HttpGet]
        //[Route("Create")]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        //[Route("Create")]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //string uniqueFileName = null;
                //if (model.Image != null)
                //{
                //    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                //    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                //}
                string uniqueFileName = ProcessUploadFile(model);
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Age = model.Age,
                    Department = model.Department,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    ImagePath = uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();

        }
        //[HttpGet]
        //public ViewResult Edit(int id)
        //{
        //    Employee employee = _employeeRepository.GetEmployee(id);
        //    EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
        //    {
        //        Id = employee.Id,
        //        Name = employee.Name,
        //        Age = employee.Age,
        //        Department = employee.Department,
        //        PhoneNumber = employee.PhoneNumber,
        //        Email = employee.Email,
        //        ExistingImagePath = employee.ImagePath
        //    };

        //    return View(employeeEditViewModel);
        //}
        //[HttpPost]
        //public IActionResult Edit(EmployeeEditViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee employee = _employeeRepository.GetEmployee(model.Id);
        //        employee.Name = model.Name;
        //        employee.Age = model.Age;
        //        employee.Department = model.Department;
        //        employee.PhoneNumber = model.PhoneNumber;
        //        employee.Email = model.Email;
        //        if (model.Image != null)
        //        {
        //            if (model.ExistingImagePath != null)
        //            {
        //                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingImagePath);
        //                System.IO.File.Delete(filePath);
        //            }
        //            employee.ImagePath = ProcessUploadFile(model);
        //            //////}
        //            //////string uniqueFileName = ProcessUploadFile(model);
        //            //////Employee newemployee = new Employee
        //            //////{
        //            //////    Name = model.Name,
        //            //////    Age = model.Age,
        //            //////    Department = model.Department,
        //            //////    PhoneNumber = model.PhoneNumber,
        //            //////    Email = model.Email,
        //            //////    ImagePath = uniqueFileName
        //            //////};
        //        }
        //        _employeeRepository.Update(employee);
        //        //////return RedirectToAction("Details", new { id = newemployee.Id });
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}
        


        private string ProcessUploadFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }
        //private string ProcessUploadedFile(EmployeeCreateViewModel model)
        //{
        //    string uniqueFileName = null;
        //    if (model.Image != null)
        //    {
        //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.Image.CopyTo(fileStream);
        //        }
        //    }

        //    return uniqueFileName;
        //}
    }
}
