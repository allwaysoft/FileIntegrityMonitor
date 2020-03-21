using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIntegrityMonitor.DAL;

namespace FileIntegrityMonitor.DTO
{
    public class FileScan
    {
        public long Id { get; set; }
        public string FilePath { get; set; }
        public string Checksum { get; set; }
        public long FileSize { get; set; }
        public DateTime Time { get; set; }

        public int ScanId { get; set; }
        public Scan Scan { get; set; }

        public bool CompareFileChecksums(FileScan other)
        {
            return (other != null 
                && !string.IsNullOrEmpty(this.Checksum) && !string.IsNullOrEmpty(other.Checksum)
                && this.Checksum == other.Checksum);
        }

        public static void ScanFile(string filePath, Scan scan)
        {
            string checksum = FileChecksumCreator.GetFileChecksum(filePath, scan.HashAlgorithm.Algorithm);
            int fileSize = 0; //Leave open for now!

            FileScan fileScan = new FileScan
            {
                FilePath = filePath,
                Checksum = checksum,
                FileSize = fileSize,
                ScanId = scan.Id,
            };

            if (!fileScan.Insert())
            {
                throw new Exception("Unknown error: the file checksum could not be stored in the database!");
            }
        }

 
        private bool Insert()
        {
            return new DALFileScan().InsertFileScan(this);
        }
    }
}
