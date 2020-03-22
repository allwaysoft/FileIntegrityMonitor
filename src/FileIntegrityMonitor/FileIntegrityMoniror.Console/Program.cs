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

            Scan.StartSingleFileScan(@"C:\Program Files\Common Files\microsoft shared\ClickToRun\Updates\16.0.12527.20278\OfficeClickToRun.exe", 
                AvailableHashAlgorithms.Sha512);

            FIMAgent agent = new FIMAgent();

            agent.Run(args);

        }


    }
}
