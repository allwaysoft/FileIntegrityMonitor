using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIntegrityMoniror.Console
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
            FIMAgent agent = new FIMAgent();
            agent.ParseArguments(args);

        }


    }
}
