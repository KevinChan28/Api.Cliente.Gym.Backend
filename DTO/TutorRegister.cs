namespace Aplication.Client.API.DTO
{
    public class TutorRegister
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public int KinshipId { get; set; }
        public AddressRegister Address { get; set; }
        public SocialMediaRegister? SocialMedia { get; set; }
    }
}
