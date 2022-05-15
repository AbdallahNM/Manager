namespace Manager.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList = new List<Employee>();
        public MockEmployeeRepository()
        {


            _employeeList.Add(new Employee() { Id = 1, Name = "Ali" , PhoneNumber = "0777777777", Department = Dept.HR, Email = "Ali@gmail.com" });
            _employeeList.Add(new Employee() { Id = 2, Name = "khaled", PhoneNumber ="0799999999" , Department = Dept.Tich, Email = "Khaled@gmail.com" });
            _employeeList.Add(new Employee() { Id = 3, Name = "Sam", PhoneNumber = "0792346332", Department = Dept.IT, Email = "Sam@gmail.com" });
            _employeeList.Add(new Employee() { Id = 4, Name = "Abeer", PhoneNumber =" 0799277892", Department = Dept.CEO, Email = "Abeer@gmail.com" });
            _employeeList.Add(new Employee() { Id = 5, Name = "Muath", PhoneNumber = "0799978945", Department = Dept.IT, Email = "Muath@gmail.com" });
            _employeeList.Add(new Employee() { Id = 6, Name = "John", PhoneNumber = "0799917704", Department = Dept.Engineer, Email = "Jhon@gmail.com" });
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(emp => emp.Id)+1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(emp => emp.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(emp => emp.Id == employeeChanges.Id);
            if(employee!= null)
            {
                employee.Name = employeeChanges.Name;
                employee.PhoneNumber = employeeChanges.PhoneNumber;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
            }
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
