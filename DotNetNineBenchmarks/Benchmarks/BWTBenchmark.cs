using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DotNetNineBenchmarks.Algorithms;

namespace DotNetNineBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BWTBenchmark
    {
        private string input = string.Empty;
        private long length = 1000000;

        [GlobalSetup]
        public void Setup()
        {
            input = ByteToHex.UnsafeSpanToHexadecimal(RandomArray.GenerateRandomBytes(length));
        }

        [Benchmark]
        public string BwtTransform()
        {
            return BWT.Transform(input);
        }
    }
}
