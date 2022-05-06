namespace Manager.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList = new List<Employee>();
        public MockEmployeeRepository()
        {


            _employeeList.Add(new Employee() { Id = 1, Name = "Ali", Department = "HR", Email = "Ali@gmail.com" });
            _employeeList.Add(new Employee() { Id = 2, Name = "khaled", Department = "Tich", Email = "Khaled@gmail.com" });
            _employeeList.Add(new Employee() { Id = 3, Name = "Sam", Department = "IT", Email = "Sam@gmail.com" });
            _employeeList.Add(new Employee() { Id = 4, Name = "Abeer", Department = "Tich", Email = "Abeer@gmail.com" });
            _employeeList.Add(new Employee() { Id = 5, Name = "Muath", Department = "IT", Email = "Muath@gmail.com" });
            _employeeList.Add(new Employee() { Id = 6, Name = "John", Department = "Engineer", Email = "Jhon@gmail.com" });
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(emp => emp.Id == Id);
        }
    }
}
