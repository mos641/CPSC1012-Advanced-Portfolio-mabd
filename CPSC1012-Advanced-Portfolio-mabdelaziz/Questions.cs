// File:    Questions.cs
// Purpose: All the methods that deal with questions other than output (creating, editing, deleting)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_Advanced_Portfolio_mabdelaziz
{
    class Questions
    {
        public static void Create(List<MultipleChoiceQuestion> questionsList)
        {
            // declare variables
            string question;
            string choice1;
            string choice2;
            string choice3;
            string choice4;
            char correctChoice;

            // display what option we are in
            Console.WriteLine("Multiple Choice Exam - New Question");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("There are currently {0} questions in the exam. \n", questionsList.Count);

            if (questionsList.Count > 30)
            {
                Console.WriteLine("The exam is at the maximum of 30 questions");
            }
            else
            {
                // ask for and capture components
                Console.WriteLine("Enter the question:");
                question = Console.ReadLine();
                Console.WriteLine("Enter choice 1 for the question:");
                choice1 = Console.ReadLine();
                Console.WriteLine("Enter choice 2 for the question:");
                choice2 = Console.ReadLine();
                Console.WriteLine("Enter choice 3 for the question:");
                choice3 = Console.ReadLine();
                Console.WriteLine("Enter choice 4 for the question:");
                choice4 = Console.ReadLine();
                Console.WriteLine("Enter the correct choice (A, B, C, D):");
                correctChoice = InputOutput.GetQuestionChoice("Enter the correct choice (A, B, C, D):\n");

                // add components to new object in list
                questionsList.Add(new MultipleChoiceQuestion(question, choice1, choice2, choice3, choice4, correctChoice));
                Console.WriteLine("Successfully added question {0} to the exam.", questionsList.Count);
            }
            
            Console.Write("Press any key to continue. ");
            Console.ReadKey();
        }

        public static void Delete(List<MultipleChoiceQuestion> questionsList)
        {
            // declare variables
            int questionNumber;
            char confirmation;

            // display what option we are in
            Console.WriteLine("Multiple Choice Exam - Delete Question");
            Console.WriteLine("--------------------------------------");

            // ask for and capture question to delete
            Console.WriteLine("Enter the question number to delete:");
            questionNumber = int.Parse(Console.ReadLine());
            int index = questionNumber - 1;

            // check if question number is valid
            // if valid
            if (questionNumber <= questionsList.Count && questionNumber > 0)
            {
                Console.WriteLine("Found the following question:");

                // display question
                Console.WriteLine("Question {0}: ", questionNumber);
                Console.WriteLine("------------------------------");
                Console.WriteLine("{0} \n{1} \n{2} \n{3} \n{4} \n",
                    questionsList[index].Question,
                    questionsList[index].Choice1,
                    questionsList[index].Choice2,
                    questionsList[index].Choice3,
                    questionsList[index].Choice4);

                // ask for confirmation
                Console.WriteLine("Are you sure you want to delete question {0} (y/n)?", questionNumber);
                confirmation = char.Parse(Console.ReadLine());

                if (confirmation == 'y')
                {
                    // delete question
                    questionsList.RemoveAt(index);
                    Console.WriteLine("Successfully deleted question {0}", questionNumber);
                }
                else
                {
                    // tell them question was not deleted
                    Console.WriteLine("Question {0} was not deleted. ", questionNumber);
                }
            }
            // if not valid
            else
            {
                Console.WriteLine("Error! {0} is not a valid question number.", questionNumber);
            }

            Console.Write("Press any key to continue. ");
            Console.ReadKey();
        }

        public static void Edit(List<MultipleChoiceQuestion> questionsList)
        {
            // declare variables
            int questionNumber;
            string question;
            string choice1;
            string choice2;
            string choice3;
            string choice4;
            char correctChoice;

            // display what option we are in
            Console.WriteLine("Multiple Choice Exam - Edit Question");
            Console.WriteLine("------------------------------------");

            // ask for and capture question to delete
            Console.WriteLine("Enter the question number to Edit:");
            questionNumber = int.Parse(Console.ReadLine());
            int index = questionNumber - 1;

            // check if question number is valid
            // if valid
            if (questionNumber <= questionsList.Count && questionNumber > 0)
            {
                Console.WriteLine("The question is as follows:");

                // display question
                Console.WriteLine("Question {0}: ", questionNumber);
                Console.WriteLine("------------------------------");
                Console.WriteLine("{0} \nA. {1} \nB. {2} \nC. {3} \nD. {4} \n",
                    questionsList[index].Question,
                    questionsList[index].Choice1,
                    questionsList[index].Choice2,
                    questionsList[index].Choice3,
                    questionsList[index].Choice4);

                // ask for and capture components
                Console.WriteLine("Enter the question:");
                question = Console.ReadLine();
                Console.WriteLine("Enter choice 1 for the question:");
                choice1 = Console.ReadLine();
                Console.WriteLine("Enter choice 2 for the question:");
                choice2 = Console.ReadLine();
                Console.WriteLine("Enter choice 3 for the question:");
                choice3 = Console.ReadLine();
                Console.WriteLine("Enter choice 4 for the question:");
                choice4 = Console.ReadLine();
                Console.WriteLine("Enter the correct choice (A, B, C, D):");
                correctChoice = InputOutput.GetQuestionChoice("Enter the correct choice (A, B, C, D):\n");

                // replace list entry at index
                questionsList.RemoveAt(index);
                questionsList.Insert(index, new MultipleChoiceQuestion(question, choice1, choice2, choice3, choice4, correctChoice));

                Console.WriteLine("Successfully updated question {0}", questionNumber);
            }
            // if not valid
            else
            {
                Console.WriteLine("Error! {0} is not a valid question number.", questionNumber);
            }

            Console.Write("Press any key to continue. ");
            Console.ReadKey();

        }

    }
}
