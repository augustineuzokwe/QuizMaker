namespace QuizMaker
{
    public class GameResult
    {

        public static bool GameOver { get; set; }

        public enum Result
        {
            win,
            lost,
            correctAnswer,
            wrongAnswer
        }
    }
}
