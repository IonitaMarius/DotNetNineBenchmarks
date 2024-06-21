using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class MergeSortBenchmark
    {
        private int[] data = null;
        private const int length = 100000; 

        [GlobalSetup]
        public void Setup()
        {
            data = RandomArray.GenerateRandomInts(length);
        }

        [Benchmark]
        public void BenchmarkMergeSort()
        {
            MergeSort.Sort(ref data);
        }
    }
}
