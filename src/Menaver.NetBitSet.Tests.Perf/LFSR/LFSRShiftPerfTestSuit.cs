using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf.LFSR;

[MinColumn]
[MaxColumn]
[HtmlExporter]
[MarkdownExporter]
public class LFSRShiftPerfTestSuit
{
    private const int byteCount = 88;
    private readonly ulong[] polynomial = { 11, 9, 8, 0 };

    private Menaver.NetBitSet.LFSR.LFSR _lfsr = null!;

    [Params(100, 1000, 10000)] public ulong ShiftCount;

    [GlobalSetup]
    public void Setup()
    {
        var data = new byte[byteCount];
        new Random().NextBytes(data);

        var netBitSet = new NetBitSet(data);
        _lfsr = new Menaver.NetBitSet.LFSR.LFSR(netBitSet, polynomial);
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
    public void ShiftWithCount()
    {
        _lfsr.Shift(ShiftCount);
    }
}