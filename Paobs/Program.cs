using System;
using System.Reflection;

namespace Paobs
{
    class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName = assembly.GetName().Name;
            AssemblyLocation = assembly.Location;
            UserName = Environment.UserName;

            if (args.Length == 0)
            {
                new MainForm().ShowDialog();
            }
            else
            {
                new Main(args);
            }
        }

        public static string AssemblyName;
        public static string AssemblyLocation;
        public static string UserName;
    }
}
