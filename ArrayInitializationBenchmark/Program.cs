
using BenchmarkDotNet.Running;

namespace ArrayInitializationBenchmark
{
    public class Program
    {
        public static void Main()
        {
            var summary = BenchmarkRunner.Run<ArrayInitBenchmark>();
        }
    }
}