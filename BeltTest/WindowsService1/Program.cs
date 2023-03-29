using System.ServiceProcess;

namespace WindowsService1
{
    internal static class Program
    {
        static void Main()
        {
            ServiceBase.Run(new Service1());
        }
    }
}
