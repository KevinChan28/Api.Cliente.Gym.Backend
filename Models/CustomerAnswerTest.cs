using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Aplication.Client.API.DTO;

namespace Aplication.Client.API.Models
{
    [Table("customeranswertest")]
    public class CustomerAnswerTest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TestId { get; set; }
        public int CustomerId { get; set; }
        public int QuestionId { get; set; }
        public int TestAnswerId { get; set; }
        public string PersonalizedDescriptionAnswer{ get; set; }
    }
}
