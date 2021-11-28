using Microsoft.Extensions.Logging;
using PersonalityTest.Data.Repositories.Contract;
using PersonalityTest.Infrasturcture;
using PersonalityTest.Resource.Contract;

namespace PersonalityTest.Resource
{
    public class TestResource : ITestResource
    {
        private IPersonalityTestRepository repository;
        private readonly ILogger<TestResource> logger;
        public TestResource(IPersonalityTestRepository repository, ILogger<TestResource> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public Question[] GetGuestions()
        {
            try
            {
                return repository.Questions.ToArray().DeepCopy<Question[]>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public List<Option> GetOptions()
        {
           try
            {
                return repository.Options.ToList().DeepCopy<List<Option>>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public List<Option> GetOptionsByID(Guid id)
        {
            try
            {
                return repository.Options.ToList().FindAll(y => y.QuestionId == id).DeepCopy<List<Option>>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
