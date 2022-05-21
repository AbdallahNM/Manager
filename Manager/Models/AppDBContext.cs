using Microsoft.EntityFrameworkCore;

namespace Manager.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "Ali",
                PhoneNumber = "0777777777",
                Department = Dept.HR,
                Email = "Ali@gmail.com",
                Age = 24,
                ImagePath = ""
            },
            new Employee
            {
                Id = 2,
                Name = "khaled",
                PhoneNumber = "0792999999",
                Department = Dept.Tich,
                Email = "Khaled@gmail.com",
                Age = 33,
                ImagePath = ""
            },
            new Employee
            {
                Id = 3,
                Name = "Sam",
                PhoneNumber = "0792346332",
                Department = Dept.IT,
                Email = "Sam@gmail.com",
                Age = 56,
                ImagePath = ""
            });
            //new Employee
            //{
            //    Id = 4, Name = "Abeer", PhoneNumber = "0799277892", Department = Dept.CEO, Email = "Abeer@gmail.com", Age = 40,ImagePath=""
            //},
            //new Employee
            //{
            //    Id = 5, Name = "Muath", PhoneNumber = "0799978945", Department = Dept.IT, Email = "Muath@gmail.com" ,Age = 22,ImagePath=""
            //},
            //new Employee
            //{
            //    Id = 6, Name = "John", PhoneNumber = "0799917704", Department = Dept.Engineer, Email = "Jhon@gmail.com" ,Age = 30,ImagePath=""
            //});

            modelbuilder.Entity<Department>().HasData(new Department
            {
                Id = 1, Name = "HR", Location = "SCS Company"
            },
            new Department
            {
                Id = 2 ,Name ="CEO" , Location="Microsoft Company",
            },
            new Department
            {
                Id = 3,Name ="TICH" ,Location="Tichnical Company",
            },
            new Department
            {
                Id=4 ,Name ="ENGINNER",Location="Enginerrnig Company"
            },
            new Department
            {
                Id = 5,Name ="IT" ,Location=" SCS Company",
            },
            new Department
            {
                Id = 6 ,Name ="CEO" ,Location="Google Company",
            });
        }

    }
}
