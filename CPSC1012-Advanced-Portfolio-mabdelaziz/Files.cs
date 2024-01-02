// File:    Files.cs
// Purpose: All the methods dealing with external files

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CPSC1012_Advanced_Portfolio_mabdelaziz
{
    class Files
    {
        public static void Import(List<MultipleChoiceQuestion> questionsList)
        {
            // declare variables
            string lineOfText;
            string question;
            string choice1;
            string choice2;
            string choice3;
            string choice4;
            char correctChoice;
            string fileName;
            
            // display what option we are in
            Console.WriteLine("Multiple Choice Exam - Import Questions");
            Console.WriteLine("---------------------------------------");

            // ask for and capture file path
            Console.WriteLine("Enter the location of the file to read from:");
            fileName = Console.ReadLine();

            // reads a stream of text
            StreamReader reader = null;

            try
            {
                // create an instance of StreamReader which opens the file and reads a stream of text
                reader = new StreamReader(fileName);

                // clear current list
                questionsList.Clear();

                // read until there are no more records
                while ((lineOfText = reader.ReadLine()) != null || questionsList.Count == 30)
                {
                    // create a string array to hold a record
                    // SPLIT splits a record based on the character you say
                    string[] fileRecordArray = lineOfText.Split('|');

                    // populate the variables for one instance
                    question = fileRecordArray[0];
                    choice1 = fileRecordArray[1];
                    choice2 = fileRecordArray[2];
                    choice3 = fileRecordArray[3];
                    choice4 = fileRecordArray[4];
                    correctChoice = char.Parse(fileRecordArray[5].Trim().ToUpper());
                    
                    // create a new instance of Student and Add it to the List
                    questionsList.Add(new MultipleChoiceQuestion(question, choice1, choice2, choice3, choice4, correctChoice));

                    if (questionsList.Count == 30)
                    {
                        Console.WriteLine("You have reached the maximum of 30 allowable questions. ");
                    }
                }
            }
            // if file path is incorrect
            catch (Exception ex)
            {
                Console.WriteLine("{0} '{1}'.", ex.Message, fileName); ;
            }
            finally
            {
                if (reader != null)
                {
                    // close the file (can be open and closed many times)
                    reader.Close();
                    // release any connections to the file
                    reader.Dispose();
                }
            }
            Console.WriteLine("Added {0} questions.", questionsList.Count);
            Console.Write("Press any key to continue. ");
            Console.ReadKey();
        }

        public static void Export(List<MultipleChoiceQuestion> questionsList)
        {
            // declare variables
            string fileName;

            // display what option we are in
            Console.WriteLine("Multiple Choice Exam - Export Questions");
            Console.WriteLine("---------------------------------------");

            // ask for and capture file path
            Console.WriteLine("Enter the location of the file to save to:");
            fileName = Console.ReadLine();

            // create a variable of StreamWriter
            StreamWriter writer = null;
            try
            {
                // create an instance of StreamWriter
                writer = new StreamWriter(fileName, false);
                for (int index = 0; index < questionsList.Count; index++)
                {
                    // write to the file
                    writer.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}", 
                        questionsList[index].Question,
                        questionsList[index].Choice1,
                        questionsList[index].Choice2,
                        questionsList[index].Choice3,
                        questionsList[index].Choice4,
                        questionsList[index].CorrectChoice);
                }
            }
            // if file path is incorrect
            catch (Exception ex)
            {
                Console.WriteLine("{0} '{1}'.", ex.Message, fileName);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
            Console.Write("Press any key to continue. ");
            Console.ReadKey();
        }
    }
}
