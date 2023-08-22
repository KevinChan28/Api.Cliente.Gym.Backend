using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aplication.Client.API.Models
{
    [Table("products")]
    public class Products
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("productName")]
        public string ProductName { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
    }
}
