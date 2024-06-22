using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ThreeWayMergeSortBenchmark
    {
        private int[] data = null;
        private const int length = 100000;

        [GlobalSetup]
        public void Setup()
        {
            data = RandomArray.GenerateRandomInts(length);
        }

        [Benchmark]
        public void BenchmarkThreeWayMergeSort()
        {
            ThreeWayMergeSort.Sort(ref data);
        }
    }
}
