using Newtonsoft.Json;
using System;

namespace blockchain_demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain phillyCoin = new Blockchain();
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:MaHesh,receiver:MaHesh,amount:5}"));

            Console.WriteLine(JsonConvert.SerializeObject(phillyCoin, Formatting.Indented));

            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");

            Console.WriteLine($"Update amount to 1000");
            phillyCoin.Chain[1].Data = "{sender:Henry,receiver:MaHesh,amount:1000}";
            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");

            Console.WriteLine($"Update hash for the 2rd block");
            phillyCoin.Chain[1].Hash = phillyCoin.Chain[1].CalculateHash();
            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");

            Console.WriteLine($"Update the entire chain");
            phillyCoin.Chain[2].PreviousHash = phillyCoin.Chain[1].Hash;
            phillyCoin.Chain[2].Hash = phillyCoin.Chain[2].CalculateHash();
            phillyCoin.Chain[3].PreviousHash = phillyCoin.Chain[2].Hash;
            phillyCoin.Chain[3].Hash = phillyCoin.Chain[3].CalculateHash();
            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
        }
    }
}
