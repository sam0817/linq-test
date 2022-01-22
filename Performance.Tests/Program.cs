using System;
using BenchmarkDotNet.Running;

namespace Ml.Mtp.Performance.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            // 日期計算測試
            // BenchmarkRunner.Run<DateTimeFunctions>();

             BenchmarkRunner.Run<EnumerableLinqTests>();

        }
    }
}
