// File:    Exam.cs
// Purpose: All the methods that deal with the exam as a whole (starting, marking)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_Advanced_Portfolio_mabdelaziz
{
    class Exam
    {
        public static void Start(List<MultipleChoiceQuestion> questionsList, List<int> wrongAnswers)
        {
            // declare variables
            char userInput;

            // clear the wrong Answers array
            wrongAnswers.Clear();

            // show what option we are in
            Console.WriteLine("Multiple Choice Exam");
            Console.WriteLine("--------------------\n");

            // display all the questions
            for (int index = 0; index < questionsList.Count; index++)
            {
                int questionNumber = index + 1;
                Console.WriteLine("Question {0}: ", questionNumber);
                Console.WriteLine("------------------------------");
                Console.WriteLine("{0} \nA. {1} \nB. {2} \nC. {3} \nD. {4} \n",
                questionsList[index].Question,
                questionsList[index].Choice1,
                questionsList[index].Choice2,
                questionsList[index].Choice3,
                questionsList[index].Choice4);
                Console.Write("Your Answer (A,B,C,D): ");

                // take in the user input
                userInput = InputOutput.GetQuestionChoice("Your Answer (A,B,C,D): ");
                Console.WriteLine("");

                // compare the input with the correct answer and act accordingly
                if (userInput != questionsList[index].CorrectChoice)
                {
                    wrongAnswers.Add(questionNumber);
                }
            }

            Console.Write("Press any key to continue. ");
            Console.ReadKey();
        }

        public static void Mark(List<MultipleChoiceQuestion> questionsList, List<int> wrongAnswers, double correctAnswers)
        {
            // declare variables
            double percent;

            // decide whether they failed or passed
            percent = (correctAnswers / questionsList.Count);
            if (percent >= .83)
            {
                // if passed
                Console.WriteLine("You got {0:P2}. You got {1} questions correct out of {2}.", percent, correctAnswers, questionsList.Count);
                Console.WriteLine("You passed the exam.");
            }
            else
            {
                // if failed
                Console.WriteLine("You got {0:P2}. You got {1} questions correct out of {2}.", percent, correctAnswers, questionsList.Count);
                Console.WriteLine("You failed the exam.");
                Console.WriteLine("The following questions were answered incorrectly: ");
                // display the questions that they got wrong
                for (int index = 0; index < wrongAnswers.Count; index++)
                {
                    if (index == wrongAnswers.Count - 1)
                    {
                        Console.WriteLine("{0} ", wrongAnswers[index]);
                    }
                    else
                    {
                        Console.Write("{0} ", wrongAnswers[index]);
                    }
                }
            }
            Console.Write("Press any key to continue. ");
            Console.ReadKey();
        }
    }
}
