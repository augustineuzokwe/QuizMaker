using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuizMaker
{
    [Serializable]
    public class Quiz
    {
        private List<string> _questions = new List<string>();

        public List<string> Questions
        {
            get => _questions;
            set
            {
                if (value != null)
                    _questions = value;
            }
        }

        private List<string> _answers = new List<string>();

        public List<string> Answers
        {
            get => _answers;
            set
            {
                if (value != null)
                    _answers = value;
            }
        }
    }
}
