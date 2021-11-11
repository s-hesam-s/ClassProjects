using System;
using System.Collections.Generic;
using System.Linq;

namespace Passanger
{
    class Program
    {
        static void Main(string[] args)
        {
            var PassangersList = GetPassangersList(4);

            Console.WriteLine($"\nDetails identity for the oldest person/people in passanger list:\n");
            Print(GetOldest(PassangersList));

            Console.WriteLine($"\nDetails identity for the oldest male person/people in passanger list:\n");
            Print(GetOldestMen(PassangersList));

            Console.WriteLine($"\nDetails identity for the oldest female person/people in passanger list:\n");
            Print(GetOldestWomen(PassangersList));
        }
        public static DateTime Check(string number)
        {
            DateTime result;
            while (!DateTime.TryParse(number, out result))
            {
                Console.WriteLine("Enter a valid date");
                number = Console.ReadLine();
            }
            return result;
        }
        public static List<Person> GetPassangersList(int numberOfPassangers)
        {
            List<Person> passangersList = new List<Person>();

            for (int i = 0; i < numberOfPassangers; i++)
            {
                Person person = new Person();
                Console.Write("Enter the name of the passanger: ");
                person.Name = Console.ReadLine().Trim().ToLower();
                Console.Write("Enter the lastname of the passanger: ");
                person.LastName = Console.ReadLine().Trim().ToLower();
                Console.Write("Enter the gender of the passanger: ");
                person.Gender = Console.ReadLine().Trim().ToLower();
                Console.Write("Enter the birthday of the passanger(month/day/year): ");
                person.BirthDay = Check(Console.ReadLine());
                passangersList.Add(person);
            }
            return passangersList;
        }
        public static List<Person> GetOldest(List<Person> passangersList)
        {
            TimeSpan oldest = DateTime.Today - passangersList[0].BirthDay;
            int person = 0;
            for (int i = 1; i < passangersList.Count; i++)
            {
                if ((DateTime.Today - passangersList[i].BirthDay) > oldest)
                {
                    oldest = DateTime.Today - passangersList[i].BirthDay;
                    person = i;
                }
            }
            List<Person> oldestList = passangersList.Where(
                i => i.BirthDay == passangersList[person].BirthDay).ToList();
            return oldestList;
        }
        public static List<Person> GetOldestMen(List<Person> passangersList)
        {
            var maleList = passangersList.Where(i => i.Gender == "male").ToList();
            TimeSpan oldestMale = DateTime.Today - maleList[0].BirthDay;
            int person = 0;
            for (int i = 1; i < maleList.Count; i++)
            {
                if ((DateTime.Today - maleList[i].BirthDay) > oldestMale)
                {
                    oldestMale = DateTime.Today - maleList[i].BirthDay;
                    person = i;
                }
            }
            List<Person> oldestMenList = maleList.Where(
                i => i.BirthDay == maleList[person].BirthDay).ToList();
            return oldestMenList;
        }
        public static List<Person> GetOldestWomen(List<Person> passangersList)
        {
            var femaleList = passangersList.Where(i => i.Gender == "female").ToList();
            TimeSpan oldestFemale = DateTime.Today - femaleList[0].BirthDay;
            int person = 0;
            for (int i = 1; i < femaleList.Count; i++)
            {
                if ((DateTime.Today - femaleList[i].BirthDay) > oldestFemale)
                {
                    oldestFemale = DateTime.Today - femaleList[i].BirthDay;
                    person = i;
                }
            }
            List<Person> oldestWomenList = femaleList.Where(
                i => i.BirthDay == femaleList[person].BirthDay).ToList();
            return oldestWomenList;
        }
        public static void Print(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"\nFirst Name:\t\t{person.Name}\nLast Name:\t\t{person.LastName}\n" +
               $"Gender:\t\t\t{person.Gender}\nBirthday:\t\t{person.BirthDay.ToShortDateString()}");
            }

        }
    }
    class Person
    {
        private string _name;
        private string _lastName;
        private string _gender;
        public DateTime BirthDay { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
            Start:
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Enter a name");
                    value = Console.ReadLine();
                    goto Start;
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetter(value[i]))
                    {
                        Console.WriteLine("Enter a valid name");
                        value = Console.ReadLine();
                        goto Start;
                    }
                }
                _name = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
            Start:
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Enter a name");
                    value = Console.ReadLine();
                    goto Start;
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetter(value[i]))
                    {
                        Console.WriteLine("Enter a valid name");
                        value = Console.ReadLine();
                        goto Start;
                    }
                }
                _lastName = value;
            }
        }
        public string Gender
        {
            get { return _gender; }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value.Trim().ToLower() != "male" && value.Trim().ToLower() != "female" &&
                        value.Trim().ToLower() != "other")
                    {
                        Console.WriteLine("Gender must be male or female or other");
                        value = Console.ReadLine();
                    }
                }
                _gender = value;
            }
        }
    }
}
