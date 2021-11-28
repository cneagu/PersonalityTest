namespace PersonalityTest.Models
{
    public class TestRequest
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public Question[] Questions { get; set; }
        public bool IsValid { get; set; }
    }
}
