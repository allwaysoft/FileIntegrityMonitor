using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileIntegrityMonitor.DAL;

namespace FileIntegrityMonitor.DTO
{
    public class Scan
    {
        public int Id { get; set; }
        public string FilePath { get; set; } //Can be folder or file!
        public FIMHashAlgorithm HashAlgorithm { get; set; }
        public DateTime Time { get; set; }

        public static void StartSingleFileScan(string filePath, AvailableHashAlgorithms hashAlgorithm)
        {
            Scan scan = new Scan
            {
                FilePath = filePath,
                HashAlgorithm = new FIMHashAlgorithm { Id = (int)hashAlgorithm },
                Time = DateTime.Now
            };

            try
            {
                FileScan.ScanFile(filePath, scan);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, LogType.Error);
            }
        }

        public static void StartScanConsole(string filePath, bool recursive, AvailableHashAlgorithms hashAlgorithm)
        {
            Scan scan = new Scan
            {
                FilePath = filePath,
                HashAlgorithm = new FIMHashAlgorithm { Id = (int)hashAlgorithm },
                Time = DateTime.Now
            };

            scan.Insert();

            //insert scan in database

            List<string> allFiles = DirectoryParser.GetAllFiles(filePath, recursive);

            int nFiles = allFiles.Count;
            int i = 0;
            Console.WriteLine("Scanning ...");
            foreach (string file in allFiles)
            {
                try
                {
                    FileScan.ScanFile(file, scan);
                    
                    Console.WriteLine(Math.Ceiling(((double)i / nFiles) * 100).ToString() + "%");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    System.Threading.Thread.Sleep(50);
                    i++;
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message, LogType.Error);

                    continue;
                }
            }
        }

        public void CompareAllFilesFromLatestScanWithAllPreviousFileScans()
        {
            List<FileScan> allFileScans = FileScan.GetAllFileScansFromScan(this.Id);
            //Logger.Log("Changed Files\n");

            foreach (FileScan fileScan in allFileScans)
            {
                FileScan other = FileScan.GetLatestPreviousFileScan(fileScan.Time, this.HashAlgorithm);

                if (other == null)
                {
                    Logger.Log("PREVIOUSLY NOT FOUND;;" + fileScan.FilePath,
                        LogType.Warning);

                    continue;
                }

                if (fileScan.Checksum != other.Checksum)
                {
                    string log = String.Format("CHANGED FILE;{0}",
                        fileScan.FilePath);
                    Logger.Log(log, LogType.Notification);
                }
            }
        }

        public void Insert()
        {
            this.Id = new DALScan().InsertScan(this);
        }

        public bool Delete()
        {
            return new DALScan().DeleteScan(this);
        }

        public static List<Scan> GetAllScans()
        {
            return new DALScan().SelectAllScans();
        }

        public static Scan GetScan(int id)
        {
            return new DALScan().SelectScan(id);
        }
    }
}
