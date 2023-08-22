using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aplication.Client.API.Models
{
    [Table("customerpolitics")]
    public class CustomerPolitics
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TutorId { get; set; }
        public int PoliticsId { get; set; }
        public bool IsAccepted { get; set; }

    }
}