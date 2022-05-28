
using BenchmarkDotNet.Running;

namespace ArrayInitializationBenchmark
{
    public class Program
    {
        public static void Main()
        {
            var summary = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
        }
    }
}