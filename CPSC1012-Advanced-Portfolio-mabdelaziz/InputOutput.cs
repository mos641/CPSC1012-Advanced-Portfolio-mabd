// File:    InputOutput.cs
// Purpose: All the methods dealing with user input and functions that require only displaying information (nothing with a mixture of the two)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_Advanced_Portfolio_mabdelaziz
{
    class InputOutput
    {
        public static void DisplayMenu()
        {
            // declare variables
            // set menu choices here to easily change if need be
            string menuHeader       = "Please enter:";
            string menuOptionOne    = "1 - to create a new question,";
            string menuOptionTwo    = "2 - to display all questions,";
            string menuOptionThree  = "3 - to edit a question,";
            string menuOptionFour   = "4 - to delete a question,";
            string menuOptionFive   = "5 - to import qestions from a file,";
            string menuOptionSix    = "6 - to export questions to a file,";
            string menuOptionSeven  = "7 - to start the exam,";
            string menuOptionEight  = "8 - to mark the exam,";
            string menuOptionZero   = "0 - to exit the program.";

            // place an empty line before
            Console.WriteLine("");
            // display menu
            Console.WriteLine("{0}", menuHeader);
            Console.WriteLine("         {0}", menuOptionOne);
            Console.WriteLine("         {0}", menuOptionTwo);
            Console.WriteLine("         {0}", menuOptionThree);
            Console.WriteLine("         {0}", menuOptionFour);
            Console.WriteLine("         {0}", menuOptionFive);
            Console.WriteLine("         {0}", menuOptionSix);
            Console.WriteLine("         {0}", menuOptionSeven);
            Console.WriteLine("         {0}", menuOptionEight);
            Console.WriteLine("         {0}", menuOptionZero);
            // place an empty line afterwards
            Console.WriteLine("");
        }

        public static int GetMenuChoice()
        {
            // declare variables
            int intValue;
            bool inputIsValid = false;
            string inputQuestion = "Option? ";
            string errorMessage = "*** Invalid menu choice.";

            // loop to determine whether char is valid menu choice
            do
            {
                // ask for and capture an char value
                Console.Write(inputQuestion);

                // loop to determine whether the input is a character
                while (!int.TryParse(Console.ReadLine().Trim(), out intValue))
                {
                    Console.WriteLine(errorMessage);
                    Console.Write(inputQuestion);
                }
                if (intValue != 1 && intValue != 2 && intValue != 3 && intValue != 4 && intValue != 5 &&
                    intValue != 6 && intValue != 7 && intValue != 8 && intValue != 0)
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    inputIsValid = true;
                }
            } while (inputIsValid == false);

            return intValue;
        }

        public static char GetQuestionChoice(string inputQuestion)
        {
            // declare variables
            char charValue;
            bool inputIsValid = false;
            string errorMessage = "*** Invalid answer";

            // loop to determine whether char is valid menu choice
            do
            {
                // loop to determine whether the input is a character
                while (!char.TryParse(Console.ReadLine().Trim().ToUpper(), out charValue))
                {
                    Console.WriteLine(errorMessage);
                    Console.Write(inputQuestion);
                }
                if (!charValue.Equals('A') && !charValue.Equals('B') && !charValue.Equals('C') && !charValue.Equals('D'))
                {
                    Console.WriteLine(errorMessage);
                    Console.Write(inputQuestion);
                }
                else
                {
                    inputIsValid = true;
                }
            } while (inputIsValid == false);

            return charValue;
        }


        public static void DisplayQuestions(List<MultipleChoiceQuestion> questionsList)
        {
            // write that we are displaying all the questions
            Console.WriteLine("Multiple Choice Exam - Display All Questions");
            Console.WriteLine("--------------------------------------------");

            // loop to display all question properties at each index of array
            for (int index = 0; index < questionsList.Count; index++)
            {
                Console.WriteLine("Question {0}: ", index + 1);
                Console.WriteLine("------------------------------");
                Console.WriteLine("{0} \nA. {1} \nB. {2} \nC. {3} \nD. {4} \n",
                questionsList[index].Question,
                questionsList[index].Choice1,
                questionsList[index].Choice2,
                questionsList[index].Choice3,
                questionsList[index].Choice4);
            }

            Console.Write("Press any key to continue. ");
            Console.ReadKey();
        }
    }
}
