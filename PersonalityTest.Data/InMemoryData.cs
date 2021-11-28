using Microsoft.EntityFrameworkCore;
using PersonalityTest.Data.Models;

namespace PersonalityTest.Data
{
    public static class InMemoryData
    {
        private static bool isSet = false;
        static public void GetData(PersonalityTestContext context)
        {
            if(isSet) return;
            AddDataToContext(context);
            context.SaveChanges();
            isSet = true;
        }

        private static void AddDataToContext(PersonalityTestContext context)
        {
            List<Question> questions = GetQuestions();
            List<Option> options = GetOptions(questions);

            foreach (var option in options)
            {
                context.Options.Add(option);

            }
            foreach (var question in questions)
            {
                question.Options = options.FindAll(x => x.QuestionId == question.ID);
                context.Questions.Add(question);
            }
        }

        private static List<Question> GetQuestions()
        {
            return new()
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

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "You’re having an animated discussion with a colleague regarding a project that you’re in charge of. You:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "You are taking part in a guided tour of a museum. You:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "During dinner parties at your home, you have a hard time with people who:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "You crack a joke at work, but nobody seems to have noticed. You:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "This morning, your agenda seems to be free. You:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "During dinner, the discussion moves to a subject about which you know nothing at all. You:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "You’re out with a group of friends and there’s a person who’s quite shy and doesn’t talk much. You:",
                    Value = 0

                },
                new Question
                {
                    ID = Guid.NewGuid(),
                    Text = "At work, somebody asks for your help for the hundredth time. You:",
                    Value = 0

                }
            };
        }

        private static List<Option> GetOptions(List<Question> questions)
        {
            return new()
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
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[2].ID,
                    Text = "Don’t dare contradict them",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[2].ID,
                    Text = "Think that they are obviously right",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[2].ID,
                    Text = "Defend your own point of view, tooth and nail",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[2].ID,
                    Text = "Continuously interrupt your colleague",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[3].ID,
                    Text = "Are a bit too far towards the back so don’t really hear what the guide is saying",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[3].ID,
                    Text = "Follow the group without question",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[3].ID,
                    Text = "Make sure that everyone is able to hear properly",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[3].ID,
                    Text = "Are right up the front, adding your own comments in a loud voice",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[4].ID,
                    Text = "Ask you to tell a story in front of everyone else",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[4].ID,
                    Text = "Talk privately between themselves",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[4].ID,
                    Text = "Hang around you all evening",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[4].ID,
                    Text = "Always drag the conversation back to themselves",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[5].ID,
                    Text = "Think it’s for the best — it was a lame joke anyway",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[5].ID,
                    Text = "Wait to share it with your friends after work",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[5].ID,
                    Text = "Try again a bit later with one of your colleagues",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[5].ID,
                    Text = "Keep telling it until they pay attention",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[6].ID,
                    Text = "Know that somebody will find a reason to come and bother you",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[6].ID,
                    Text = "Heave a sigh of relief and look forward to a day without stress",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[6].ID,
                    Text = "Question your colleagues about a project that’s been worrying you",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[6].ID,
                    Text = "Pick up the phone and start filling up your agenda with meetings",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[7].ID,
                    Text = "Don’t dare show that you don’t know anything about the subject",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[7].ID,
                    Text = "Barely follow the discussion",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[7].ID,
                    Text = "Ask lots of questions to learn more about it",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[7].ID,
                    Text = "Change the subject of discussion",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[8].ID,
                    Text = "Notice that they’re alone, but don’t go over to talk with them",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[8].ID,
                    Text = "Go and have a chat with them",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[8].ID,
                    Text = "Shoot some friendly smiles in their direction",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[8].ID,
                    Text = "Hardly notice them at all",
                    Value = 4
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[9].ID,
                    Text = "Give them a hand, as usual",
                    Value = 1
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[9].ID,
                    Text = "Accept — you’re known for being helpful",
                    Value = 2
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[9].ID,
                    Text = "Ask them, please, to find somebody else for a change",
                    Value = 3
                },
                new Option
                {
                    Id = Guid.NewGuid(),
                    QuestionId = questions[9].ID,
                    Text = "Loudly make it known that you’re annoyed",
                    Value = 4
                }
            };
        }
    }
}
