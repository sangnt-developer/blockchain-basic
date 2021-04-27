using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace blockchain_demo1
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }

        public Block(DateTime timeStamp, string previousHash, string data)
        {
            Index = 0;
            TimeStamp = timeStamp;
            PreviousHash = previousHash;
            Data = data;
            Hash = CalculateHash();

        }

        public string CalculateHash()
        {
            var unhashedString = $"{TimeStamp}-{PreviousHash ?? ""}-{Data}";
            byte[] inputBytes = Encoding.ASCII.GetBytes(unhashedString);

            SHA256 sha256 = SHA256.Create();
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}
