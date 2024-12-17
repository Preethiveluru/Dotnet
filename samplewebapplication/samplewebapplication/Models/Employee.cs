using System.ComponentModel.DataAnnotations;

namespace samplewebapplication.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Required]
        public string? Department { get; set; }

        public int? Salary { get; set; }
    }
}

