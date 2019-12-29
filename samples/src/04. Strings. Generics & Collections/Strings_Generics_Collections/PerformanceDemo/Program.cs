using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace PerformanceDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<GenericsBenchmark>();
            Console.ReadLine();
        }
    }
}
