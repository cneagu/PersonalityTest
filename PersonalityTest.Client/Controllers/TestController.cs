using Microsoft.AspNetCore.Mvc;
using PersonalityTest.Contract;
using PersonalityTest.Data;
using PersonalityTest.Infrasturcture;
using PersonalityTest.Models;
using Question = PersonalityTest.Models.Question;

namespace PersonalityTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly PersonalityTestContext context;
        private readonly ITestManager testManager;


        public TestController(
            PersonalityTestContext personalityTestContext,
            ITestManager testManager)
        {
            context = personalityTestContext;
            InMemoryData.GetData(context);
            this.testManager = testManager;
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            Question[] questions = testManager.GetQuestions().DeepCopy<Question[]>();

            return Ok(questions);
        }

        [HttpPost]
        public IActionResult SendTest(TestRequest test)
        {
            if (!test.IsValid)
                return BadRequest();

            string personalityType = testManager.GetPersonalityType(test.Questions.DeepCopy<Contract.Question[]>());

            TestResponse response = new() { Name = test.Name, Personality = personalityType };

            return Ok(response);
        }
    }
}
