using System;

namespace Classroom
{
    class Program
    {
        static void Main(string[] args)
        {
            double average = TotalAverage(2, 2);
            Console.WriteLine();
            Console.WriteLine($"The total average is: {average}");
        }
        public static double Check()
        {
            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Enter a correct number");
            }
            return result;
        }
        public static string[,] GetNameAndScores(int numberOfLessons)
        {
            string[,] nameAndScr = new string[numberOfLessons + 1, 2];
            Classroom cl = new Classroom();
            Console.WriteLine("Enter your name");
            cl.Name = Console.ReadLine();
            nameAndScr[0, 0] = "Name";
            nameAndScr[0, 1] = cl.Name;
            for (var i = 1; i < numberOfLessons + 1; i++)
            {
                for (var j = 0; j < 1; j++)
                {
                    Console.WriteLine("Enter the name of lesson");
                    cl.Lesson = Console.ReadLine();
                    nameAndScr[i, 0] = cl.Lesson;
                    Console.WriteLine("Enter the score of lesson");
                    cl.Score = Check();
                    nameAndScr[i, 1] = cl.Score.ToString();
                }
            }
            return nameAndScr;
        }
        public static void Print(string[,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t\t");
                }
                Console.WriteLine();
            }
        }
        public static double Average(string[,] array)
        {
            double sum = 0;
            for (var i = 0; i < array.GetLength(0) - 1; i++)
            {
                sum += Convert.ToDouble(array[i + 1, 1]);
            }
            return sum / (array.GetLength(0) - 1);
        }
        public static double TotalAverage(int numberOfStudents, int numberOfLessons)
        {
            double sum = 0;
            for (var i = 0; i < numberOfStudents; i++)
            {
                string[,] array = GetNameAndScores(numberOfLessons);
                Print(array);
                double average = Average(array);
                Console.WriteLine($"The average is: {average}");
                sum += average;
            }
            return sum / numberOfStudents;
        }
    }
    class Classroom
    {
        public string Lesson { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
            StartName:
                for (var i = 0; i < value.Length; i++)
                {
                    while (!Char.IsLetter(value[i]))
                    {
                        Console.WriteLine("Enter alphabets not digits or simbols");
                        value = Console.ReadLine();
                        goto StartName;
                    }
                }
                _name = value;
            }
        }
        //private string _score;
        //public string Score
        //{
        //    get { return _score; }
        //    set
        //    {
        //        StartScore:
        //        for (var i = 0; i < value.Length; i++)
        //        {
        //            while (!Char.IsNumber(value[i]))
        //            {
        //                if (value[i] == '.')
        //                {
        //                    break;
        //                }
        //                Console.WriteLine("Enter a number not alphabets or simbols");
        //                value = Console.ReadLine();
        //                goto StartScore;
        //            }
        //        }
        //        int ctr = 0;
        //        foreach (var ch in value)
        //        {
        //            if (ch == '.')
        //            {
        //                ctr++;
        //            }
        //        }
        //        if (ctr > 1)
        //        {
        //            Console.WriteLine("Enter a valid number");
        //            value = Console.ReadLine();
        //            goto StartScore;
        //        }
        //        while (!(Convert.ToDouble(value) >= 0 && Convert.ToDouble(value) <= 20))
        //        {
        //            Console.WriteLine("Enter a number between 0 and 20");
        //            value = Console.ReadLine();
        //            goto StartScore;
        //        }
        //        _score = value;
        //    }
        //}
        double _score;
        public double Score
        {
            get { return _score; }
            set
            {
                while (value < 0 || value > 20)
                {
                    Console.WriteLine("Enter a number between 0 and 20");
                    value = Program.Check();
                }
                _score = value;
            }
        }
    }
}
