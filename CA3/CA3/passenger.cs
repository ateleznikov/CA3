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
        public static void ShipReport(Passenger[] passengers)
        {
            int choice = 0;
            bool choiceChecker = false;
            int shipCounter = 1;
            List<string> ShipNames = new List<string>();

            for (int i = 1; i < passengers.Length; i++)
            {
                if (!ShipNames.Contains(passengers[i].ShipNumber))
                {
                    ShipNames.Add(passengers[i].ShipNumber);
                }
            }

            WriteLine($"\t----All Ships----\n");
            foreach (string ship in ShipNames)
            {
                WriteLine($"{shipCounter}. {ship}");
                shipCounter++;
            }

            while (choiceChecker == false)
            {
                Write("Choose the ship(number) : ");
                string inputString = ReadLine();

                if (int.TryParse(inputString, out int number))
                {
                    choice = number;
                    if (choice >= 1 && choice <= ShipNames.Count)
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
            WriteLine("\n\n");
            // Raspihatj po metodam !!!!!!!!!!!!!!!!!
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
            // Dopisatj imena!!!!!!!!!!
        }
    }
}
