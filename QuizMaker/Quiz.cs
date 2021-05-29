using System;
using System.Collections.Generic;

namespace QuizMaker
{
    [Serializable]
    public class Quiz
    {
        private string _question;
        private List<Answer> _answers;

        public Quiz() { }

        public Quiz(string question, List<Answer> answers)
        {
            _question = question;
            _answers = answers;
        }

        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }
    }

    [Serializable]
    public class Answer
    {
        private string _answer;
        private bool _isCorrectanswer;

        public Answer() { }

        public Answer(string answer, bool isCorrectanswer)
        {
            QuizAnswer = answer;
            _isCorrectanswer = isCorrectanswer;
        }

        public string QuizAnswer
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public bool IsCorrectanswer
        {
            get { return _isCorrectanswer; }
            set { _isCorrectanswer = value; }
        }
    }
}