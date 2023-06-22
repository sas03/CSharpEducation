using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEducatif.Classes
{
    public class Logger
    {
        private string _logFilePath;
        public Logger(string logFilePath) {
            _logFilePath = logFilePath;
        }

        public void Log(string message)
        {
            //System.IO
            using (StreamWriter writer = File.AppendText(_logFilePath)) {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                writer.WriteLine(logEntry);
            }
        }
    }
}
