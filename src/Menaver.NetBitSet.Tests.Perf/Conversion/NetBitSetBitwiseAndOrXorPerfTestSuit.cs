using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf.Conversion;

public class NetBitSetConversionPerfTestSuit : PerfTestSuitBase
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
    public void ConvertToBools()
    {
        _ = _netBitSet.ToBools();
    }

    [Benchmark]
    public void ConvertToBytes()
    {
        _ = _netBitSet.ToBytes();
    }

    [Benchmark]
    public void ConvertToSBytes()
    {
        _ = _netBitSet.ToSBytes();
    }

    [Benchmark]
    public void ConvertToShorts()
    {
        _netBitSet.WordLength = WordLength.Sixteen;

        _ = _netBitSet.ToShorts();
    }

    [Benchmark]
    public void ConvertToUShorts()
    {
        _netBitSet.WordLength = WordLength.Sixteen;

        _ = _netBitSet.ToUShorts();
    }

    [Benchmark]
    public void ConvertToInts()
    {
        _netBitSet.WordLength = WordLength.ThirtyTwo;

        _ = _netBitSet.ToInts();
    }

    [Benchmark]
    public void ConvertToUInts()
    {
        _netBitSet.WordLength = WordLength.ThirtyTwo;

        _ = _netBitSet.ToUInts();
    }

    [Benchmark]
    public void ConvertToLongs()
    {
        _netBitSet.WordLength = WordLength.SixtyFour;

        _ = _netBitSet.ToLongs();
    }

    [Benchmark]
    public void ConvertToULongs()
    {
        _netBitSet.WordLength = WordLength.SixtyFour;

        _ = _netBitSet.ToULongs();
    }

    [Benchmark]
    public void ConvertToDoubles()
    {
        _netBitSet.WordLength = WordLength.SixtyFour;

        _ = _netBitSet.ToDoubles();
    }

    [Benchmark]
    public void ConvertToBinaryString()
    {
        _ = _netBitSet.ToBinaryString();
    }
}