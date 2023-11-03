using System;
using System.IO;

namespace Paobs
{
    class LogIO
    {
        public static string TimeText => $"[{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}]";
        public static string UserText => $"[{Environment.UserName}]";
        public static string GetLocalPath(string name) => Path.Combine(Path.GetDirectoryName(Program.AssemblyLocation), name);

        public static void LogEvents(string text)
        {
            string line = $"{TimeText}{UserText} {text}\n";

            try
            {
                Console.Write(line);
                File.AppendAllText(GetLocalPath("log.txt"), line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
