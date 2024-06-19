using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class RandomArrayBenchmark
    {
        private const long Length = 100000;

        [Benchmark]
        public byte[] GenerateRandomBytes()
        {
            return RandomArray.GenerateRandomBytes(Length);
        }

        [Benchmark]
        public int[] GenerateRandomInts()
        {
            return RandomArray.GenerateRandomInts(Length);
        }
    }
}
