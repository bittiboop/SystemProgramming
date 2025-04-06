using System;
using System.Diagnostics;
using System.IO;


namespace SystemProgramming
{
    class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DisplayMenu();

                var choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        LaunchNotepad();
                        break;
                    case '2':
                        LaunchCalculator();
                        break;
                    case '3':
                        LaunchPaint();
                        break;
                    case '4':
                        LaunchCustomApp();
                        break;
                    case '0':
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nEnter to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("=== Launching programs menu ===");
            Console.WriteLine("1. Launch Notepad");
            Console.WriteLine("2. Launch Calculator");
            Console.WriteLine("3. Launch Paint");
            Console.WriteLine("4. Choose custom program");
            Console.WriteLine("0. Exit");
            Console.Write("Vhoose option: ");
        }

        static void LaunchNotepad()
        {
            try
            {
                Console.WriteLine("Notepad launch...");
                Process.Start("notepad.exe");
                Console.WriteLine("Notepad запущено успішно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Launch error for Notepad: {ex.Message}");
            }
        }

        static void LaunchCalculator()
        {
            try
            {
                Console.WriteLine("Calculator launch...");
                Process.Start("calc.exe");
                Console.WriteLine("Calculator launched successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Launch error for Calculator: {ex.Message}");
            }
        }

        static void LaunchPaint()
        {
            try
            {
                Console.WriteLine("Paint launch...");
                Process.Start("mspaint.exe");
                Console.WriteLine("Paint launched successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Launch error for Paint: {ex.Message}");
            }
        }

        static void LaunchCustomApp()
        {
            Console.Write("Enter the .exe path: ");
            string path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Path cannot be empty");
                return;
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            try
            {
                Console.WriteLine($"Program launch: {path}");
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
                Console.WriteLine("Successfully launched");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error was occured during launch: {ex.Message}");
            }
        }
    }
}