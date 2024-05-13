using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf.Bitwise;

[MinColumn]
[MaxColumn]
[HtmlExporter]
[MarkdownExporter]
public class NetBitSetBitWiseInvertPerfTestSuit
{
    private NetBitSet _netBitSet = null!;

    // 1 kbit, 1 Mbit, 10 Mbit
    [Params(8192, 8388608, 83886080)] public ulong BitCount;

    [GlobalSetup]
    public void Setup()
    {
        var byteCount = BitCount / 8;

        var data = new byte[byteCount];
        new Random().NextBytes(data);

        _netBitSet = new NetBitSet(data);
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