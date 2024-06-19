using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BubbleSortBenchmark
    {
        private string input = string.Empty;
        private long length = 10000;

        [GlobalSetup]
        public void Setup()
        {
            input = ByteToHex.UnsafeSpanToHexadecimal(RandomArray.GenerateRandomBytes(length));
        }

        [Benchmark]
        public void BenchmarkBubbleSort()
        {
            BubbleSort.Sort(GenerateSuffixes.UnsafeWhileFromSpan(input.AsSpan()));
        }
    }
}
