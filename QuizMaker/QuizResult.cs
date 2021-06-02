namespace QuizMaker
{
    public class QuizResult
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
