using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {
        //Handles the reporting of the analysis

        //The names of the different report types
        private static List<string> reportNames = new List<string>()
        {
            "sentences",
            "vowels",
            "consonants",
            "upper case letters",
            "lower case letters"
        };

        //Method: outputConsole
        //Arguments: list of integers
        //Displays the analysis of the text to the console
        public void outputConsole(List<int> values)
        {
            Console.WriteLine(generateOutput(values));
        }

        //Method: outputFile
        //Arguments: list of integers, string (output file path)
        //Prints the analysis of the text to a file
        public void outputFile(List<int> values, string path)
        {
            File.WriteAllText(path, generateOutput(values));
        }

        //Method: generateOutput
        //Arguments: list of integers
        //Returns: string
        //Generates a human readable analysis

        //The process of actually generating the string is encapsulated within this class
        //Since other classes only need to write the analysis to the console or a file
        //And do not need to know the analysis string
        private string generateOutput(List<int> values){
            string output = "";
            
            int i = 0;
            for(; i < reportNames.Count; i++)
                output += $"number of {reportNames[i]} = {values[i]}\n";
            
            output += "\nLetter frequencies:";

            for(; i < values.Count; i++)
                output += $"\n{Analyse.ALPHABET[i - reportNames.Count]}: {values[i]}";
            return output;
        }
    }
}
