using FinalProject.Infrustucture;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Manager
{
    internal class ScannerManager
    {
        public static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!int.TryParse(Console.ReadLine(), out int value))
            {
                PrintError("Invalid data! Try again...");
                goto l1;
            }

            Console.ResetColor();
            return value;
        }
        public static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                PrintError("Invalid data! Try again...");
                goto l1;
            }

            Console.ResetColor();
            return value;
        }
        public static string ReadString(string caption)
        {
        l1:
            Console.Write(caption);

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string value = Console.ReadLine();

            if (string.IsNullOrEmpty(value))
            {
                PrintError("Invalid data! Try again...");
                goto l1;
            }

            Console.ResetColor();
            return value;
        }
        public static DateTime ReadDate(string caption)
        {
        l1:
            Console.Write($"{caption} [yyyy]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy", null, DateTimeStyles.None, out DateTime value))
            {
                PrintError("Invalid data! Try again...");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }
        public static void PrintError(string message)
        {
            Console.Beep(200,500);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static Menu ReadMenu(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!Enum.TryParse(Console.ReadLine(), out Menu m))
            {
                PrintError("Select correct menu...");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }
        public static FuelType ReadFuelMenu(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!Enum.TryParse(Console.ReadLine(), out FuelType m))
            {
                PrintError("Select correct menu...");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }
    }
}
