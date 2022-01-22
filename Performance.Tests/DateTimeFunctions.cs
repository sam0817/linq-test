using System;
using BenchmarkDotNet.Attributes;

namespace Ml.Mtp.Performance.Tests
{
    public class DateTimeFunctions
    {
        // * Summary *
        // BenchmarkDotNet=v0.12.1, OS=ubuntu 20.04
        // Intel Xeon CPU 2.20GHz, 1 CPU, 2 logical cores and 1 physical core
        //     .NET Core SDK=3.1.403
        // [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
        // DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
        // |      Method |     Mean |    Error |   StdDev |
        // |------------ |---------:|---------:|---------:|
        // | Eom_Method1 | 68.77 ns | 0.574 ns | 0.509 ns |
        // | Eom_Method2 | 90.37 ns | 0.454 ns | 0.379 ns |
        // | Eom_Method3 | 68.10 ns | 0.508 ns | 0.475 ns |
        // BenchmarkDotNet=v0.12.1, OS=ubuntu 20.04
        // Intel Xeon CPU 2.20GHz, 1 CPU, 2 logical cores and 1 physical core
        //     .NET Core SDK=3.1.403
        // [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
        // DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
        // |      Method |     Mean |    Error |   StdDev |   Median |
        // |------------ |---------:|---------:|---------:|---------:|
        // | Eom_Method1 | 70.08 ns | 1.382 ns | 1.293 ns | 71.14 ns |
        // | Eom_Method2 | 90.19 ns | 0.315 ns | 0.263 ns | 90.11 ns |
        // | Eom_Method3 | 68.14 ns | 0.516 ns | 0.458 ns | 67.93 ns |

        // BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1457 (1809/October2018Update/Redstone5)
        // Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
        //     .NET Core SDK=3.1.202
        // [Host]     : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT
        // DefaultJob : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT
        // |      Method |     Mean |    Error |   StdDev |   Median |
        // |------------ |---------:|---------:|---------:|---------:|
        // | Eom_Method1 | 210.3 ns | 12.10 ns | 35.69 ns | 216.1 ns |
        // | Eom_Method2 | 277.7 ns | 13.22 ns | 38.97 ns | 285.6 ns |
        // | Eom_Method3 | 197.4 ns |  9.82 ns | 28.97 ns | 205.6 ns |

        private static readonly DateTime _date = new(2020, 10, 10);

        [Benchmark]
        public DateTime Eom_Method1()
        {
            var year = _date.Month == 12 ? _date.Year + 1 : _date.Year;
            var month = _date.Month == 12 ? 1 : _date.Month + 1;
            return new DateTime(year, month, 1).AddDays(-1);
        }

        [Benchmark]
        public DateTime Eom_Method2()
        {
            return new DateTime(_date.Year, _date.Month, 1).AddMonths(1).AddDays(-1);
        }

        [Benchmark]
        public DateTime Eom_Method3()
        {
            return new(_date.Year, _date.Month, DateTime.DaysInMonth(_date.Year, _date.Month));
        }
    }
}
