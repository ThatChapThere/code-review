//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Create 'Input' object
            var input = new Input();

            //Create an 'Analyse' object
            var analyse = new Analyse();


            //Get either manually entered text, or text from a file
            string text = "";
            if(getUserChoice("1. Do you want to enter the text via the keyboard?")) //User input
            {
                text = input.manualTextInput();
            }
            //File input (This is a while loop in case the filename is mistyped)
            else while(getUserChoice("2. Do you want to read in the text from a file?"))
            {
                try
                {
                    //Get a file path to open from the user
                    Console.Write("Enter the path of the file you would like to open: ");
                    text = input.fileTextInput(Console.ReadLine());

                    //Make a WordCount Object to count the long words
                    var wordCount = new WordCount();

                    //Write all of the long words to a file
                    File.WriteAllText
                    (
                        "long words.txt",
                        string.Join("\n", wordCount.longWords(text, 7))
                    );
                    break;
                }
                catch(FileNotFoundException) //Handle invalid file names
                {
                    Console.WriteLine("Sorry, that file does not exist on the disk.");
                }catch(UnauthorizedAccessException){ //Handle when a directory path is entered
                    Console.WriteLine("Sorry, you do not have permission to write to that path.");
                }
            }

            Console.WriteLine();

            //Pass the text input to the 'analyseText' method
            //Receive a list of integers back

            //This is an example of data abstraction, since at this point in the code the implementation does not matter
            //As long as we recieve a list of integers which reflect a correct analysis
            parameters = analyse.analyseText(text);

            //Report the results of the analysis
            var report = new Report();
            report.outputConsole(parameters);

            //Allow the user to write the results of the analysis to a file
            //This implements the suggestion to add more methods to the Report class
            if(getUserChoice("Would you like to output the results to a file?")){
                while(true){ //Keep going until a valid path is entered
                    try{
                        //Get a file path from the user
                        Console.Write("Please enter the path to write to: ");
                        //Write the report to this file path
                        report.outputFile(parameters, Console.ReadLine());
                        break;
                    }catch(IOException){ //Handle invalid file names
                        Console.WriteLine("Sorry, that is not a valid file name.");
                    }catch(UnauthorizedAccessException){ //Handle when directory paths are entered
                        Console.WriteLine("Sorry, you do not have permission to write to that path.");
                    }
                }
            }

            Console.ReadKey();
        }

        //Method: getUserChoice
        //Arguments: string (the prompt displayed to the user)
        //Returns: boolean
        //Gets a yes or no answer from the user
        static bool getUserChoice(string prompt){
            char userChoice = ' ';
            do
            {
                Console.Write($"{prompt} [Y/N] ");
                userChoice = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            }
            while(!"YN".Contains(userChoice));
            Console.WriteLine();

            return userChoice == 'Y';
        }
    }
}
