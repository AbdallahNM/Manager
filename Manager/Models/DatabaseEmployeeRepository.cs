namespace Manager.Models
{
    public class DatabaseEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList = new List<Employee>();
        public DatabaseEmployeeRepository()
        {


            _employeeList.Add(new Employee() { Id = 1, Name = "Ali", Department = Dept.HR, Email = "Ali@gmail.com" });
            _employeeList.Add(new Employee() { Id = 2, Name = "khaled", Department = Dept.IT, Email = "Khaled@gmail.com" });
            _employeeList.Add(new Employee() { Id = 3, Name = "Sam", Department = Dept.CEO, Email = "Sam@gmail.com" });

        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(emp => emp.Id == Id);
        }

        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = _employeeList.Max(emp => emp.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
    }
}
