// File:    Program.cs
// Purpose: A program for a multiple choice exam that creates, displays, edits, deletes, imports and exports questions as well as starts the exam and marks the exam


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_Advanced_Portfolio_mabdelaziz
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare variables
            int menuSelection;
            bool quitLoop = false;
            double correctAnswers;

            // declare lists
            List<MultipleChoiceQuestion> questionsList = new List<MultipleChoiceQuestion>();
            List<int> wrongAnswers = new List<int>();

            // display program header
            Console.WriteLine("Multiple Choice Exam");
            Console.WriteLine("--------------------");

            while (quitLoop == false)
            {
                // display menu
                InputOutput.DisplayMenu();

                // ask for menu choice
                menuSelection = InputOutput.GetMenuChoice();

                // enact the corresponding decision
                switch (menuSelection)
                {
                    case 1:
                        // create a question
                        Questions.Create(questionsList);
                        break;
                    case 2:
                        // display all the questions
                        InputOutput.DisplayQuestions(questionsList);
                        break;
                    case 3:
                        // edit a pre-existing question
                        Questions.Edit(questionsList);
                        break;
                    case 4:
                        // delete a question
                        Questions.Delete(questionsList);
                        break;
                    case 5:
                        // import questions from a file
                        Files.Import(questionsList);
                        break;
                    case 6:
                        // export questions to a file
                        Files.Export(questionsList);
                        break;
                    case 7:
                        // start the exam
                        Exam.Start(questionsList, wrongAnswers);
                        break;
                    case 8:
                        // mark the exam
                        correctAnswers = questionsList.Count - wrongAnswers.Count;
                        Exam.Mark(questionsList, wrongAnswers, correctAnswers);
                        break;
                    default:
                        // quit the program
                        quitLoop = true;
                        break;
                }

            }


        }
    }
}
