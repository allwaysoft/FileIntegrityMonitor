using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FileIntegrityMonitor.DTO
{
    public enum AvailableHashAlgorithms
    {
        Sha256 = 1,
        Sha512 = 2
    }

    public class FIMHashAlgorithm
    {
        public int Id { get; set; }
        public string AlgorithmText { get; set; }

        public HashAlgorithm Algorithm
        {
            get {
                HashAlgorithm algorithm = new SHA256Managed();

                if (AlgorithmText.ToLower() == "sha512")
                {
                    algorithm = new SHA512Managed();
                }

                return algorithm;
            }
        }
    }
}
