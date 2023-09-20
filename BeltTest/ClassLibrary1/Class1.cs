using System;
using System.IO;
using Microsoft.Win32;

namespace ClassLibrary1
{
    public class Class1
    {
        private static string _path;

        public static string GetEdition()
        {
            return (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Edition", null);
        }

        public static string GetCustomer()
        {
            return (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", null);
        }

        public static void SetCustomer(string customer)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", customer, RegistryValueKind.String);
        }

        public static string GetCountFilePath()
        {
            if (!String.IsNullOrEmpty(_path))
            {
                return _path;
            }

            var folder = String.Empty;
            var filename = String.Empty;

            try
            {
                folder = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFileFolder", null) as string;
            }
            catch
            {
            }

            try
            {
                filename = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFileFilename", null) as string;
            }
            catch
            {
            }

            if (String.IsNullOrEmpty(folder))
            {
                folder = AppContext.BaseDirectory;
            }

            if (String.IsNullOrEmpty(filename))
            {
                filename = "WindowsService1.txt";
            }

            folder = Path.GetFullPath(folder);

            Directory.CreateDirectory(folder);

            _path = Path.Combine(folder, filename);

            return _path;
        }
    }
}
