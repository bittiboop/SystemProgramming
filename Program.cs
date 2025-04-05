using System.Diagnostics;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        
        var list = Process.GetProcessesByName("zen");
        if (list.Length == 0)
        {
            Console.WriteLine("No process found with the name 'zen'.");
            return;
        }

        Console.WriteLine($"Found {list.Length} process(es) with the name 'zen'.");
        foreach (var process in list)
        {
            Console.WriteLine($"-------------------------<Process ID: {process.Id}>-------------------------");
            Console.WriteLine($"Process Name: {process.ProcessName}");
            Console.WriteLine($"Process Start Time: {process.StartTime}");
            Console.WriteLine($"Process Memory Size: {process.PrivateMemorySize64 / 1024} KB");
            Console.WriteLine($"Process CPU Time: {process.TotalProcessorTime}");
            Console.WriteLine($"Process Threads Count: {process.Threads.Count}");
            Console.WriteLine($"Process Handle Count: {process.HandleCount}");
            Console.WriteLine("\n");
            ProcessModuleCollection modules = process.Modules;
 
            foreach(ProcessModule module in modules)
            {
                Console.WriteLine($"-------------------------<Process ID: {process.Id} - Module Name: {module.ModuleName}>-------------------------");
                Console.WriteLine($"FileName: {module.FileName}");
                Console.WriteLine($"Base Address: {module.BaseAddress}");
                Console.WriteLine($"Entry Point Address: {module.EntryPointAddress}");
                Console.WriteLine($"File Version: {module.FileVersionInfo.FileVersion}");
                Console.WriteLine($"File Description: {module.FileVersionInfo.FileDescription}");
                Console.WriteLine($"File Company Name: {module.FileVersionInfo.CompanyName}");
                Console.WriteLine($"File Product Name: {module.FileVersionInfo.ProductName}");
                Console.WriteLine($"File Copyright: {module.FileVersionInfo.LegalCopyright}");
                Console.WriteLine($"File Product Version: {module.FileVersionInfo.ProductVersion}");
                Console.WriteLine("\n\n");
            }
        }

        Console.ReadKey();
    }
}