using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public class GameCore
    {
        public static Dictionary<string, int> _questionAnsweredWrong = new Dictionary<string, int>();
        public static bool IsAllQuestionsAnswered { get; set; }
        private static DataSerializer<List<Quiz>> dataSerializer = new DataSerializer<List<Quiz>>();
        private static int gameCardsInPlay = 3;
        private static List<Quiz> quizCards = new List<Quiz>();
        private static List<Answer> answers = new List<Answer>();


        public static Dictionary<string, int> QuestionAnsweredWrong
        {
            get { return _questionAnsweredWrong; }
            set { _questionAnsweredWrong = value; }
        }

        public static bool IsCorrectAnswerGiven(Quiz gameCard, string playerAnswer)
        {
            foreach (var item in gameCard.Answers)
            {
                if (item.QuizAnswer.ToLower().Equals(playerAnswer.ToLower()) && item.IsCorrectanswer)
                    return true;
                else
                    continue;
            }

            return false;
        }

        public static int QuizCardPlay(Quiz gameCard)
        {
            int wrongAnswers = 0;

            for (int x = 0; x < gameCard.Answers.Count; x++)
            {
                string answer = Console.ReadLine();

                if (IsCorrectAnswerGiven(gameCard, answer))
                {
                    GameUI.GameRoundResult(GameResult.Result.correctAnswer, 0, answer);
                    break;
                }
                else
                {
                    GameUI.GameRoundResult(GameResult.Result.wrongAnswer, 0, answer);
                    wrongAnswers++;
                }
            }
            return wrongAnswers;
        }

        public static Quiz CreateGameCards()
        {
                Console.WriteLine($"Enter your questions:...");

                string question = Console.ReadLine();

                for (int a = 0; a < gameCardsInPlay; a++)
                {
                    Console.WriteLine($"Enter the answers to the questions: ");

                    string answer = Console.ReadLine();

                    Console.WriteLine($"Is this the correct answer?");

                    if (Console.ReadLine().ToLower().Equals("yes"))
                    {
                        answers.Add(new Answer(answer, true));
                    }
                    else
                    {
                        answers.Add(new Answer(answer, false));
                    }
                }

            return new Quiz(question, answers: answers);
        }
    }
}
