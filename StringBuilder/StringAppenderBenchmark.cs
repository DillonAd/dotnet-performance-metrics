using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringBuilderBenchmark
{
    [HtmlExporter, CsvExporter]
    public class StringAppenderBenchmark
    {
        private readonly int _maxIterations;
        private readonly int _defaultStringLength;
        private readonly string _defaultString;

        public IEnumerable<int> Iterations
        {
            get
            {
                for(int i = 0; i < _maxIterations; i++)
                {
                    yield return i;
                }
            }
        }

        public StringAppenderBenchmark()
        {
            _maxIterations = 15;
            _defaultStringLength = 20;

            var randomString = new char[_defaultStringLength];
            var random = new Random();

            for(int i = 0; i < randomString.Length; i++)
            {
                randomString[i] = (char)random.Next(97, 122);
            }

            _defaultString = new string(randomString);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Iterations))]
        public void StringBuilderObject(int iterations)
        {
            var sb = new StringBuilder();

            for(int i = 0; i <= iterations; i++)
            {
                sb.Append(_defaultString);
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Iterations))]
        public void ConcatenationWithPlus(int iterations)
        {
            var s = string.Empty;

            for(int i = 0; i <= iterations; i++)
            {
                s += _defaultString;
            }
        }
    }
}