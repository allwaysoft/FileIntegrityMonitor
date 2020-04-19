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
        private const string _partialSelect = @"SELECT [Id], [FilePath], [Checksum], [FileSize], 
[Time], [ScanId] FROM [FileScan]";

        public List<FileScan> SelectAllFileScansFromScan(int scanId)
        {
            return this.SelectMultipleRecords(_partialSelect + " WHERE [ScanId] = @ScanId;", 
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
            return this.ExecQueryOneRecord(@"INSERT INTO [FileScan] ([FilePath], [Checksum], [FileSize], [Time], 
[ScanId]) VALUES(@FilePath, @checksum, @FileSize, @Time, @ScanId);", new Dictionary<string, object>()
            {
                { "@Filepath", fileScan.FilePath },
                { "@Checksum", fileScan.Checksum },
                { "@FileSize", fileScan.FileSize },
                { "@Time", fileScan.Time },
                { "@ScanId", fileScan.ScanId }
            });
        }

        public FileScan GetLatestPreviousFileScan(DateTime latestTime, int hashAlgorithmId)
        {
            return this.SelectSingleRecord(@"SELECT TOP 1 [FileScan].[Id], [FilePath], [Checksum], [FileSize], 
[FileScan].[Time], [ScanId] FROM [FileScan] INNER JOIN [Scan] ON [FileScan].[ScanId] = [Scan].[Id] 
WHERE [FileScan].[Time] < @LatestTime AND [Scan].[HashAlgorithmId] = @HashAlgorithmId 
ORDER BY [TIME] DESC;",
            new Dictionary<string, object> { { "@LatestTime", latestTime },
                { "HashAlgorithmId", hashAlgorithmId } },
            this.GetFileScanFromReader);
        }
    }
}
