using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Ml.Mtp.Performance.Tests;

// // * Summary *
//
// BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1586 (20H2/October2020Update)
// Intel Core i7-9700 CPU 3.00GHz, 1 CPU, 8 logical and 8 physical cores
//     .NET SDK=6.0.201
//     [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
// DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
//
//
//     | Method |     Mean |     Error |    StdDev |
//     |------- |---------:|----------:|----------:|
//     |    Any | 1.408 us | 0.0093 us | 0.0077 us |
//     |  Count | 6.727 us | 0.0390 us | 0.0345 us |
//
//     // * Hints *
//     Outliers
// LinqAnyVsCountTests.Any: Default   -> 2 outliers were removed (1.44 us, 1.56 us)
// LinqAnyVsCountTests.Count: Default -> 1 outlier  was  removed (7.25 us)
//
// // * Legends *
// Mean   : Arithmetic mean of all measurements
// Error  : Half of 99.9% confidence interval
// StdDev : Standard deviation of all measurements
// 1 us   : 1 Microsecond (0.000001 sec)

public class LinqAnyVsCountTests
{
    private readonly List<int> _data;

    public LinqAnyVsCountTests()
    {
        _data = new List<int>(1000);
        for (int i = 0; i < 1000; i++) _data.Add(i);
    }

    [Benchmark]
    public void Any() { _data.Any(t => t > 200); }

    [Benchmark]
    public void Count() { _data.Count(t => t > 200); }
}
