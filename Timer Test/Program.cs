using System;
using System.Timers;

namespace Timer_Test
{
    class Program
    {
        private static System.Timers.Timer newTimer;

        static void Main(string[] args)
        {
            SetTimer();
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            newTimer.Stop();                                                                        //Stop timer
            newTimer.Dispose();                                                                     //Terminate timer

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            //Create a timer with a 60 second interval
            newTimer = new Timer(60000);

            newTimer.Elapsed += OnTimedEvent;                                                       //Add event handler
            newTimer.AutoReset = true;                                                              //Raise elapsed event repeatedly
            newTimer.Enabled = true;                                                                //Start timer
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);        //Display Message
            Console.WriteLine(e.SignalTime.ToShortTimeString());

            DateTime testDate = new DateTime(2019, 1, 1, 14, 14, 00);                               //Assemble test date

            if (e.SignalTime.ToShortTimeString().Equals(testDate.ToShortTimeString()))              //Compares the timer to the current time
                Console.WriteLine("It's time");
            

        }


    }
}
