using Moq;
using PersonalityTest.Manager;
using PersonalityTest.Resource;
using PersonalityTest.Resource.Contract;
using System;
using System.Collections.Generic;
using Xunit;

namespace PersonalityTest.Tests
{
    public class TestManagerTests
    {
        private readonly Contract.ITestManager testManager;
        private Mock<ITestResource> testResource;
        public TestManagerTests()
        {
            testResource = new Mock<ITestResource>();
            testManager = new TestManager(testResource.Object);
        }

        [Fact]
        public void TestManager_GetQuestions_QuestionsShouldReturn()
        {
            Question[] questions = new[]
            {
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "You’re really busy at work and a colleague is telling you their life story and personal woes. You:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "You’ve been sitting in the doctor’s waiting room for more than 25 minutes. You:",
                    Value = 0

                }
            };

            List<Option> options = new()
            {
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[0].ID,
                    Text = "Don’t dare to interrupt them",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[0].ID,
                    Text = "Think it’s more important to give them some of your time; work can wait",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[0].ID,
                    Text = "Listen, but with only with half an ear",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[0].ID,
                    Text = "Interrupt and explain that you are really busy at the moment",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[1].ID,
                    Text = "Look at your watch every two minutes",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[1].ID,
                    Text = "Bubble with inner anger, but keep quiet",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[1].ID,
                    Text = "Explain to other equally impatient people in the room that the doctor is always running late",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[1].ID,
                    Text = "Complain in a loud voice, while tapping your foot impatiently",
                    Value = 4
                }
            };

            testResource.Setup(x => x.GetQuestions()).Returns(questions);
            testResource.Setup(x => x.GetOptionsByID(questions[0].ID)).Returns(options.FindAll(s => s.QuestionId == questions[0].ID));
            testResource.Setup(x => x.GetOptionsByID(questions[1].ID)).Returns(options.FindAll(s => s.QuestionId == questions[1].ID));

            Contract.Question[] result = testManager.GetQuestions();

            Assert.Equal(questions.Length, result.Length);
        }

        [Fact]
        public void TestManager_GetQuestions_QuestionsShouldReturnWithOptions()
        {
            Question[] questions = new[]
            {
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "You’re really busy at work and a colleague is telling you their life story and personal woes. You:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "You’ve been sitting in the doctor’s waiting room for more than 25 minutes. You:",
                    Value = 0

                }
            };

            List<Option> options = new()
            {
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[0].ID,
                    Text = "Don’t dare to interrupt them",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[0].ID,
                    Text = "Think it’s more important to give them some of your time; work can wait",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[0].ID,
                    Text = "Listen, but with only with half an ear",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[0].ID,
                    Text = "Interrupt and explain that you are really busy at the moment",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[1].ID,
                    Text = "Look at your watch every two minutes",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[1].ID,
                    Text = "Bubble with inner anger, but keep quiet",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[1].ID,
                    Text = "Explain to other equally impatient people in the room that the doctor is always running late",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[1].ID,
                    Text = "Complain in a loud voice, while tapping your foot impatiently",
                    Value = 4
                }
            };

            questions[0].Options = options.FindAll(s => s.QuestionId == questions[0].ID);
            questions[1].Options = options.FindAll(s => s.QuestionId == questions[1].ID);
            testResource.Setup(x => x.GetQuestions()).Returns(questions);

            Contract.Question[] result = testManager.GetQuestions();

            Assert.Equal(questions.Length, result.Length);
        }

        [Fact]
        public void TestManager_GetPersonalityType_ReturnExtrovert()
        {
            Contract.Question[] questions = new[]
            {
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 4
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 4
                },
                 new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 3
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 4
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 3
                }
            };

            string personality = testManager.GetPersonalityType(questions);

            Assert.Equal(Personality.Extrovert, personality);
        }

        [Fact]
        public void TestManager_GetPersonalityType_ReturnIntrovert()
        {
            Contract.Question[] questions = new[]
            {
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 2
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 2
                },
                 new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 2
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 2
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 2
                }
            };

            string personality = testManager.GetPersonalityType(questions);

            Assert.Equal(Personality.Introvert, personality);
        }

        [Fact]
        public void TestManager_GetPersonalityType_ReturnIntrovertOut()
        {
            Contract.Question[] questions = new[]
            {
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 2
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 1
                },
                 new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 3
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 4
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 2
                }
            };

            string personality = testManager.GetPersonalityType(questions);

            Assert.Equal(Personality.IntrovertOut, personality);
        }

        [Fact]
        public void TestManager_GetPersonalityType_ReturnExtrovertOut()
        {
            Contract.Question[] questions = new[]
            {
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 4
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 1
                },
                 new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 3
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 3
                },
                new Contract.Question
                {
                    ID = Guid.NewGuid(),
                    Text = "",
                    Value = 2
                }
            };

            string personality = testManager.GetPersonalityType(questions);

            Assert.Equal(Personality.ExtrovertOut, personality);
        }
    }
}
