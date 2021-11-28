namespace PersonalityTest.Resource.Contract
{
    public interface ITestResource
    {
        Question[] GetGuestions();
        List<Option> GetOptions();
        List<Option> GetOptionsByID(Guid id);
    }
}