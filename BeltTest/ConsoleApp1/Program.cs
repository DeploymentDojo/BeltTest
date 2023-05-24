using System;
using System.IO;
using System.Threading;
using ClassLibrary1;
using Microsoft.Win32;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var edition = Class1.GetEdition();
            var customer = Class1.GetCustomer();

            Console.WriteLine("Welcome to the {0} ConsoleApp1.", edition);
            Console.WriteLine("  Registered to our {0} customer.", customer);
            Console.WriteLine();

            var path = Class1.GetCountFilePath();
            var oldText = String.Empty;

            while (!Console.KeyAvailable)
            {
                string text;

                try
                {
                    text = File.ReadAllText(path);
                }
                catch (Exception e)
                {
                    text = e.Message;
                }

                if (text != oldText)
                {
                    Console.WriteLine(text);
                    oldText = text;
                }

                Thread.Sleep(1000);
            }
        }
    }
}
