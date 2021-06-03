using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public class QuizCore
    {
        public static Dictionary<string, int> _questionAnsweredWrong = new Dictionary<string, int>();
        public static bool IsAllQuestionsAnswered { get; set; }
        private static readonly List<Answer> answers = new List<Answer>();

        public static Dictionary<string, int> QuestionWrongAnswersDictionary
        {
            get { return _questionAnsweredWrong; }
            set { _questionAnsweredWrong = value; }
        }

        public static bool IsCorrectAnswerGiven(QuizDataModel gameCard, string playerAnswer)
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

        public static void QuizCardPlay(QuizDataModel gameCard)
        {
            int wrongAnswersCount = 0;

            for (int x = 0; x < gameCard.Answers.Count; x++)
            {
                string answer = Console.ReadLine();

                if (IsCorrectAnswerGiven(gameCard, answer))
                {
                    QuizUI.GameRoundResult(QuizResult.Result.correctAnswer, 0, answer);
                    break;
                }
                else
                {
                    QuizUI.GameRoundResult(QuizResult.Result.wrongAnswer, 0, answer);
                    wrongAnswersCount++;
                }
            }

            // keep track of wrong answers
            QuestionWrongAnswersDictionary.Add(gameCard.Question, wrongAnswersCount);
        }

        public static QuizDataModel CreateGameCards(int answersForEachQuestion)
        {
            string question = QuizUI.getPlayerQuestion();

            for (int a = 0; a < answersForEachQuestion; a++)
            {
                string answer = QuizUI.getPlayerAnswerToQuestion();

                if (QuizUI.IsCorrectAnswerToQuestion())
                {
                    answers.Add(new Answer(answer, true));
                }
                else
                {
                    answers.Add(new Answer(answer, false));
                }
            }
            return new QuizDataModel(question, answers: answers);
        }
    }
}
