using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIntegrityMonitor.DTO;

namespace FileIntegrityMonitor
{
    public enum LogType
    {
        Error = 0,
        Warning = 1,
        Notification = 2
    }

    public static class Logger
    {


        public static void LogFileChanged(FileScan latest, FileScan other)
        {

        }

        public static void Log(string message, LogType logType)
        {
            //To do ...
        }
    }
}
