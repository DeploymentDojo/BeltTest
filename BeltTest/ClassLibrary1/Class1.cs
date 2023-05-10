using System;
using System.IO;
using Microsoft.Win32;

namespace ClassLibrary1
{
    public class Class1
    {
        private static string _path;

        public static string GetCountFilePath()
        {
            if (!String.IsNullOrEmpty(_path))
            {
                return _path;
            }

            var path = String.Empty;

            try
            {
                path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFilePath", null) as string;
            }
            catch
            {
            }

            if (String.IsNullOrEmpty(path))
            {
                path = Path.Combine(AppContext.BaseDirectory, "WindowsService1.txt");
            }

            _path = Path.GetFullPath(path);

            Directory.CreateDirectory(Path.GetDirectoryName(_path));

            return _path;
        }
    }
}
