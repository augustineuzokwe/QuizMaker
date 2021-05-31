using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public class GameUI
    {
        public static void WelcomeToQuizGame(string question)
        {
            Console.WriteLine($"Enter the correct answer to the questions \n\n {question}");
        }

        public static void NextQuizQuestion()
        {
            Console.WriteLine($"\n\n==== Moving to next question ====== \n\n ");
        }

        public static void GameRoundResult(GameResult.Result result, int errorCount = 0, string playerInput = "")
        {
            switch (result)
            {
                case GameResult.Result.win:
                    Console.WriteLine($"  YOU'VE WON THE GAME with Error Count: {errorCount}");
                    break;
                case GameResult.Result.lost:
                    Console.WriteLine($"YOU LOST THE GAME with Error Count: { errorCount }");
                    break;
                case GameResult.Result.correctAnswer:
                    Console.WriteLine($"Your answer [ { playerInput } ] is correct. ");
                    break;
                case GameResult.Result.wrongAnswer:
                    Console.WriteLine($"Your answer [ { playerInput } ] is wrong, try again.. ");
                    break;
            }
        }

        public static void FinalGameResult(Dictionary<string, int> questionsAnsweredWrong)
        {
            Console.WriteLine($"\n\nHere are the game results:\n\n ");
            foreach (var item in questionsAnsweredWrong)
            {
                Console.WriteLine($"You have [ {item.Value} ] wrong answer(s) to the queston  \" {item.Key} \" ");
            }
        }
    }
}
