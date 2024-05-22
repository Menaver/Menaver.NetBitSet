using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf.LFSR;

public class LFSRShiftPerfTestSuit : PerfTestSuitBase
{
    private const int BitCount = 64;
    private readonly ulong[] Polynomial = { 4, 3, 1, 0 };

    private Menaver.NetBitSet.LFSR.LFSR _lfsr = null!;

    [Params(100000, 1000000, 10000000)] public ulong ShiftCount;

    [IterationSetup]
    public void Setup()
    {
        _lfsr = BuildRandomLFSR(BitCount, Polynomial);
    }

    [Benchmark]
    public void Shift()
    {
        for (ulong i = 0; i < ShiftCount; i++)
        {
            _lfsr.Shift();
        }
    }

    [Benchmark]
    public void ShiftByCount()
    {
        _lfsr.Shift(ShiftCount);
    }
}