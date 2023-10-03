using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            GradingPeriod studentA = new GradingPeriod(78.88, 85.00, 100.00);
            GradingPeriod studentB = new GradingPeriod(57.76, 98.00, 100.00);
            GradingPeriod studentC = new GradingPeriod(98.00, 87.92, 99.00);
            GradingPeriod studentD = new GradingPeriod(87.98, 85.00, 98.00);
            GradingPeriod studentE = new GradingPeriod(89.00, 90.15, 97.00);
            GradingPeriod studentF = new GradingPeriod(90.00, 90.11, 89.90);
    
            List<Student> students = new List<Student>
            {
                new Student("Student A", studentA),
                new Student("Student B", studentB),
                new Student("Student C", studentC),
                new Student("Student D", studentD),
                new Student("Student E", studentE),
                new Student("Student F", studentF),

            };

            Console.WriteLine("Student Data:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Name\t\tPrelim\tMidterm\tFinals\tFAverage");
            Console.WriteLine("------------------------------------------------------");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}\t{student.Grades.Prelim}\t{student.Grades.Midterm}\t{student.Grades.Finals}\t{Math.Ceiling(student.OverallRating):F0}");
            }

            Console.WriteLine("------------------------------------------------------");

            double[] prelimGrades = students.Select(student => student.Grades.Prelim).ToArray();
            double[] midtermGrades = students.Select(student => student.Grades.Midterm).ToArray();
            double[] finalsGrades = students.Select(student => student.Grades.Finals).ToArray();
            double[] overallRatings = students.Select(student => student.OverallRating).ToArray();

            string[] categories = { "Prelim", "Midterm", "Finals", "FAverage" };

            Console.WriteLine("Statistics:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"{"",10}{"Mean",10}{"Median",10}{"Mode",10}{"Variance",10}{"Std Dev",10}{"Range",10}");
            Console.WriteLine("------------------------------------------------------");

            foreach (var category in categories)
{
    double[] data = category switch
    {
        "Prelim" => prelimGrades.Select(x => Math.Floor(x)).ToArray(),
        "Midterm" => midtermGrades.Select(x => Math.Floor(x)).ToArray(),
        "Finals" => finalsGrades.Select(x => Math.Floor(x)).ToArray(),
        _ => overallRatings.Select(x => Math.Ceiling(x)).ToArray(),
    };

    if (category == "FAverage") // Output for Final Average, Need this cuz FAverage will calc the mode of ALL Terms
    {
        string overallMode = GradeCalculator.CalculateOverallMode(prelimGrades, midtermGrades, finalsGrades);
        Console.WriteLine($"{category,10}" +
                          $"{GradeCalculator.CalculateMean(data),10:F0}" +
                          $"{GradeCalculator.CalculateMedian(data),10:F0}" +
                          $"{overallMode,10}" + 
                          $"{GradeCalculator.CalculateVariance(data),10:F0}" +
                          $"{GradeCalculator.CalculateStandardDeviation(data),10:F0}" +
                          $"{GradeCalculator.CalculateRange(data),10:F0}");
    }
    else
    {
        // Output for other categories (Prelim, Midterm, Finals)
        Console.WriteLine($"{category,10}" +
                          $"{GradeCalculator.CalculateMean(data),10:F2}" +
                          $"{GradeCalculator.CalculateMedian(data),10:F2}" +
                          $"{GradeCalculator.CalculateMode(data),10:F2}" +
                          $"{GradeCalculator.CalculateVariance(data),10:F2}" +
                          $"{GradeCalculator.CalculateStandardDeviation(data),10:F2}" +
                          $"{GradeCalculator.CalculateRange(data),10:F2}");
    }
}


            Console.WriteLine("------------------------------------------------------");

            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
