namespace MvcApplicationForCV.Models
{
    public class PersonalInfo
    {
        public int PersonalInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Address> AddressList { get; set; }
    }
}
