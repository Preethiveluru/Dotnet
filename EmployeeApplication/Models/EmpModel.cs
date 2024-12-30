using System.ComponentModel.DataAnnotations;

namespace EmployeeApplication.Models
{
    public class EmpModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
