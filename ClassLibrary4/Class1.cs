using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    // Enumeration for at definere forskellige
    public enum LoggingMode
    {
        Console,    // Logger til consolen
        Debug   // Logger til debug værktøjer
    }

    // En Logger klasse for fleksibel logning baset på en vælgt mode
    public static class Logger
    {
        // Nuværende Logning mode (standard: Console)
        private static LoggingMode currentMode = LoggingMode.Console;

        // En funktion for at få og modificere den nuværende logning mode
        public static LoggingMode CurrentMode
        {
            get { return currentMode; }
            set { currentMode = value; }
        }

        // En metode for at skrive en string baset beskede i det nuværende mode efterfulgt af et linjeskift
        public static void WriteLine(string message)
        {
            if (currentMode == LoggingMode.Console)
            {
                Console.WriteLine(message);
            }
            else if (currentMode == LoggingMode.Debug)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }
        }
        // En metode for at skrive en string baset beskede i det nuværende mode uden et linjeskift
        public static void Write(string message)
        {
            if (currentMode == LoggingMode.Console)
            {
                Console.Write(message);
            }
            else if (currentMode == LoggingMode.Debug)
            {
                System.Diagnostics.Debug.Write(message);
            }
        }

        // En overloadet metode for at skrive en integer baset beskede i det nuværende mode efterfulgt af et linjeskift
        public static void WriteLine(int message)
        {
            if (currentMode == LoggingMode.Console)
            {
                Console.WriteLine(message);
            }
            else if (currentMode == LoggingMode.Debug)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }
        }
        // En overloadet metode for at skrive en integer baset beskede i det nuværende mode uden et linjeskift
        public static void Write(int message)
        {
            if (currentMode == LoggingMode.Console)
            {
                Console.Write(message);
            }
            else if (currentMode == LoggingMode.Debug)
            {
                System.Diagnostics.Debug.Write(message);
            }
        }
    }
}
