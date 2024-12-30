namespace Medicines_Management.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExpiryDate { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
    }
}
