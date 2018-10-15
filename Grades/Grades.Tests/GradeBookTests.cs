using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputerStatisticsEmpty()
        {
            GradeBook book = new GradeBook();

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(0, result.average);
            Assert.AreEqual(0, result.lowest);
            Assert.AreEqual(0, result.highest);
        }
        [TestMethod]
        public void ComputeStatistics()
        {
            GradeBook book = new GradeBook();

            var test = new List<float>() { 10f, 66f, 99f };

            foreach(float grade in test)
            {
                book.AddGrade(grade);
            }
         
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(test.Max(), result.highest);
            Assert.AreEqual(test.Min(), result.lowest);
            Assert.AreEqual(test.Average(), result.average, 0.01);
            //the third parameter is a delta.
        }
    }
}
