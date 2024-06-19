using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BinarySearchBenchmark
    {
        private int[] sortedArray = null;
        private long length = 100000;
        private int target = 32342;

        [GlobalSetup]
        public void Setup()
        {
            sortedArray = RandomArray.GenerateRandomInts(length);
        }

        [Benchmark]
        public int SearchTest()
        {
            return BinarySearch.Search(sortedArray.AsSpan(), target);
        }
    }
}
