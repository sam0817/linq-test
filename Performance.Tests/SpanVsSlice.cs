using System;
using BenchmarkDotNet.Attributes;

namespace Ml.Mtp.Performance.Tests;

//    |                     Method |     Mean |    Error |   StdDev |
//    |--------------------------- |---------:|---------:|---------:|
//    |        ParseDateUsingSplit | 60.14 ns | 0.311 ns | 0.243 ns |
//    |       ParseDateUsingString | 26.79 ns | 0.242 ns | 0.215 ns |
//    | ParseDateUsingReadOnlySpan | 31.69 ns | 0.337 ns | 0.315 ns |

//    |                     Method |     Mean |    Error |   StdDev |
//    |--------------------------- |---------:|---------:|---------:|
//    |        ParseDateUsingSplit | 60.29 ns | 0.653 ns | 0.579 ns |
//    |       ParseDateUsingString | 27.03 ns | 0.271 ns | 0.240 ns |
//    | ParseDateUsingReadOnlySpan | 31.10 ns | 0.343 ns | 0.267 ns |


public class SpanVsSlice
{
    static string date = "2022-04-15";

    [Benchmark]
    public (string, string, string) ParseDateUsingSplit()
    {
        var split = date.Split("-");
        var y = split[0];
        var m = split[1];
        var d = split[2];

        return (y, m, d);
    }

    [Benchmark]
    public (string, string, string) ParseDateUsingString()
    {
        var y = date[0..4];
        var m = date[5..7];
        var d = date[8..];

        return (y, m, d);
    }

    [Benchmark]
    public (string, string, string) ParseDateUsingReadOnlySpan()
    {
        ReadOnlySpan<char> nameAsSpan = date.AsSpan();

        var y = nameAsSpan.Slice(0, 4);
        var m = nameAsSpan.Slice(5, 2);
        var d = nameAsSpan.Slice(8);

        return (y.ToString(), m.ToString(), d.ToString());
    }
}
