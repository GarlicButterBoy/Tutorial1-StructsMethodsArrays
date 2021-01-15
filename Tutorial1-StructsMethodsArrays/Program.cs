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
    class Program
    {
        static void Main(string[] args)
        {



        }
        /// <summary>
        /// PercentToLetterGrade - Converts numeric grade to letter grade
        /// </summary>
        /// <param name="percentageGrade"></param>
        /// <returns></returns>
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
        /// <param name="percentageGrade"></param>
        /// <returns></returns>
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
                else if (percentageGrade >= 55.0)
                    strFeedback = "Conditional Pass";
                else if (percentageGrade >= 50.0)
                    strFeedback = "Conditional Pass";
                else
                    strFeedback = "Failure";
            }
            return strFeedback; //returns strFeedback
        }

    }
}
