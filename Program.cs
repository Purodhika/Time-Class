using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeApp
{    
    //Enums
    public enum TimeFormat    
    {       
        Mil ,        
        Hour12,       
        Hour24    
    }   
    class Time
    {
        public static void Main(String[] args)
        {
            //create a list to store the objects
            List<Time> times = new List<Time>()
            {
               new Time(9, 35),
               new Time(18, 5),
               new Time(20, 500),
               new Time(10),
               new Time()
            };
            //display all the objects
            TimeFormat format = TimeFormat.Hour12;
            Console.WriteLine($"\n\nTime format is {format}");
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }

            //change the format of the output
            format = TimeFormat.Mil;
            Console.WriteLine($"\n\nSetting time format to {format}");

            //SetFormat(TimeFormat) is a class member, so you need the type to access it
            Time.SetFormat(format);

            //again display all the objects
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }

            //change the format of the output
            format = TimeFormat.Hour24;
            Console.WriteLine($"\n\nSetting time format to {format}");

            //SetFormat(TimeFormat) is a class member, so you need the type to access it
            Time.SetFormat(format);
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }
        }
        public Time(int hour = 0, int minute = 0)
        {
            //Check Hour Validation
            if (hour >= 0 && hour <= 24)
            {
                this.Hour = hour;
            }
            else
            {
                this.Hour = 0;
            }

            //Check Minute Validation
            if (minute >= 0 && minute <= 60)
            {
                this.Minute = minute;
            }
            else
            {
                this.Minute = 0;
            }
        }
        private static TimeFormat Time_Format = TimeFormat.Hour12;
        public int Hour { get; }
        public int Minute { get; }
        public static void SetFormat(TimeFormat time_format)
        {
            Time_Format = time_format;
        }
        public override string ToString()
        {
            switch (Time_Format)
            {
                case TimeFormat.Mil: { return this.Hour.ToString("D2") + this.Minute.ToString("D2"); }
                case TimeFormat.Hour12:
                    {
                        var hours = this.Hour;
                        var minutes = this.Minute;
                        var amPm = "AM";

                        if (hours == 0)
                            hours = 0;

                        else if (hours == 12)
                            amPm = "PM";

                        else if (hours > 12)
                        {
                            hours -= 12; amPm = "PM";
                        }

                        return string.Format("{0}:{1:00} {2}", hours, minutes, amPm);

                    }
                case TimeFormat.Hour24:
                    {
                        return this.Hour.ToString("D2") + ":" + this.Minute.ToString("D2");
                    }
                default: return "";
            }
        }
    }
}
