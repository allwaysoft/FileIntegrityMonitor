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

        public void StartScan(string filePath, AvailableHashAlgorithms hashAlgorithm)
        {
            Scan scan = new Scan
            {
                FilePath = filePath,
                HashAlgorithm = new FIMHashAlgorithm { Id = (int)hashAlgorithm },
                Time = DateTime.Now
            };

            //insert scan in database

            List<string> allFiles = DirectoryParser.GetAllFiles(filePath, true);

            foreach (string file in allFiles)
            {
                try
                {
                    FileScan.ScanFile(filePath, scan);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message, LogType.Error);

                    continue;
                }
            }
        }

        public bool Insert()
        {
            return new DALScan().InsertScan(this);
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
