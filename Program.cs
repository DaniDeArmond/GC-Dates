using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Text;

namespace GC_Dates
{
    class Program
    {
        //checks for a compatible date/time format, using US culture and a variety of possible inputs
        public static bool DateTimeParse(string userDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            DateTime date1;
            bool bool1;
            List<string> badFormats = new List<String>();

            
            if (DateTime.TryParse(userDate, out DateTime result))
            {
                date1 = result;
            }
            else
            {
                bool1 = false;
                return bool1;
            }

            foreach (var dateString in date1.GetDateTimeFormats())
            {
                DateTime parsedDate;
                if (DateTime.TryParse(dateString, out parsedDate))
                {
                    bool1 = true;
                    return bool1;
                }
                else
                {
                    badFormats.Add(dateString);
                }
            }

            // Display strings that could not be parsed.
            if (badFormats.Count > 0)
            {
                bool1 = false;
                return bool1;
            }
            else
            {
                bool1 = true;
                return bool1;
            }

        }

        static void Main(string[] args)
        {
            //defining variables
            string myDate1 = "", myDate2 = "";
            bool repeat1 = true, repeat2 = true;
            DateTime dateTime1, dateTime2;
            TimeSpan timeAmount1;

            //sets loop to run the program again
            while (repeat1 == true)
            {
                char doAgain;

                Console.WriteLine("This program will tell you the difference between two dates in days, hours and minutes." +
                   "{0}This calculation only works for dates in the same time zone.{1}" +
                   "If you choose not to enter hours and minutes, the time will be set to 00:00 by default{2}", 
                   Environment.NewLine, Environment.NewLine, Environment.NewLine);


                //sets loop for validation of input & validates input
                while (repeat2 == true)
                {
                    Program n = new Program();
                    Console.WriteLine("Please input the first date. (mm/dd/yyyy hh:mm am/pm) OR (mm/dd/yyyy hh:mm) using the 24-hour clock");
                    myDate1 = (Console.ReadLine());
                    Console.Write(Environment.NewLine);


                    Console.WriteLine("Please input the second date. (mm/dd/yyyy hh:mm am/pm) OR (mm/dd/yyyy hh:mm) using the 24-hour clock");
                    myDate2 = (Console.ReadLine());
                    Console.Write(Environment.NewLine);

                    if ((DateTimeParse(myDate1)) & (DateTimeParse(myDate2)))
                    {
                        repeat2 = false;
                    }
                    else
                    {
                        Console.Write("Your dates are not in the correct format. Please try again.");
                    }
                }

                //initializes the datetime objects
                dateTime1 = DateTime.Parse(myDate1);
                dateTime2 = DateTime.Parse(myDate2);

                //calculates the difference and outputs timespan, writing to console
                if (dateTime2 > dateTime1)
                {
                    timeAmount1 = dateTime2 - dateTime1;
                    Console.WriteLine(myDate1 + " occurs " + "{0:%d} days, {1:%h} hours, and {2:%m} minutes before " +
                        myDate2, timeAmount1, timeAmount1, timeAmount1);
                }
                else
                {
                    timeAmount1 = dateTime1 - dateTime2;
                    Console.WriteLine(myDate2 + " occurs " + "{0:%d} days, {1:%h} hours, and {2:%m} minutes before " +
                        myDate1, timeAmount1, timeAmount1, timeAmount1);
                }

                //allows the user to run the program again
                Console.WriteLine("Would you like to run this program again? (Y or N)");
                doAgain = (Convert.ToChar(Console.ReadLine()));

                if (doAgain == 'Y' || doAgain == 'y')
                {
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
                else
                {
                    repeat1 = false;
                }
            }
        }
    }
}
