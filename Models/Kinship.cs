using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication.Client.API.Models
{
    [Table("kinship")]
    public class Kinship
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int KinshipId { get; set; }
        [Column("Description")]
        public string Description { get; set; }
    }
}
