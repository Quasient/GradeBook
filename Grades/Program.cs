using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grades
{
    public class Animal
    {
        private readonly string Name;

        public Animal(string name)
        {
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook("Kuba's Book");
            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;
            

            book.Name = "Kierszka's Book";
            WriteNames(book.Name);

            Console.WriteLine("The Average Grade is " + stats.AverageGrade);
            Console.WriteLine("The Lowest Grade is " + stats.LowestGrade);
            Console.WriteLine("The Highest Grade is " + stats.HighestGrade);

        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }

        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.oldValue, args.newValue);
        }

   
      
        //Integer handler (Overloaded method for int or float)
        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }
        //Write the array for each
        private static void WriteByteArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0x{0:X} ", b);
            }
            Console.WriteLine();
        }
        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}