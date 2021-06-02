using System;
using System.Collections.Generic;

namespace QuizMaker
{
    class MainClass
    {
        public static int gameTrialCount { get; private set; }

        public static void Main(string[] args)
        {
            string filePath = "quiz.xml";
            int gameCardsInPlay = 2;
            DataSerializer<List<QuizDataModel>> dataSerializer = new DataSerializer<List<QuizDataModel>>();
            List<QuizDataModel> quizCards = new List<QuizDataModel>();
            int answeredQuestionCount = 0;

            // create 3 game cards
            for (int x = 0; x < gameCardsInPlay; x++)
            {
                quizCards.Add(QuizCore.CreateGameCards());
            }

            //Store in serialized xml file
            dataSerializer.XmlSerialize(quizCards, filePath);

            Console.Clear();

            // load game cards
            List<QuizDataModel> questionAndAnswers = dataSerializer.XmlDeserialize(filePath);

            //Play game
            foreach (var gameCard in questionAndAnswers)
            {
                QuizUI.WelcomeToQuizGame(gameCard.Question);

                answeredQuestionCount++;

                QuizCore.QuestionAnsweredWrong.Add(gameCard.Question, QuizCore.QuizCardPlay(gameCard));

                if (answeredQuestionCount < questionAndAnswers.Count)
                {
                    QuizUI.NextQuizQuestion();
                }
            }

            QuizUI.FinalGameResult(QuizCore.QuestionAnsweredWrong);
        }
    }
}
