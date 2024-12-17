using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DMSWebApplication.Models
{
    public class patient
    {
        [Key]
        public int PId { get; set; }

        [Required]
        public string PName { get; set; }

        [Required]
        public string PDisease { get; set; }

        [Required]
        public string specilaist { get; set; }

        [ForeignKey("DMS")]

        public int Id { get; set; } 
        
        
    }
}
