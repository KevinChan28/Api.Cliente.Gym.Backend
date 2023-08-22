namespace Aplication.Client.API.DTO
{
    public class CustomerAnswerTestRegister
    {
        public int TestId { get; set; }
        public int CustomerId { get; set; }
        public List<QuestionsAnsweredDTO> QuestionsAnswereds { get; set; }
    }
}
