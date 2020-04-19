using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIntegrityMonitor.DTO;

namespace FileIntegrityMonitor.Console
{
    class Program
    {
        /*
         * -r, recursive
         * <filepath>
         * 
         * -a, list all scans
         * 
         * -c compare, scan with other scan
         *
         * -o "path", spit output to path
         * 
         * -d, directory followed by ""
         * 
         * fileintegritymonitor -r -o "C:\users\s\desktop\test.txt"
         */

        static void Main(string[] args)
        {
            SetDataBasePath();

            FIMAgent agent = new FIMAgent();

            agent.Run(args);

        }

        static void SetDataBasePath()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }
    }
}
