using PersonalityTest.Infrasturcture;
using PersonalityTest.Resource;
using PersonalityTest.Resource.Contract;

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
            Question[] result = testResource.GetQuestions();

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
            int numberOfQuestions = questions.Length;
            foreach (Contract.Question question in questions)
            {
                score += question.Value;
            }

            int extrovert = numberOfQuestions * 3;
            int introvert = numberOfQuestions * 2;
            int extrovertOutFirst = introvert;
            int extrovertOutSecond = introvert + ((extrovert - introvert) / 2);

            if (score >= extrovert)
            {
                return Personality.Extrovert;
            }
            else if (score <= introvert)
            {
                return Personality.Introvert;
            }
            else if (score > extrovertOutFirst && score <= extrovertOutSecond)
                return Personality.IntrovertOut;
            else
                return Personality.ExtrovertOut;
        }

        private Question[] GetTestQuestions(Question[] questions)
        {
            int range = questions.Length > 5 ? 5 : questions.Length;
            Question[] result = new Question[range];

            Random r = new();
            int max = range > 5 ? 9 : range;
            var position = Enumerable.Range(0, max).OrderBy(x => r.Next()).Take(range).ToArray();

            for (int i = 0; i < range; i++)
            {
                result[i] = questions[position[i]];
            }

            return result;
        }
    }
}