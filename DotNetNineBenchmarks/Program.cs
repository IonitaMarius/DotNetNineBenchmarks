using BenchmarkDotNet.Running;
using DotNetNineBenchmarks.Algorithms;
using DotNetNineBenchmarks.Benchmarks;

namespace DotNetNineBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<RandomArrayBenchmark>();
            //BenchmarkRunner.Run<ByteToHexBenchmark>();
            //BenchmarkRunner.Run<BWTBenchmark>();
            //BenchmarkRunner.Run<BenchmarkGenerateSuffixes>();
            //BenchmarkRunner.Run<BubbleSortBenchmark>();
            //BenchmarkRunner.Run<InsertionSortBenchmark>();
            //BenchmarkRunner.Run<BinarySearchBenchmark>();
            //BenchmarkRunner.Run<MergeSortBenchmark>();
            //BenchmarkRunner.Run<ThreeWayMergeSortBenchmark>();
            BenchmarkRunner.Run<TimSortBenchmark>();
        }
    }
}
