namespace Aplication.Client.API.DTO
{
    public class TestDTO
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string DescriptionTest { get; set; }
        public string IntructionsTest { get; set; }
        public List<QuestionTest> Questions { get; set; }
    }

    public class QuestionTest
    {
        public int QuestionId { get; set; }
        public string DescriptionQuestion { get; set; }
        public List<TestAnswer> Answer { get; set; }
    }

    public class TestAnswer
    {
        public int AnswerId { get; set; }
        public int QuestionIdAnswer { get; set; }
        public string DescriptionAnswer { get; set; }
        public int RequirePersonalizedDescription { get; set; }
        public string ComponentType { get; set; }
    }

}
