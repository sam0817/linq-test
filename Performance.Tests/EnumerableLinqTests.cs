using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Ml.Mtp.Performance.Tests;

public class EnumerableLinqTests
{
    [Benchmark]
    public List<int> ToList() => Enumerable.Range(0, 1000).ToList();

    [Benchmark]
    public int[] ToArray() => Enumerable.Range(0, 1000).ToArray();

    [Benchmark]
    public int[] Array()
    {
        return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    }

    [Benchmark]
    public int[] ArrayToArray()
    {
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        return array.ToArray();
    }

    [Benchmark]
    public List<int> ArrayToList()
    {
        var a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        return a.ToList();
    }

    [Benchmark]
    public List<int> List()
    {
        return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    }

    [Benchmark]
    public List<int> ListToList()
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        return list.ToList();
    }

    [Benchmark]
    public int[] ListToArray()
    {
        var a = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        return a.ToArray();
    }
}
