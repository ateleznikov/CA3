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
        public string ArrivalDate { get { return _arrivalDate;  } set { _arrivalDate = value; } }
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
        public static void Hujnya(Passenger[] passengers)
        {
            WriteLine(passengers[1].Age);
        }
}
}
