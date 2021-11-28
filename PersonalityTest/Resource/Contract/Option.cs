namespace PersonalityTest.Resource.Contract
{
    public class Option
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
