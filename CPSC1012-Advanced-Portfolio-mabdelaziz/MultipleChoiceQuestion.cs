// File:    MultipleChoiceQuestion.cs
// Purpose: The class for the object MultipleChoiceQuestion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_Advanced_Portfolio_mabdelaziz
{
    class MultipleChoiceQuestion
    {
        // Fields
        private string _question;
        private string _choice1;
        private string _choice2;
        private string _choice3;
        private string _choice4;
        private char _correctChoice;

        // Properties
        public string Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
            }
        }
        public string Choice1
        {
            get
            {
                return _choice1;
            }
            set
            {
                _choice1 = value;
            }
        }
        public string Choice2
        {
            get
            {
                return _choice2;
            }
            set
            {
                _choice2 = value;
            }
        }
        public string Choice3
        {
            get
            {
                return _choice3;
            }
            set
            {
                _choice3 = value;
            }
        }
        public string Choice4
        {
            get
            {
                return _choice4;
            }
            set
            {
                _choice4 = value;
            }
        }
        public char CorrectChoice
        {
            get
            {
                return _correctChoice;
            }
            set
            {
                if (value != 'A' && value != 'B' && value != 'C' && value != 'D')
                {
                    throw new Exception("The correct choice for all questions must be A, B, C, or D. Check and fix file ");
                }
                else
                {
                    _correctChoice = value;
                }
            }
        }

        // Constructor(s)
        // default constructor
        public MultipleChoiceQuestion()
        {
            Question        = "Question?";
            Choice1         = "Answer A";
            Choice2         = "Answer B";
            Choice3         = "Answer C";
            Choice4         = "Answer D";
            CorrectChoice   = 'A';
        }

        // non-default constructor
        public MultipleChoiceQuestion(string question, string choice1, string choice2, string choice3, string choice4, char correctChoice)
        {
            Question       = question;
            Choice1        = choice1;
            Choice2        = choice2;
            Choice3        = choice3;
            Choice4        = choice4;
            CorrectChoice  = correctChoice;
        }
        // Methods
    }
}
