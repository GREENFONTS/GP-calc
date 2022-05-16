using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int coursesCount = 0;
            List<string> courses = new List<string>();
            List<string> newGrades = new List<string>();
            List<int> gradeUnits = new List<int>(); 
            string[] gradeList = {"F", "E", "D", "C", "B", "A" };
            List<int> gradePoints = new List<int>();
            double totalPoints = 0;
            double sumPoints = 0;
            double GP = 0;

            //function to get the course names from user
            CoursesInput(coursesCount, courses)
;
            //function to input course grades from user
            GradeInput(courses, newGrades, gradeList);

            //function to input the course units
            UnitInput(courses, gradeUnits);

            //function to convert grades to equivalent grade points
            ConvertGrades(newGrades, gradeList, gradePoints, courses);

            //function to calculate the GP
            CalculateGP(courses, gradePoints, gradeUnits, sumPoints, totalPoints, GP);

        }

        //get list of courses
        static void CoursesInput(int coursesCount, List<string> courses)
        {
            bool checkInput;
            string input;
            int a;

            Console.Write("Enter the number of courses: ");
            input = Console.ReadLine();
            checkInput = int.TryParse(input, out a);

            while (!checkInput)
            {
                Console.WriteLine("Wrong Input value, Please enter a right value");
                Console.Write("Enter the number of courses: ");
                input = Console.ReadLine();
                checkInput = int.TryParse(input, out a);
            }

            coursesCount = int.Parse(input);
            for(int i = 0; i < coursesCount; i++)
            {
                Console.Write("Enter the name of course: ");
                input = Console.ReadLine();

                courses.Add(input);
            }

        }


        // course grades input
        static void GradeInput(List<string> courses, List<string> newGrades, string[] gradeList)
        {
            string grade;
            int count = 0;
            bool checkInput;
            while (count < courses.Count)
            {
                Console.Write("Enter " + courses[count] + " Grade:");
                grade = Console.ReadLine().ToUpper();

                checkInput = Array.Exists(gradeList, x => x == grade);

                while (!checkInput)
                {
                    Console.WriteLine("Wrong Input value, Please enter a right value");
                    Console.Write("Enter " + courses[count] + " Grade:");
                    grade = Console.ReadLine().ToUpper();

                    checkInput = Array.Exists(gradeList, x => x == grade);
                }

                newGrades.Add(grade);
               
                count++;
            }
        }
        //input course unit
        static void UnitInput(List<string> courses, List<int> gradeUnits)
        {
            int unit;
            int count = 0;
            string input;
            bool checkInput;
            int a;
            while (count < courses.Count)
            {
                Console.Write("Enter " + courses[count] + " Unit:");
                input = Console.ReadLine();

                checkInput = int.TryParse(input, out a);

                while (!checkInput)
                {
                    Console.WriteLine("Wrong Input value, Please enter a right value");
                    Console.Write("Enter " + courses[count] + " Unit:");
                    input = Console.ReadLine();

                    checkInput = int.TryParse(input, out a);
                }

                unit = int.Parse(input);
                gradeUnits.Add(unit);

                count++;
            }
        }

        //convert grades to grade points
        public static void ConvertGrades(List<string> anewGrades, string[] agradeList, List<int> agradePoints, List<string> acourses)
        {
            int index;
            for (int i = 0; i < acourses.Count; i++)
            {
               index = Array.IndexOf(agradeList, anewGrades[i]);
                agradePoints.Insert(i, index);

            }
        }

        //calculate GP
        public static void CalculateGP(List<string> aCourses, List<int> aGradePoints, List<int> aGradeUnits, double aSumPoints, 
            double aTotalPoints, double aGP)
        {
            aTotalPoints = aGradeUnits.Sum() * 5;

            for (int i = 0; i < aCourses.Count; i++)
            {
                aSumPoints += aGradePoints[i] * aGradeUnits[i];

            }
            aGP = ((aSumPoints / aTotalPoints) * 5);
            Console.WriteLine($"Your Gp is {Math.Round(aGP, 2)}");

            Console.ReadLine();

        }
    }
}


