using System.ComponentModel.DataAnnotations;

namespace Manager.Models
{
    public class Employee
    {
        [Required]
        [RegularExpression("1")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [RegularExpression("emailname@gmail.com")]
        public string Email { get; set; }
        [Required]
        public Dept Department { get; set; }
    }
}
