using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileIntegrityMonitor;
using FileIntegrityMonitor.DTO;

namespace FileIntegrityMonitor.Console
{
    public class IncorrectUsageException: Exception
    {
        public IncorrectUsageException()
        {

        }

        public IncorrectUsageException(string message) : base(message)
        {

        }

        public IncorrectUsageException(string messages, Exception inner) : base (messages, inner)
        {

        }
    }

    public class FIMAgent
    {
        private string SingleFileToScan { get; set; }
        private string DirectoryToScan { get; set; }
        private string OutputPath { get; set; }
        private bool Recursive { get; set; }
        private bool ListScans { get; set; }

        public void Run(string[] args)
        {
            try
            {
                this.ParseArguments(args);
                this.RunWithArguments();
            }
            catch (IncorrectUsageException ex)
            {
                System.Console.WriteLine("Incorrect usage: " + ex.Message);

                DisplayUsage();
            }
        }

        public bool ParseArguments(string[] args)
        {
            if (args.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < args.Length; i++)
            {
                string currentArg = args[i];
                string nextArg = "";

                if (i + 1 < args.Length)
                {
                    nextArg = args[i + 1];
                    System.Console.WriteLine(nextArg);
                }

                if (currentArg == "-o")
                {
                    if (string.IsNullOrWhiteSpace(nextArg))
                    {
                        throw new IncorrectUsageException(
                            "Output path must be given behind \"-o\" argument" +
                            " and must be enclosed in \" and \"!");
                    }

                    OutputPath = nextArg.Trim('\"');

                    i++;
                } 
                else if (currentArg == "-r")
                {
                    Recursive = true;
                } 
                else if (currentArg == "-a")
                {
                    ListScans = true;
                }
                else if (currentArg == "-c")
                {

                }
                else if (currentArg == "-d")
                {
                    if (string.IsNullOrWhiteSpace(nextArg))
                    {
                        throw new IncorrectUsageException(
                            "Directory path must be given behind \"-d\" argument" +
                            " and must be enclosed in \" and \"!");
                    }

                    DirectoryToScan = nextArg;

                    if (!Directory.Exists(DirectoryToScan))
                    {
                        throw new FileNotFoundException("Directory to scan not found!");
                    }

                    i++;
                }
                else if (currentArg == "-s")
                {
                    if (string.IsNullOrWhiteSpace(nextArg))
                    {
                        throw new IncorrectUsageException(
                            "File path must be given behind \"-d\" argument" +
                            " and must be enclosed in \" and \"!");
                    }

                    DirectoryToScan = nextArg;

                    if (!Directory.Exists(DirectoryToScan))
                    {
                        throw new FileNotFoundException("File to scan not found!");
                    }
                }
            }

            return true;
        }

     

        public void DisplayUsage()
        {

        }

        private void RunWithArguments()
        {
            if (!string.IsNullOrWhiteSpace(SingleFileToScan))
            {
                StartSingleFileScan();
            }
            else if (!string.IsNullOrWhiteSpace(DirectoryToScan))
            {
                StartScan();
            }
            else if (ListScans)
            {
                ListAllScans();
            }

        }

        private void StartSingleFileScan()
        {
            //FileScan.ScanFile()
        }

        private void StartScan()
        {
            if (!Directory.Exists(DirectoryToScan))
            {
                throw new FileNotFoundException("Directory to scan not found!");
            }

            Scan.StartScanConsole(DirectoryToScan, Recursive, AvailableHashAlgorithms.Sha512);


        }

        private void ListAllScans()
        {
            List<Scan> allScans = Scan.GetAllScans();

            if (!string.IsNullOrWhiteSpace(OutputPath))
            {
                WriteScansToOutputFile(allScans);
            }
            else
            {
                DisplayScansConsole(allScans);
            }

        }

        private void WriteScansToOutputFile(List<Scan> scans)
        {
            using (StreamWriter outputFile = new StreamWriter(OutputPath + ".csv"))
            {
                outputFile.WriteLine("Scan Id;File;Algorithm;Time");

                foreach (Scan scan in scans)
                {
                    outputFile.WriteLine(String.Format("%d;%s;%s;%s",
                    scan.FilePath, scan.HashAlgorithm.AlgorithmText,
                    String.Format("{0:dd/MM/yyyy HH:mm}", scan.Time)
                    ));
                }
            }
        }

        public void DisplayScansConsole(List<Scan> scans)
        {
            System.Console.WriteLine("Available Past Scans:");
            System.Console.WriteLine("====================================================");

            foreach (Scan scan in scans)
            {
                System.Console.WriteLine(String.Format("{0}\t\t{1}\t\t{2}\t\t{3}",
                    scan.Id, ShortenPath(scan.FilePath), scan.HashAlgorithm.AlgorithmText,
                    String.Format("{0:dd/MM/yyyy HH:mm}", scan.Time)
                    ));
            }
        }

        private string ShortenPath(string path)
        {
            if (path.Length > 20)
            {
                path = path.Substring(0, 7) + "..." + path.Substring(path.Length - 11, 10);
            }

            return path;
        }

    }
}
