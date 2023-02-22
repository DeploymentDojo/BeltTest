using System;
using Microsoft.Win32;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var edition = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Edition", null);
            var customer = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", null);

            Console.WriteLine("Welcome to the {0} ConsoleApp1.", edition);
            Console.WriteLine("  Registered to our {0} customer.", customer);

            Console.ReadKey();
        }
    }
}
