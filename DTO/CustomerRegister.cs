using Aplication.Client.API.Models;

namespace Aplication.Client.API.DTO
{
    public class CustomerRegister
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public AddressRegister Address { get; set; }
        public IdentificationImagerRegister IdentificationImage { get; set; }
        public SocialMediaRegister? SocialMedia { get; set; }
    }
}
