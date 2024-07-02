using BenchmarkDotNet.Attributes;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    public class TimSortBenchmark
    {
        private string input = string.Empty;
        private long length = 10000;

        [GlobalSetup]
        public void Setup()
        {
            input = ByteToHex.UnsafeSpanToHexadecimal(RandomArray.GenerateRandomBytes(length));
        }

        [Benchmark]
        public void TestTimSort()
        {
            TimSort.Sort(GenerateSuffixes.UnsafeWhileFromSpan(input.AsSpan()));
        }

        //[Benchmark]
        //public void TestTimSortV1()
        //{
        //    TimSort.SortV1(GenerateSuffixes.UnsafeWhileFromSpan(input.AsSpan()));
        //}
    }
}
