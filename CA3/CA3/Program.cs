/* Name: CA3 
* Author: Anton Teleznikov
* Date Created : 03/04/23
* Purpose: 
* Modified By:     
*/
using static System.Console;
namespace CA3
{
    internal class Program
    {
        static void Main(string[] args)
        {


            


           




        }
        static int Menu()
        {
            string inputString;
            int choice = 0;
            bool choiceChecker = false;

            WriteLine("Main Menu\n");
            WriteLine("1. Ship Reports\n2. Occupation Report\n3. Age Report\n4. Exit"); 

            while (choiceChecker == false)
            {
                Write("Enter Choice: ");
                inputString = ReadLine();

                if (int.TryParse(inputString, out int number))
                {
                    choice = number;
                    if (choice >= 1 && choice <= 4)
                    {
                        choiceChecker = true;
                    }
                    else
                    {
                        WriteLine("You entered invalid number!");
                        choiceChecker = false;
                    }
                }
                else
                {
                    WriteLine("Enter a number!");
                    choiceChecker = false;
                }
            }
            return choice;
        }
    }
}