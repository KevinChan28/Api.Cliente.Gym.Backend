using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aplication.Client.API.Models
{
    public class TestHealth
    {
        [Column("Id")]
        public int TestId { get; set; }
        public string Name { get; set; }
        public string DescriptionTest { get; set; }
        public string IntructionsTest { get; set; }
        public int QuestionId { get; set; }
        public string DescriptionQuestion { get; set; }
        public int AnswerId { get; set; }
        public string DescriptionAnswer { get; set; }
        public int RequirePersonalizedDescription { get; set; }
        public string ComponentType { get; set; }
    }
}
