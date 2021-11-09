using System;
using System.Collections.Generic;

namespace Students_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> studentNames = new List<string>();
            string name = "";
            do
            {
                Console.WriteLine("Enter the name of students(For exit type no)");
                name = Console.ReadLine();
                if (name != "no")
                {
                    studentNames.Add(name);
                }
            } while (name != "no");

            List<int> scores = new List<int>();
            for (int i = 0; i < studentNames.Count; i++)
            {
                Console.WriteLine("Enter each student's score respectively");
                int score = Convert.ToInt32(Console.ReadLine());
                scores.Add(score);
            }

            int rejectStudentsNumber = 0;
            foreach (var score in scores)
            {
                if (score < 10)
                {
                    rejectStudentsNumber++;
                }
            }

            string[,] rejects = new string[rejectStudentsNumber, 2];
            int ctr = 0;
            for (int i = 0; i < scores.Count; i++)
            {
                if (scores[i] < 10)
                {
                    rejects[ctr, 0] = studentNames[i];
                    rejects[ctr, 1] = scores[i].ToString();
                    ctr++;
                }
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine("Names and scores of the rejected students:");
            for (int i = 0; i < rejectStudentsNumber; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(rejects[i, j] + "\t");
                }
                Console.Write(Environment.NewLine);
            }


            int passedStudentNumber = studentNames.Count - rejectStudentsNumber;
            string[,] passed = new string[passedStudentNumber, 2];
            List<int> scores2 = scores;
            List<string> studentNames2 = studentNames;
            for (int i = 0; i < passedStudentNumber; i++)
            {
                int max = scores2[0];
                foreach (var score in scores2)
                {
                    if (score > max)
                    {
                        max = score;
                    }
                }
                int index = scores2.FindIndex(i => i.Equals(max));
                passed[i, 0] = studentNames2[index];
                passed[i, 1] = max.ToString();
                scores2.Remove(max);
                studentNames2.Remove(studentNames2[index]);
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine("Names and scores of the passed students in order of the scores:");
            for (int i = 0; i < passedStudentNumber; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(passed[i, j] + "\t");
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
