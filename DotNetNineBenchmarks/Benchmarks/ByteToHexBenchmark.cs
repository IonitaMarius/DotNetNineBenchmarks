using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ByteToHexBenchmark
    {
        private byte[]? byteArray;
        private long length = 1000000;

        [GlobalSetup]
        public void Setup()
        {
            byteArray = RandomArray.GenerateRandomBytes(length);
        }

        [Benchmark]
        public string UnsafeSpanToHexadecimal()
        {
            return ByteToHex.UnsafeSpanToHexadecimal(byteArray!);
        }
    }
}
