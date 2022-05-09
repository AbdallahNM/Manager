namespace Manager.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList = new List<Employee>();
        public MockEmployeeRepository()
        {


            _employeeList.Add(new Employee() { Id = 1, Name = "Ali", Department = Dept.HR, Email = "Ali@gmail.com" });
            _employeeList.Add(new Employee() { Id = 2, Name = "khaled", Department = Dept.Tich, Email = "Khaled@gmail.com" });
            _employeeList.Add(new Employee() { Id = 3, Name = "Sam", Department = Dept.IT, Email = "Sam@gmail.com" });
            _employeeList.Add(new Employee() { Id = 4, Name = "Abeer", Department = Dept.CEO, Email = "Abeer@gmail.com" });
            _employeeList.Add(new Employee() { Id = 5, Name = "Muath", Department = Dept.IT, Email = "Muath@gmail.com" });
            _employeeList.Add(new Employee() { Id = 6, Name = "John", Department = Dept.Engineer, Email = "Jhon@gmail.com" });
        }

        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = _employeeList.Max(emp => emp.Id)+1;
            _employeeList.Add(employee);
            return employee;
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
