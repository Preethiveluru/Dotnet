using System.ComponentModel.DataAnnotations;

namespace WebApplicationApiEF.Models
{
    public class PetAnimal
    {
        [Key]
        public int petId { get; set; }

        public string petName { get; set; }

        public string petType { get; set; }

     // public string DOB { get; set; }

        public bool IsVeg { get; set; }
    }
}
