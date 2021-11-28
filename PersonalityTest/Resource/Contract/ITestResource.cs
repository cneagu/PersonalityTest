namespace PersonalityTest.Resource.Contract
{
    public interface ITestResource
    {
        Question[] GetQuestions();
        List<Option> GetOptions();
        List<Option> GetOptionsByID(Guid id);
    }
}