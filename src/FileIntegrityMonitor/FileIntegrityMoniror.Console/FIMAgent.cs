using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIntegrityMoniror.Console
{
    public class FIMAgent
    {
        public void ParseArguments(string[] args)
        {
            if (args.Length < 2)
            {
                return;
            }

            string outputPath = "";
            bool recursive = false;
            bool listScans = false;

            for (int i = 0; i < args.Length; i++)
            {
                string currentArg = args[i];
                string nextArg = "";

                if (i + 1 < args.Length)
                {
                    nextArg = args[i + 1];
                }

                if (currentArg == "-o")
                {
                    if (string.IsNullOrWhiteSpace(nextArg) ||
                        !nextArg.StartsWith("\"") ||
                        !nextArg.EndsWith("\""))
                    {
                        DisplayUsage();
                        return;
                    }

                    outputPath = nextArg.Trim('\"');

                    if (!Directory.Exists(outputPath))
                    {
                        DisplayUsage();
                        return;
                    }

                    outputPath = nextArg;
                    i++;
                } 
                else if (currentArg == "-r")
                {
                    recursive = true;
                } 
                else if (currentArg == "-a")
                {
                    listScans = true;
                }
                else if (currentArg == "-c")
                {

                }
                else if (currentArg == "-d")
                {
                    if (string.IsNullOrWhiteSpace(nextArg))
                    {
                        DisplayUsage();
                        return;
                    }

                    i++;
                }

            }
        }

        public void DisplayUsage()
        {

        }
    }
}
