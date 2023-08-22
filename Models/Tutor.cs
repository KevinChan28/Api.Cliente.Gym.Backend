using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication.Client.API.Models
{
    [Table("tutor")]
    public class Tutor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int KinshipId { get; set; }
        public int SocialMediaId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate{ get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}
