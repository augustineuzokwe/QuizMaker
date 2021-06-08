using static QuizMaker.QuizResult;

namespace QuizMaker
{
    public class QuizCore
    {
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

        public static Result QuizCardPlay(QuizDataModel gameCard, string answer)
        {
            if (IsCorrectAnswerGiven(gameCard, answer))
            {
                return Result.correctAnswer;
            }
            return Result.wrongAnswer;
        }
    }
}
