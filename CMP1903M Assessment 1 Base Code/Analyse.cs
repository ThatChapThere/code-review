using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        //Handles the analysis of text

        //These static variables improve readability since we're using a list and not a dictionary
        public static int VOWELS = 1, CONSONANTS = 2;

        //The alphabet will be useful for letter frequencies
        public static string ALPHABET = "abcdefghijklmonopqrstuvwxyz";
        
        //List of sets of characters for each analysis point
        //The character sets for analysis are encapsulated within this class as they are not needed elsewhere
        private List<string> characterSets = new List<string>()
        {
            ".!?", 
            "aeiou",
            "bcdfghjklmnpqrstvwxyz"
        };

        //Method: Analyse (intitaliser)
        //Generates character sets
        public Analyse(){
            characterSets.Add(ALPHABET.ToUpper()); //Capital letters
            characterSets.Add(ALPHABET); //Lowercase letters
            characterSets[VOWELS] += characterSets[VOWELS].ToUpper(); //Vowels
            characterSets[CONSONANTS] += characterSets[CONSONANTS].ToUpper(); //Consonants

            foreach(char letter in ALPHABET) //Add a separate character set for every letter
                characterSets.Add(letter.ToString() + letter.ToString().ToUpper()); //Which is both the lower and uppercase version of that letter
        }
        
        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string input)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();

            //Initialise all the values in the list to '0'
            for(int i = 0; i < characterSets.Count; i++) values.Add(0);

            foreach(char character in input){ //Loop through every character in the string
                if(character == '*') break; //End of text to analysis is indicated by *
                for(int i = 0; i < characterSets.Count; i++) //Test each character against the character sets
                    if(characterSets[i].Contains(character)) values[i]++;
            }

            return values;
        }
    }
}
