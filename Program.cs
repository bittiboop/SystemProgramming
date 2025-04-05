using System.Diagnostics;

namespace SystemProgramming
{
    class Program
    {
        private static void ListProcesses()
        {
             foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
            }

            Console.Write("get process by name: ");
            var processByName = Console.ReadLine();
            if (string.IsNullOrEmpty(processByName))
            {
                Console.WriteLine("Process name cannot be empty.");
                return;
            }

            var list = Process.GetProcessesByName(processByName);
            if (list.Length == 0)
            {
                Console.WriteLine($"No processes found with the name: {processByName}");
                return;
            }

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

                foreach (ProcessModule module in modules)
                {
                    Console.WriteLine(
                        $"-------------------------<Process ID: {process.Id} - Module Name: {module.ModuleName}>-------------------------");
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
        }
        private static void Main(string[] args)
        {
            static void TimerCallback(Object o)
            {
                var interval = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Youre list processes will refresh after {interval} seconds");
                Timer timer = new Timer(TimerCallback, null, 0, interval * 1000);
                ListProcesses();
            }
        }
    }
}