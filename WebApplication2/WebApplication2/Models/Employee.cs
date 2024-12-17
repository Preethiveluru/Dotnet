using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [MaxLength(20)]
        public string? Department { get; set; }

        [Required]
        public int? Salary { get; set; }

    }
}
