using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aplication.Client.API.Models
{
    [Table("incomeproduct")]
    public class IncomeProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ProductId")]
        public int ProductId { get; set; }
        [Column("Concept")]
        public string Concept { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
