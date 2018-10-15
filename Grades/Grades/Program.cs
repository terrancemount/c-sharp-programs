using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        

        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            synth.Speak("Hello World!");

            var book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(49.2f);

            var stats = book.ComputeStatistics();

            Console.WriteLine($"min = {stats.lowest}, max = {stats.highest}, avg = {stats.average}");
        }
    }
}
