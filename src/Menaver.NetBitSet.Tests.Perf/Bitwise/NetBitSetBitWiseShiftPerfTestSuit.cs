using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf.Bitwise;

[MinColumn]
[MaxColumn]
[HtmlExporter]
[MarkdownExporter]
public class NetBitSetBitWiseShiftPerfTestSuit
{
    private const int ShiftCount = 100;

    private NetBitSet _netBitSet = null!;

    // 1 kbit, 100 kbit, 1 Mbit
    [Params(8192, 819200, 8388608)] public ulong BitCount;

    [GlobalSetup]
    public void Setup()
    {
        var byteCount = BitCount / 8;

        var data = new byte[byteCount];
        new Random().NextBytes(data);

        _netBitSet = new NetBitSet(data);
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
}