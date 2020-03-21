using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIntegrityMonitor
{
    public class DirectoryParser
    {
        public static List<String> GetAllFiles(string directoryPath, bool isRecursive = true)
        {
            List<String> filePaths = new List<string>();

            filePaths = GetAllFilesFromDirectory(directoryPath, isRecursive);

            return filePaths;
        }

        public static List<String> GetAllFilesFromDirectory(string directoryPath, bool isRecursive = true)
        {
            List<String> files = new List<String>();

            foreach (string filePath in Directory.GetFiles(directoryPath))
            {
                if (Directory.Exists(filePath) && isRecursive)
                {
                    List<String> filesInDirectory = GetAllFilesFromDirectory(filePath, true);

                    foreach (string fileInDirectory in filesInDirectory)
                    {
                        files.Add(fileInDirectory);
                    }
                }

                files.Add(filePath);
            }

            return files;
        }
    }
}
