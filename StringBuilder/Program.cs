using BenchmarkDotNet.Running;
using System;

namespace StringBuilderBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringAppenderBenchmark>();
        }
    }
}
