using System;
using System.Globalization;
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
            DateTime dateOfBirth;
            DateTime dateOfDate;
            TimeSpan dateDiff;
            int yearCount;
            // Defining variables
            currDate = DateTime.Now;
            int endLen = 10; // Length of the end of the string
            string currDateToStr = Convert.ToString(currDate);
            var currDateRegex = Regex.Replace(currDateToStr, "/", "-");
            string currDateTrunc = currDateRegex.Substring(0, endLen);

            // Text to console
            Console.WriteLine("This is a birthday calculator.\nPlease enter the date of birth in DD-MM-YYYY format.\n");
            //string dateOfBirth = Console.ReadLine();
            //string dateOfBirth = "12-07-1992";  // Temp for laziness

            while (true)  // Prevents invalid dates from being input
            {
                Console.Write("> ");
                // TryParseExact works like ParseExact, but needs to DataTimeStyles, which is None in this case.
                // This way it will only allow valid inputs, and through the while loop is true,
                // it will repeat it until the input is no longer invalid.
                if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, DateTimeStyles.None, out dateOfBirth)) break;
                //if (DateTime.TryParseExact("12-07-1992", "dd-MM-yyyy", null, DateTimeStyles.None, out dateOfBirth)) break;
                Console.WriteLine("Your input is invalid. Please try again.");
            }            //Console.WriteLine(birthdate);
            birthDate = Convert.ToDateTime(dateOfBirth);

            string birthDateToStr = Convert.ToString(birthDate);  // DateTime to string
            //currDateToStr.Replace("/", "-");
            var birthDateRegex = Regex.Replace(birthDateToStr, "/", "-");  // Replaces symbols
            string birthDateTrunc = birthDateRegex.Substring(0, endLen);  // Removes the time at the end

            Console.WriteLine("\nWould you like to calcuate from today's date?\nType \"Y\"" +
                "to use the current date,\nor \"N\" to enter a date yourself.\n" +
                "If you want to exit the application, type anything else.\n");
            Console.Write("> ");
            string choiceIn = Console.ReadLine();  // Allows for input
            string choiceOut = choiceIn.ToUpper();  // This turns the input into uppercase

            switch (choiceOut)
            {
                case "Y":
                case "\"Y\"":

                    //Console.WriteLine(currDateTrunc);
                    //Console.WriteLine(currDateRegex);
                    //Console.WriteLine(currDateToStr);
                    //Console.WriteLine(currDate);
                    dateDiff = currDate - birthDate;
                    yearCount = (int)Math.Floor(dateDiff.TotalDays / 365.2425);  // Rounds down to the nearest whole number
                    // Interpolation to get various varibles to show in the string
                    Console.WriteLine($"\nFrom {birthDateTrunc} to {currDateTrunc} has a difference of {yearCount} years.");
                    break;

                case "N":
                case "\"N\"":
                    Console.WriteLine("\nPlease enter the second date in DD-MM-YYYY format.\n");
                    //string dateOfDate = Console.ReadLine();
                    //string dateOfDate = "02-93-1962";  // Temp for laziness, again.

                    while (true)
                    {
                        Console.Write("> ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, DateTimeStyles.None, out dateOfDate)) break;
                        //if (DateTime.TryParseExact("12-07-1990", "dd-MM-yyyy", null, DateTimeStyles.None, out dateOfDate)) break;
                        Console.WriteLine("Your input is invalid. Please try again.");
                    }
                    custDate = Convert.ToDateTime(dateOfDate);
                    string custDateToStr = Convert.ToString(custDate);
                    var custDateRegex = Regex.Replace(custDateToStr, "/", "-");
                    string custDateTrunc = custDateRegex.Substring(0, endLen);
                    dateDiff = birthDate - custDate;
                    yearCount = (int)Math.Floor(dateDiff.TotalDays / 365.2425);
                    Console.WriteLine($"\nFrom {birthDateTrunc} to {custDateTrunc} has a difference of {yearCount} years.");
                    break;
            }
        }
    }
}