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
                string question = QuizUI.getPlayerQuestion();
                List<Answer> answers = new List<Answer>();

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
                quizCards.Add(new QuizDataModel(question, answers));
            }

            //Store the quiz cards in serialized xml file
            dataSerializer.XmlSerialize(quizCards, filePath);

            Console.Clear();

            // Load quiz cards
            List<QuizDataModel> questionAndAnswers = dataSerializer.XmlDeserialize(filePath);

            //Play quiz
            foreach (var gameCard in questionAndAnswers)
            {
                answeredQuestionCount++;
                int wrongAnswersCount = 0;

                string answer = QuizUI.EnterAnswerToQuizGame(gameCard);

                for (int x = 0; x < gameCard.Answers.Count; x++)
                {

                    //Play quiz
                    var answerResult = QuizCore.QuizCardPlay(gameCard, answer);

                    if (answerResult != QuizResult.Result.correctAnswer)
                    {
                        wrongAnswersCount++;

                        if (!wrongAnswersCount.Equals(gameCard.Answers.Count))
                        {
                            QuizUI.GameRoundResult(answerResult, 0, answer);
                            answer = QuizUI.TryAgain();
                        }

                        continue;
                    }
                    else
                    {
                        if (answerResult.Equals(QuizResult.Result.correctAnswer))
                        {
                            QuizUI.GameRoundResult(answerResult, 0, answer);
                            break;
                        }
                    }
                }

                // keep track of wrong answers
                QuizDataModel.QuestionWrongAnswersDictionary.Add(gameCard.Question, wrongAnswersCount);

                if (answeredQuestionCount < questionAndAnswers.Count)
                {
                    QuizUI.NextQuizQuestion();
                }
            }

            //Display quiz results
            QuizUI.FinalGameResult(QuizDataModel.QuestionWrongAnswersDictionary);
        }
    }
}
