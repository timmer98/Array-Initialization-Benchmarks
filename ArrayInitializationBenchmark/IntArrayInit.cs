using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace ArrayInitializationBenchmark
{
    public class IntArrayInit
    {
        [Params(500_000, 1_000_000)]
        public int ArraySize { get; set; }

        [Benchmark]
        public void OnlyInit()
        {
            int[] array = new int[ArraySize];
        }

        [Benchmark]
        public void LoopInit()
        {
            int[] array = new int[ArraySize];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 3;
            }
        }

        [Benchmark]
        public void EnumerableRepeat()
        {
            var array = Enumerable.Repeat(3, ArraySize).ToArray();
        }
    }
}
