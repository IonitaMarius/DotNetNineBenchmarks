using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkGenerateSuffixes
    {
        private string input = string.Empty;
        private long length = 50000;

        [GlobalSetup]
        public void Setup()
        {
            input = ByteToHex.UnsafeSpanToHexadecimal(RandomArray.GenerateRandomBytes(length));
        }

        [Benchmark]
        public string[] UnsafeWhileFromSpan()
        {
            return GenerateSuffixes.UnsafeWhileFromSpan(input.AsSpan());
        }
    }
}
