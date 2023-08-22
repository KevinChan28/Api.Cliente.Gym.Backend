using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication.Client.API.Models
{
    [Table("termsandconditions")]
    public class TermsAndConditions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; }
        public  int PoliticsId { get; set; }
        public  string Description { get; set; }
    }
}
