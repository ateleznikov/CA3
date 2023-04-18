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
            bool runner = true;

            // Adding info to class
            Passenger passenger = new Passenger();
            string[,] passengerData = AddInfo();
            Passenger[] passengers = new Passenger[passengerData.GetLength(0)];
            for (int i = 0; i < passengerData.GetLength(0); i++)
            {
                Passenger psngr = new Passenger();
                {
                    psngr.Name = passengerData[i, 0];
                    psngr.Surname = passengerData[i, 1];
                    psngr.Age = passengerData[i, 2];
                    psngr.Sex = passengerData[i, 3];
                    psngr.Occupation = passengerData[i, 4];
                    psngr.Country = passengerData[i, 5];
                    psngr.Destination = passengerData[i, 6];
                    psngr.EmbarkationCode = passengerData[i, 7];
                    psngr.ShipNumber = passengerData[i, 8];
                    psngr.ArrivalDate = passengerData[i, 9];
                }
                passengers[i] = psngr;
            }

            while (runner == true)
            {
                int choice = Menu();
                switch (choice)
                {
                    case 1: 
                        Passenger.ShipReport(passengers);
                        break;
                    case 2:
                        Passenger.OccupationReport(passengers);
                        break;
                    case 3:
                        Passenger.AgeReport(passengers);
                        break;
                    case 4:
                        runner = false;
                        break;
                    default:
                        WriteLine("Enter correct number!");
                        break;
                }
            }
        }
        static int Menu()
        {
            string inputString;
            int choice = 0;
            bool choiceChecker = false;

            WriteLine("\nMain Menu\n");
            WriteLine("1. Ship Reports\n2. Occupation Report\n3. Age Report\n4. Exit"); 

            while (choiceChecker == false)
            {
                Write("Enter Choice: ");
                inputString = ReadLine();
                WriteLine();
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
        static string[,] AddInfo()
        {
            string path = @"../../../faminefile.csv";
            int lineCount = File.ReadLines(path).Count();
            string[,] passengerData = new string[lineCount, 10];
            string? line;
            int i = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    if (values.Length != 10)
                    {
                        WriteLine($"the line number {i + 1} does not contain 10 variables");
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j < passengerData.GetLength(1); j++)
                        {
                            passengerData[i, j] = values[j];
                        }
                        i++;
                    }
                }
            }
            return passengerData;
        }

    }
}