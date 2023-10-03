namespace StudentGradesCalculator
{
    public class GradingPeriod
    {
        public double Prelim { get; set; }
        public double Midterm { get; set; }
        public double Finals { get; set; }

        public GradingPeriod(double prelim, double midterm, double finals)
        {
            Prelim = prelim;
            Midterm = midterm;
            Finals = finals;
        }
    }


    public class Student
    {
        public string Name { get; set; }
        public GradingPeriod Grades { get; set; }
        public double OverallRating { get; private set; }

        public Student(string name, GradingPeriod grades)
        {
            Name = name;
            Grades = grades;
            CalculateOverallRating();
        }

        private void CalculateOverallRating()
        {
            OverallRating = 0.2 * Grades.Prelim + 0.3 * Grades.Midterm + 0.5 * Grades.Finals;

            /*
            Based po dun sa inyong First Activity ito :)
            */
        }
    }
}
