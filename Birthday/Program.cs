using System;
using System.Text.RegularExpressions;

namespace Birthday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables
            DateTime birthDate;
            DateTime currDate;
            DateTime custDate;
            TimeSpan dateDiff;
            int yearCount;

            Console.WriteLine("This is a birthday calculator.\nPlease enter the day of birth in DD-MM-YYYY format.\n");
            Console.Write("> ");
            //string dateOfBirth = Console.ReadLine();
            string dateOfBirth = "12-07-1992";
            DateTime.ParseExact(dateOfBirth, "dd-MM-yyyy", null);
            //Console.WriteLine(birthdate);
            birthDate = Convert.ToDateTime(dateOfBirth);

            Console.WriteLine("Would you like to calcuate from today's date?\nType \"Y\" to use the current date,\n" +
                "or \"N\" to enter a date yourself.");
            Console.Write("> ");
            string choiceIn = Console.ReadLine();  // Allows for input
            string choiceOut = choiceIn.ToUpper();  // This turns the input into uppercase

            switch (choiceOut)
            {
                case "Y":
                case "\"Y\"":
                    currDate = DateTime.Now;
                    string currDateToStr = Convert.ToString(currDate);
                    //currDateToStr.Replace("/", "-");
                    var currDateRegex = Regex.Replace(currDateToStr, "/","-");
                    int endLen = 10; // Length of the end of the string
                    string currDateTrunc = currDateRegex.Substring(0, endLen);
                    //Console.WriteLine(currDateTrunc);
                    //Console.WriteLine(currDateRegex);
                    //Console.WriteLine(currDateToStr);
                    //Console.WriteLine(currDate);
                    dateDiff = currDate - birthDate;
                    yearCount = (int)Math.Floor(dateDiff.TotalDays/365.2425);
                    Console.WriteLine($"From {dateOfBirth} to {currDateTrunc} has a difference of {yearCount} years.");
                    break;

                case "N": case "\"N\"":
                    DateTime.TryParse(choiceIn, out custDate);
                    break;
            }
        }
    }
}