/*
 * @author  Nick Sturch-Flint
 * @version 1.0.0
 * @since   2021-01-15
 * @see     OOP4200 Tutorial 1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial1_StructsMethodsArrays
{
    /// <summary>
    /// A data structure to store an average grade, number of passing grades, number of failures and number of invalid grades
    /// </summary>
    struct GradeStats
    {
        public double averageGrade; //Average grade for all valid grades
        public int passCount;       //Number of passing grades
        public int failCount;       //Number of failing grades
        public int invalidCount;    //Number of invalid grades
    }

    class Program
    {
        static void Main(string[] args)
        {
            //CONSTANTS
            const int NUMBER_OF_GRADES = 5;
            double[] grades = new double[NUMBER_OF_GRADES];

            //String for user input
            string userInput = "";

            //Loops through 5 grade inputs
            for (int student = 0; student < grades.Length;) //no increment
            {
                try
                {
                    Console.Write("\nEnter a grade for student {0}: ", student + 1); //prompt
                    userInput = Console.ReadLine(); //reads into a string
                    grades[student] = Convert.ToDouble(userInput); //Converts user input to a double
                    //If conversion works, increment
                    student++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, I can't convert {0} into a numeric value, try again!", userInput);
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, something went wrong. Try again!");
                }
            }

            //Delegate Declaration, initialized with PercentToLetterGrade Method
            PercentToFeedback feedbackMethod = PercentToLetterGrade;

            //Change PercentToFeedback from one Method (PercentToLetterGrade) to another (PercentToDescription)
            try
            {
                if (args[0].ToLower() == "description")
                    feedbackMethod = PercentToDescription;
            }
            catch (Exception) { ;}

            //Shows the appropriate output
            ShowGradesReport(grades, feedbackMethod);

            //End of Program
            Console.WriteLine("\nPress Any Key to Exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays Grades and Feedback as well as the averages and counts stored in our Struct
        /// </summary>
        /// <param name="marks">Array of Doubles representing Student Grades</param>
        /// <param name="feedback">Delegate determining the feedback format</param>
        public static void ShowGradesReport(double[] marks, PercentToFeedback feedback)
        {
            GradeStats stats; //holds the stats
            int count = CalculateGradeStats(marks, out stats); //processes the marks array and populates the stats

            for (int student = 0; student < marks.Length; student++)
            {
                //displays their marks and feedback
                Console.WriteLine("Student {0}: {1,5:n1}% : {2}", student + 1, marks[student], feedback(marks[student]));
            }

            //Displays the Stats
            Console.WriteLine("\nCount:    {0, 5:n1}", count);
            Console.WriteLine("Passed:   {0, 5:n1}", stats.passCount);
            Console.WriteLine("Failed:   {0, 5:n1}", stats.failCount);
            Console.WriteLine("Invalid:  {0, 5:n1}", stats.invalidCount);
            Console.WriteLine("Average:  {0, 5:n1}%\n", stats.averageGrade);
        }

        /// <summary>
        /// Processes an array of marks to determine basic summary stats
        /// </summary>
        /// <param name="marks">An Array of marks</param>
        /// <param name="stats">Struct to hold the average, pass, fail and invalid marks</param>
        /// <returns>Number of Grades processed</returns>
        public static int CalculateGradeStats(double[] marks, out GradeStats stats)
        {
            const double MIN_GRADE = 0.0;      //Min Grade Allowed
            const double MAX_GRADE = 100.0;    //Max Grade Allowed
            const double PASSING_GRADE = 50.0; //min passing grade

            double totalValid = 0.0;           //Accumulates Grade Average
            int validCount;                    //Counts Valid Grades

            //Initialize all struct fields to 0;
            stats.averageGrade = 0;
            stats.passCount = 0;
            stats.failCount = 0;
            stats.invalidCount = 0;

            if (marks.Length > 0)//only processes if marks exist in the array
            {
                foreach (double mark in marks) //for each mark in the array
                {
                    if (mark >= MIN_GRADE && mark <= MAX_GRADE)
                    {
                        totalValid += mark;    //adds valid mark to the total
                        if (mark >= PASSING_GRADE)
                        {
                            stats.passCount++; //if the mark is a passing grade, pass counter increases
                        }
                        else
                        {
                            stats.failCount++; //if the marks is a failing grade, fail counter increases
                        }
                    }
                    else
                    {
                        stats.invalidCount++; //if the mark is out of range, invalid counter increases
                    }
                }
                //Calculates the average of all valid grades
                validCount = stats.passCount + stats.failCount;
                if (validCount > 0)
                    stats.averageGrade = (double)totalValid / validCount; 
            }

            return marks.Length; //returns the number of processed marks
        }

        /// <summary>
        /// Used to reference either PercentToGrade() or PercentToDescription
        /// </summary>
        /// <param name="percentageGrade">Numeric Grade</param>
        /// <returns>Feedback String</returns>
        public delegate string PercentToFeedback(double percentageGrade);


        /// <summary>
        /// PercentToLetterGrade - Converts numeric grade to letter grade
        /// </summary>
        /// <param name="percentageGrade">Numeric Grade</param>
        /// <returns>Feedback String</returns>
        public static string PercentToLetterGrade(double percentageGrade)
        {
            const double MIN_GRADE = 0.0;   //Min Grade Allowed
            const double MAX_GRADE = 100.0; //Max Grade Allowed
            string strFeedback = "INVALID"; //Invalid by default

            //If numeric grade is a valid number
            if (percentageGrade >= MIN_GRADE && percentageGrade <= MAX_GRADE)
            {
                //Sets the letter grade depending on numeric input
                if (percentageGrade >= 90.0)
                    strFeedback = "A+";
                else if (percentageGrade >= 85.0)
                    strFeedback = "A";
                else if (percentageGrade >= 80.0)
                    strFeedback = "A-";
                else if (percentageGrade >= 75.0)
                    strFeedback = "B+";
                else if (percentageGrade >= 70.0)
                    strFeedback = "B";
                else if (percentageGrade >= 65.0)
                    strFeedback = "C+";
                else if (percentageGrade >= 60.0)
                    strFeedback = "C";
                else if (percentageGrade >= 55.0)
                    strFeedback = "D+";
                else if (percentageGrade >= 50.0)
                    strFeedback = "D";
                else
                    strFeedback = "F";
            }
            return strFeedback; //returns strFeedback
        }

        /// <summary>
        /// Converts a numeric grade to a descriptive string
        /// </summary>
        /// <param name="percentageGrade">Numeric Grade</param>
        /// <returns>Feedback String</returns>
        public static string PercentToDescription(double percentageGrade)
        {
            const double MIN_GRADE = 0.0;   //Min Grade Allowed
            const double MAX_GRADE = 100.0; //Max Grade Allowed
            string strFeedback = "INVALID"; //Invalid by default
            
            //If numeric grade is a valid number
            if (percentageGrade >= MIN_GRADE && percentageGrade <= MAX_GRADE)
            {
                //Sets the letter grade depending on numeric input
                if (percentageGrade >= 90.0)
                    strFeedback = "Outstanding";
                else if (percentageGrade >= 85.0)
                    strFeedback = "Exemplary";
                else if (percentageGrade >= 80.0)
                    strFeedback = "Excellent";
                else if (percentageGrade >= 75.0)
                    strFeedback = "Very Good";
                else if (percentageGrade >= 70.0)
                    strFeedback = "Good";
                else if (percentageGrade >= 65.0)
                    strFeedback = "Satisfactory";
                else if (percentageGrade >= 60.0)
                    strFeedback = "Acceptable";
                else if (percentageGrade >= 50.0)
                    strFeedback = "Conditional Pass";
                else
                    strFeedback = "Failure";
            }
            return strFeedback; //returns strFeedback
        }

    }
}
