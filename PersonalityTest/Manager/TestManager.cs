using PersonalityTest.Infrasturcture;
using PersonalityTest.Resource.Contract;
using System.Text;

namespace PersonalityTest.Manager
{
    public class TestManager : Contract.ITestManager
    {
        private ITestResource testResource;
        public TestManager(ITestResource testResource)
        {
            this.testResource = testResource;
        }
        public Contract.Question[] GetQuestions()
        {
            Question[] result = testResource.GetGuestions();


            if (result == null || result.Length == 0)
                return null;

            foreach (Question question in result)
            {
                if (question.Options == null)
                    question.Options = testResource.GetOptionsByID(question.ID);
            }

            return GetTestQuestions(result).DeepCopy<Contract.Question[]>();
        }

        public string GetPersonalityType(Contract.Question[] questions)
        {
            int score = 0;
            foreach (Contract.Question question in questions)
            {
                score+=question.Value;
            }

            if (score > 14)
            {
                return "Your personality is Extrovert";
            } 
            else if(score < 11)
            {
                return "Your personality is Introvert";
            }
            else if (score == 11 | score == 12)
                return "Your personality is Extrovert but your inner personality is Introvert";
            else
                return "Your personality is Introvert but your inner personality is Extrovert";
        }

        private Question[] GetTestQuestions(Question[] questions)
        {
            Question[] result = new Question[5]; 
            Random r = new();
            var position = Enumerable.Range(0, 9).OrderBy(x => r.Next()).Take(5).ToArray();

            for (int i = 0; i < 5; i++)
            {
                result[i] = questions[position[i]];
            }

            return result;
        }
    }
}
