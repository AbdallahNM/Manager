using Manager.Models;
using System.ComponentModel.DataAnnotations;

namespace Manager.ViewModels
{
    public class EmployeeImageDataUpload
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "work mail")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        //public Department Departments { get; set; }

        [Required(ErrorMessage = "Required Field")]

        public int Age { get; set; }

        public IFormFile Image { get; set; }
    }
}
