using System;
using System.Collections.Generic;

namespace QuizMaker
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string filePath = "quiz.xml";
            DataSerializer<Quiz> dataSerializer = new DataSerializer<Quiz>();
            List<Answer> answers = new List<Answer>();
            Quiz questionAndAnswers = new Quiz();
            string question = "";

            for (int x = 0; x < 1; x++)
            {
                Console.WriteLine($"Enter your questions:...{Environment.NewLine}");

                question = Console.ReadLine();

                for (int a = 0; a < 3; a++)
                {
                    Console.WriteLine($"Enter the answers to the questions:{Environment.NewLine}");

                    string answer = Console.ReadLine();

                    Console.WriteLine($"Is this the correct answer?{Environment.NewLine}");

                    if (Console.ReadLine().ToLower().Equals("yes"))
                    {
                        answers.Add(new Answer(answer, true));
                    }
                    else
                    {
                        answers.Add(new Answer(answer, false));
                    }
                }
                questionAndAnswers = new Quiz(question, answers);
            }

            dataSerializer.XmlSerialize(questionAndAnswers, filePath);

            Console.Clear();

            Console.Write(Environment.NewLine);

            questionAndAnswers = dataSerializer.XmlDeserialize(filePath);


            Console.WriteLine($"Enter the correct answer to the questions:{Environment.NewLine}" +
                $"{questionAndAnswers.Question} {Environment.NewLine}");

            for (int x = 0; x < questionAndAnswers.Answers.Count; x++)
            {
                Console.WriteLine($"Try again... {Environment.NewLine}");

                string answer = Console.ReadLine();

                foreach (var item in questionAndAnswers.Answers)
                {
                    if (item.QuizAnswer.Equals(answer) && item.IsCorrectanswer.Equals(true))
                    {
                        Console.WriteLine($"You have entered the correct answer: [ {item.QuizAnswer} ]");
                    }
                    else
                    {
                        Console.WriteLine($"[ {item.QuizAnswer} ] is a wrrong answer");
                    }
                }

            }
        }
    }
}
