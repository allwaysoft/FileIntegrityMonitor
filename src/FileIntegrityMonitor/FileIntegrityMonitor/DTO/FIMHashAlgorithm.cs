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
        public AvailableHashAlgorithms AlgorithmEnum { get { return (AvailableHashAlgorithms)Id; } }
        public HashAlgorithm Algorithm
        {
            get {
                HashAlgorithm algorithm = new SHA256Managed();

                if (AlgorithmEnum == AvailableHashAlgorithms.Sha512)
                {
                    algorithm = new SHA512Managed();
                }

                return algorithm;
            }
        }
        public string AlgorithmText { get { return AlgorithmEnum.ToString(); } }
    }
}
