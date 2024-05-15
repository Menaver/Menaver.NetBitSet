using BenchmarkDotNet.Running;

namespace Menaver.NetBitSet.Tests.Perf;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Any())
        {
            var types = typeof(Program).Assembly.GetTypes().Where(type => args.Contains(type.Name)).ToList();

            foreach (var type in types)
            {
                BenchmarkRunner.Run(type);
            }
        }
        else
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}