using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMSWebApplication.Models
{
    public class DMS
    {
        [Key] 
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Qualification { get; set; }
        public string? speciality { get; set; }
        
    }
}

