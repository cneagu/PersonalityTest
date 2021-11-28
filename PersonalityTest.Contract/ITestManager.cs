namespace PersonalityTest.Contract
{
    public interface ITestManager
    {
        Question[] GetQuestions();
        string GetPersonalityType(Question[] questions);
    }
}
