using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication.Client.API.Models
{
    [Table("address")]
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nationality { get; set; }
        public string? Municipaly { get; set; }
        public string? Locality { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string InteriorNumber { get; set; }
        public string OutdoorNumber { get; set; }
    }
}
