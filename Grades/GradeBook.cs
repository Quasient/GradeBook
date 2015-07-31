using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        
        //Constructors
        public GradeBook(string name = "There is no name")
        {
            _name = name;
            _grades = new List<float>();
                }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }
        //Methods
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades");
            foreach(int grade in _grades)
            {
                textWriter.WriteLine(grade);
                         } 
            textWriter.WriteLine("*******");
        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0f;
            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / _grades.Count;
            return stats;
        }

        protected List<float> _grades;
    }
}
