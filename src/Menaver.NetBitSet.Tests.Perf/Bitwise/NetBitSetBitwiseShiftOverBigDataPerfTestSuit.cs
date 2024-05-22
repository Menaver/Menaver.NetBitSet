using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf.Bitwise;

public class NetBitSetBitwiseShiftOverBigDataPerfTestSuit : PerfTestSuitBase
{
    private const int ShiftCount = 3;

    private NetBitSet _netBitSet = null!;

    // 1 kbit, 1 Mbit, 10 Mbit
    [Params(8192, 8388608, 83886080)] public ulong BitCount;

    [IterationSetup]
    public void Setup()
    {
        _netBitSet = BuildRandomNetBitSet(BitCount);
    }

    [Benchmark]
    public void ShiftLeft()
    {
        _netBitSet.ShiftLeft(ShiftCount, Bit.True);
    }

    [Benchmark]
    public void ShiftRight()
    {
        _netBitSet.ShiftRight(ShiftCount, Bit.True);
    }

    [Benchmark]
    public void ArithmeticShiftLeft()
    {
        _netBitSet.ArithmeticShiftLeft(ShiftCount);
    }

    [Benchmark]
    public void ArithmeticShiftRight()
    {
        _netBitSet.ArithmeticShiftRight(ShiftCount);
    }

    [Benchmark]
    public void LogicalShiftLeft()
    {
        _netBitSet.LogicalShiftLeft(ShiftCount);
    }

    [Benchmark]
    public void LogicalShiftRight()
    {
        _netBitSet.LogicalShiftRight(ShiftCount);
    }

    [Benchmark]
    public void CircularShiftLeft()
    {
        _netBitSet.CircularShiftLeft(ShiftCount);
    }

    [Benchmark]
    public void CircularShiftRight()
    {
        _netBitSet.CircularShiftRight(ShiftCount);
    }
}