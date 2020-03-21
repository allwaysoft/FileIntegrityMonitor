using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FileIntegrityMonitor.DTO;

namespace FileIntegrityMonitor.DAL
{
    class DALFileScan : DALBase<FileScan>
    {
        public List<FileScan> SelectAllFileScansFromScan(int scanId)
        {
            return this.SelectMultipleRecords(@"SELECT [Id], [FilePath], [Checksum], [FileSize], 
[Time], [ScanId] FROM [FileScan] WHERE [ScanId] = @ScanId;", 
                new Dictionary<string, object>() { { "@ScanId", scanId } }, this.GetFileScanFromReader);
        }

        private FileScan GetFileScanFromReader(SqlDataReader reader)
        {
            return new FileScan
            {
                Id = Convert.ToInt32(reader["Id"]),
                FilePath = Convert.ToString(reader["FilePath"]),
                FileSize = Convert.ToInt64(reader["FileSize"]),
                Checksum = Convert.ToString(reader["Checksum"]),
                Time = Convert.ToDateTime(reader["Time"]),
                ScanId = Convert.ToInt32(reader["ScanId"])
            };
        }

        public bool InsertFileScan(FileScan fileScan)
        {
            return this.ExecQueryOneRecord(@"INSERT INTO [FileeScan] ([FilePath], [Checksum], [FileSize], [Time], 
[ScanId]) VALUES(@FilePath, @checksum, @FileSize, @Time, @ScanId);", new Dictionary<string, object>()
            {
                { "@Filepath", fileScan.FilePath },
                { "@Checksum", fileScan.Checksum },
                { "@FileSize", fileScan.FileSize },
                { "@Time", fileScan.Time },
                { "@ScanId", fileScan.ScanId }
            });
        }
    }
}
