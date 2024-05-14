using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf.LFSR;

public class LFSRShiftPerfTestSuit : PerfTestSuitBase
{
    private const int BitCount = 88;
    private readonly ulong[] Polynomial = { 11, 9, 8, 0 };

    private Menaver.NetBitSet.LFSR.LFSR _lfsr = null!;

    [Params(10000, 100000, 1000000)] public ulong ShiftCount;

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