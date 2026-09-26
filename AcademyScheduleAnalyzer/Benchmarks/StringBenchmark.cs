using System.Text;
using BenchmarkDotNet.Attributes;

namespace AcademyScheduleAnalyzer.Benchmarks
{
    // Part 21
    [MemoryDiagnoser]
    public class StringBenchmark
    {
        // Part 22
        [Params(100, 1000)]
        public int Iterations;

        // Part 21 & Part 24
        [Benchmark]
        public string StringConcatenation()
        {
            string result = "";

            for (int i = 0; i < Iterations; i++)
            {
                result += "sample text ";
            }

            return result;
        }

        // Part 21 & Part 24
        [Benchmark]
        public string StringBuilderConcatenation()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Iterations; i++)
            {
                sb.Append("sample text ");
            }

            return sb.ToString();
        }
    }
}