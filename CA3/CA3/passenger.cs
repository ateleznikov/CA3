using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CA3
{
    internal class Passenger
    {
        // Atributes
        private string _name;
        private string _surname;
        private DateOnly _arrivalDate;
        private string _sex;
        private int _age;
        private string _occupation;
        private string _country;
        private string _destination;
        private string _embarkationCode;
        private string _shipNumber;

        public static string path;
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public DateOnly ArrivalDate { get { return _arrivalDate;  } set { _arrivalDate = value; } }
        public string Sex { get { return _sex; } set { _sex = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public string Occupation { get { return _occupation; } set { _occupation = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public string Destination { get { return _destination; } set { _destination = value; } }
        public string EmbarkationCode { get { return _embarkationCode; } set { _embarkationCode = value; } }
        public string ShipNumber { get { return _shipNumber; } set { _shipNumber = value; } }

        public Passenger() 
        {
            string path = @"../../../faminefile.csv";
        }

        static void AddInfo()
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
                        throw new FormatException("Length is not equal to 10");
                    }
                    for (int j = 0; j < passengerData.GetLength(1); j++)
                    {
                        passengerData[i, j] = values[j];
                    }
                    i++;
                }

            }
        }
    }
}
