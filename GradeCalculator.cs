using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentGradesCalculator
{
    public class GradeCalculator
    {
        public static double CalculateMean(double[] values)
        {
            double sum = values.Sum();
            return sum / values.Length;
        }

        public static double CalculateMedian(double[] values)
        {
            Array.Sort(values);
            int length = values.Length;
            int mid = length / 2;
            if (length % 2 == 0)
            {
                return (values[mid - 1] + values[mid]) / 2.0;
            }
            else
            {
                return values[mid];
            }
        }

        public static string CalculateMode(double[] values)
        {
            var grouped = values.GroupBy(v => v).OrderByDescending(g => g.Count());
            int maxCount = grouped.First().Count();
            if (maxCount > 1)
            {
                return grouped.First().Key.ToString();
            }
            else
            {
                return "no mode"; 
            }
        }

        public static string CalculateOverallMode(double[] prelimGrades, double[] midtermGrades, double[] finalsGrades)
        {
            
            var allGrades = new List<double>();
            allGrades.AddRange(prelimGrades);
            allGrades.AddRange(midtermGrades);
            allGrades.AddRange(finalsGrades);

            
            var grouped = allGrades.GroupBy(v => v).OrderByDescending(g => g.Count());

            
            int maxCount = grouped.First().Count();
            if (maxCount > 1)
            {
                return grouped.First().Key.ToString();
            }
            else
            {
                return "no mode";
            }
        }



        public static double CalculateVariance(double[] values)
        {
                double mean = CalculateMean(values);
                return values.Select(x => Math.Pow(x - mean, 2)).Sum() / (values.Length - 1);
        }


        public static double CalculateStandardDeviation(double[] values)
        {
            return Math.Sqrt(CalculateVariance(values));
        }

        public static double CalculateRange(double[] values)
        {
            return values.Max() - values.Min();
        }
    }
}
