using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class WordCount
    {
        // Handles Word Counting
        // This is an additional class to the base code

        //Method: longWords
        //Arguments: string, integer
        //Returns: list of strings
        //Generates a list of words above a certain length
        public List<string> longWords(string input, int lengthCutoff) => 
            input.Split( //Split by all non letter characters
                input.ToList().FindAll(
                    c => !Analyse.ALPHABET.Contains(char.ToLower(c)) //Find all non letter characters
                ).ToArray() //The split function requires an array input
            ).ToList().FindAll(s => s.Length > lengthCutoff); //Take only words with a length greater than 7
    }
}
