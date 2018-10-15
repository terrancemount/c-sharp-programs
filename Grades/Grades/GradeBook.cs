using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        

        public GradeBook()
        {
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            var stats = new GradeStatistics();

            if (grades.Count == 0)
            {
                return stats;
            }

            stats.lowest = grades.Min();
            stats.highest = grades.Max();
            stats.average = grades.Average();

            return stats;
        }

        List<float> grades;
    }
}
