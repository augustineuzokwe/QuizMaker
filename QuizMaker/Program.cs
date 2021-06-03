using System;
using System.Collections.Generic;

namespace QuizMaker
{
    class MainClass
    {
        public static void Main()
        {
            string filePath = "quiz.xml";
            int quizCardsToPlay = 2;
            int answersForEachQuestion = 3;
            DataSerializer<List<QuizDataModel>> dataSerializer = new DataSerializer<List<QuizDataModel>>();
            List<QuizDataModel> quizCards = new List<QuizDataModel>();
            int answeredQuestionCount = 0;

            //Create quiz cards
            for (int x = 0; x < quizCardsToPlay; x++)
            {
                quizCards.Add(QuizCore.CreateGameCards(answersForEachQuestion));
            }

            //Store in serialized xml file
            dataSerializer.XmlSerialize(quizCards, filePath);

            Console.Clear();

            // Load quiz cards
            List<QuizDataModel> questionAndAnswers = dataSerializer.XmlDeserialize(filePath);

            //Play quiz
            foreach (var gameCard in questionAndAnswers)
            {
                QuizUI.WelcomeToQuizGame(gameCard.Question);

                answeredQuestionCount++;

                //Play quiz
                QuizCore.QuizCardPlay(gameCard);

                if (answeredQuestionCount < questionAndAnswers.Count)
                {
                    QuizUI.NextQuizQuestion();
                }
            }

            //Display quiz results
            QuizUI.FinalGameResult(QuizCore.QuestionWrongAnswersDictionary);
        }
    }
}
