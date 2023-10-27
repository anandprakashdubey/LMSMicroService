namespace LMS.PharmacyService.API.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public int PharmacyId { get; set; }
    }
}
