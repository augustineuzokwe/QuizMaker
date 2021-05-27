using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace QuizMaker
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int counter = 0;
            string filePath = "quiz.xml";
            DataSerializer dataSerializer = new DataSerializer();
            Quiz quiz = new Quiz();

            while (counter < 2)
            {
                Console.WriteLine($"Enter your questions:...{Environment.NewLine}");

                quiz.Questions.Add(Console.ReadLine());

                Console.WriteLine($"Enter the answers to the questions:... Mark the correct answer with a (e.g. # answer){Environment.NewLine} ");

                for (int a = 0; a < 3; a++)
                {
                    quiz.Answers.Add(Console.ReadLine());
                }

                counter++;
            }

            Console.Clear();

            dataSerializer.XmlSerialize(typeof(Quiz), quiz, filePath);

            Console.Write(Environment.NewLine);

            quiz = dataSerializer.XmlDeserialize(typeof(Quiz), filePath) as Quiz;

            for (int q = 0; q < quiz.Questions.Count; q++)
            {
                Console.WriteLine($"Q: {quiz.Questions[q]}");

                for (int a = 0; a < quiz.Answers.Count; a++)
                {
                    Console.WriteLine($" A{a}: {quiz.Answers[a]}");
                }
            }
        }
    }
}
