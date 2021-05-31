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
            int gameCardsInPlay = 3;
            DataSerializer<List<Quiz>> dataSerializer = new DataSerializer<List<Quiz>>();
            List<Quiz> quizCards = new List<Quiz>();
            int answeredQuestionCount = 0;

            // create 3 game cards
            for (int x = 0; x < gameCardsInPlay; x++)
            {
                quizCards.Add(GameCore.CreateGameCards());
            }

            //Store in serialized xml file
            dataSerializer.XmlSerialize(quizCards, filePath);

            Console.Clear();

            // load game cards
            List<Quiz> questionAndAnswers = dataSerializer.XmlDeserialize(filePath);

            //Play game
            foreach (var gameCard in questionAndAnswers)
            {
                GameUI.WelcomeToQuizGame(gameCard.Question);

                answeredQuestionCount++;

                GameCore.QuestionAnsweredWrong.Add(gameCard.Question, GameCore.QuizCardPlay(gameCard));

                if (answeredQuestionCount < questionAndAnswers.Count)
                {
                    GameUI.NextQuizQuestion();
                }
            }

            GameUI.FinalGameResult(GameCore.QuestionAnsweredWrong);
        }
    }
}
