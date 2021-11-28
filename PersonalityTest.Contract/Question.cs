namespace PersonalityTest.Contract
{
    public class Question
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public List<Option> Options { get; set; }
        public int Value { get; set; } = 0;
    }
}
