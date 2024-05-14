using BenchmarkDotNet.Running;

namespace Menaver.NetBitSet.Tests.Perf;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}