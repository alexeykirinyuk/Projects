using System;
using System.IO;

namespace Projects.Managers.Logging
{
    public class Log
    {
        private static object _locker = new object();
        private const string _path = "log.txt";

        public void Info(string tag, string message) => Write("Info", tag, message);
        public void Warning(string tag, string message) => Write("Warning", tag, message);
        public void Error(string tag, Exception exception)
        {
            Write("Error", tag, exception.Message);

            if (ManagerFactory.Debug)
            {
                throw exception;
            }
        }

        private static void Write(string type, string tag, string message)
        {
            lock (_locker)
            {
                using (var stream = new StreamWriter(new FileStream(_path, FileMode.Append, FileAccess.Write)))
                {
                    stream.WriteLine($"[{type}] {DateTime.Now} ({tag}): {message}");
                }
            }
        }
    }
}
