using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles the text input for Assessment 1
        string text = "";
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            Console.WriteLine("Please enter the text you wish to analyse. Use * to indicate the end of the text:");

            //Keep taking in lines
            while(true)
            {
                Console.Write(">> ");
                text += Console.ReadLine(); //Add every line to the text
                if(text.Contains("*")) break; //Stop when a line contains an *
                else text += "\n";
            }
            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput(string fileName)
        {
            text = File.ReadAllText(fileName);
            return text;
        }

    }
}
