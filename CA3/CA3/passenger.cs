using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

namespace CA3
{
    internal class Passenger
    {
        // Atributes
        private string _name;
        private string _surname;
        private string _arrivalDate;
        private string _sex;
        private string _age;
        private string _occupation;
        private string _country;
        private string _destination;
        private string _embarkationCode;
        private string _shipNumber;

        public int infantCounter;
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string ArrivalDate { get { return _arrivalDate; } set { _arrivalDate = value; } }
        public string Sex { get { return _sex; } set { _sex = value; } }
        public string Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value.Contains("Infant"))
                {
                    infantCounter++;
                    _age = value;
                }
                else
                {
                    _age = Regex.Replace(value, "[^0-9]", "");
                    if (_age == "")
                    {
                        _age = "unknown";
                    }
                    else if (_age[0] == '0')
                    {
                        _age = _age.Substring(1);
                    }
                }
            }
        }
        public string Occupation { get { return _occupation; } set { _occupation = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public string Destination { get { return _destination; } set { _destination = value; } }
        public string EmbarkationCode { get { return _embarkationCode; } set { _embarkationCode = value; } }
        public string ShipNumber { get { return _shipNumber; } set { _shipNumber = value; } }

        public Passenger()
        {

        }
        public Passenger(string name, string surname, string arrivalDate, string sex, string age, string occupation, string country, string destination, string embarkationCode, string shipNumber)
        {
            Name = name;
            Surname = surname;
            ArrivalDate = arrivalDate;
            Sex = sex;
            Age = age;
            Occupation = occupation;
            Country = country;
            Destination = destination;
            EmbarkationCode = embarkationCode;
            ShipNumber = shipNumber;
        }
        // Methods above are the main methods that are completing the tasks
        public static void ShipReport(Passenger[] passengers)
        {
            int shipCounter = 1;
            List<string> List = new List<string>();

            for (int i = 1; i < passengers.Length; i++)
            {
                if (!List.Contains(passengers[i].ShipNumber))
                {
                    List.Add(passengers[i].ShipNumber);
                }
            }

            WriteLine($"\t----All Ships----\n");
            foreach (string ship in List)
            {
                WriteLine($"{shipCounter}. {ship}");
                shipCounter++;
            }

            int choice = InputChecker(List); // Just checking the input
            WriteLine("\n\n");
            ShipReport_Addon( passengers, List,choice); // This is an addon to a a ShipReport Method just to make this method claner 
        }
        public static void OccupationReport(Passenger[] passengers)
        {
            Dictionary<string, int> occupationCounter = new Dictionary<string, int>();

            for (int i = 1; i < passengers.Length; i++)
            {
                if (!occupationCounter.ContainsKey(passengers[i].Occupation))
                {
                    occupationCounter.Add(passengers[i].Occupation, 1);
                }
                else
                {
                    occupationCounter[passengers[i].Occupation]++;
                }
            }

            WriteLine("\t----All Occupations----\n");
            int counter = 1;
            foreach (KeyValuePair<string, int> kvp in occupationCounter)
            {
                WriteLine($"{counter}. {kvp.Key} ({kvp.Value} occurrences)");
                counter++;
            }
        }
        public static void AgeReport(Passenger[] passengers)
        {
            WriteLine($"\t----All Ages----\n");

            int children = 0, teenagers = 0, youngAdults = 0, adults = 0, olderAdults = 0, unknown = 0, infants = 0;
            for (int i = 0; i < passengers.Length; i++)
            {
                if (int.TryParse(passengers[i].Age, out int age))
                {
                    if (age > 0 && age < 13)
                    {
                        children++;
                    }
                    else if (age >= 12 && age < 20)
                    {
                        teenagers++;
                    }
                    else if (age >= 20 && age < 30)
                    {
                        youngAdults++;
                    }
                    else if (age >= 30 && age < 50)
                    {
                        adults++;
                    }
                    else
                    {
                        olderAdults++;
                    }
                }
                else
                {
                    unknown++;
                }

                if (passengers[i].Age.Contains("Infant in months"))
                {
                    infants++;
                }
            }
            WriteLine("Infants(<1 year) : {0}", infants);
            WriteLine("Children(1-12) : {0}", children);
            WriteLine("Teenagers(13-19) : {0}", teenagers);
            WriteLine("Young adults(20-29) : {0}", youngAdults);
            WriteLine("Adults(30+ years) : {0}", adults);
            WriteLine("Older Adults(50+ years) : {0}", olderAdults);
            WriteLine("Unknown : {0}", unknown);
        }


        // Metods above helps to make code in main methods to look cleaner
        public static int InputChecker(List<string> list)
        {
            int choice = 0;
            bool choiceChecker = false;
            while (choiceChecker == false)
            {
                Write("Choose option(number) : ");
                string inputString = ReadLine();

                if (int.TryParse(inputString, out int number))
                {
                    choice = number;
                    if (choice >= 1 && choice <= list.Count)
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
        public static void ShipReport_Addon(Passenger[] passengers, List<string> ShipNames, int choice)
        {
            string leavingStation = " ";
            int stationCounter = 0;
            int allPasangers = 0;

            while (leavingStation != ShipNames[choice - 1])
            {
                leavingStation = passengers[stationCounter].ShipNumber;
                stationCounter++;
            }
            leavingStation = passengers[stationCounter].EmbarkationCode;
            string arrivalDate = passengers[stationCounter].ArrivalDate;

            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i].ShipNumber == ShipNames[choice - 1])
                {
                    allPasangers++;
                }
            }

            WriteLine($"{ShipNames[choice - 1]} : leaveing from {leavingStation} Arrived : {arrivalDate} with {allPasangers} pasangers");
            WriteLine("Pasanger list:\n");
            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i].ShipNumber == ShipNames[choice - 1])
                {
                    WriteLine(passengers[i].Surname + " " + passengers[i].Name);
                }
            }
        }
    }
}
