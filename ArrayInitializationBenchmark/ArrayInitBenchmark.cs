using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace ArrayInitializationBenchmark
{
    [MemoryDiagnoser]
    public class ArrayInitBenchmark
    {
        [Params(500_000, 1_000_000)]
        public int ArraySize { get; set; }

        [Benchmark]
        public void OnlyInit()
        {
            bool[] array = new bool[ArraySize];
        }

        [Benchmark]
        public void LoopInit()
        {
            bool[] array = new bool[ArraySize];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = true;
            }
        }

        [Benchmark]
        public void EnumerableRepeat()
        {
            var array = Enumerable.Repeat(true, ArraySize).ToArray();
        }
    }
}