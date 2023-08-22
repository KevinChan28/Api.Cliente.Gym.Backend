using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication.Client.API.Models
{
    [Table("politics")]
    public class Politics
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PoliticsTypeId { get; set; }
        public string Description { get; set; }
    }
}
