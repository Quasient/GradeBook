using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{

    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            try
            {
                using (FileStream stream = File.Open("grades.txt", FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not locate the file grades.txt");
                return;
            }
            catch (UnauthorizedAccessException)
            {

                Console.WriteLine("No access.");
                return;
            }

            foreach(float grade in book)
            {
                Console.WriteLine(grade);
            }
            try
            {
                //Console.WriteLine("Please type a name for the book");
                //string enteredName = Console.ReadLine();
                //while (enteredName.Length == 0)
                //    {
                //    Console.Write("It seems you didn't enter a name. Please try again\n");
                //    enteredName = Console.ReadLine();
                //    }
                //book.Name = enteredName;
                //Console.Write("Your book has been named\n" + book.Name + "\n");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid name");
            }

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine("The Average Grade is " + stats.AverageGrade);
            Console.WriteLine("The Lowest Grade is " + stats.LowestGrade);
            Console.WriteLine("The Highest Grade is " + stats.HighestGrade);
            Console.WriteLine("{0} {1}", stats.LetterGrade, stats.Description);
        }

        private static IGradeTracker CreateGradeBook()
        {
            IGradeTracker book = new ThrowAwayGradeBook("Kuba's Book");
            return book;
        }
    }       
}

