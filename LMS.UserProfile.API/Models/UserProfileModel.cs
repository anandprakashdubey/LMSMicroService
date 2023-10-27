namespace LMS.UserProfile.API.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HospitalName { get; set; }
        public string DoctorName { get; set; }
        public string Prescription  { get; set; }

    }
}
