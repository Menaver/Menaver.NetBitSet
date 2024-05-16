using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf.Bitwise;

public class NetBitSetBitwiseInvertPerfTestSuit : PerfTestSuitBase
{
    private NetBitSet _netBitSet = null!;

    // 1 kbit, 1 Mbit, 10 Mbit
    [Params(8192, 8388608, 83886080)] public ulong BitCount;

    [IterationSetup]
    public void Setup()
    {
        _netBitSet = BuildRandomNetBitSet(BitCount);
    }

    [Benchmark]
    public void InvertAll()
    {
        _netBitSet.InvertAll();
    }

    [Benchmark]
    public void ResetAll()
    {
        _netBitSet.ResetAll();
    }

    [Benchmark]
    public void SetAll()
    {
        _netBitSet.SetAll();
    }
}