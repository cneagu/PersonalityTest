namespace PersonalityTest.Resource.Contract
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Question[] Questions { get; set; }
        public bool IsValid { get; set; }
    }
}
