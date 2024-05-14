using BenchmarkDotNet.Attributes;

namespace Menaver.NetBitSet.Tests.Perf;

[MinColumn]
[MaxColumn]
[MarkdownExporter]
public abstract class PerfTestSuitBase
{
    protected NetBitSet BuildRandomNetBitSet(ulong bitCount)
    {
        var byteCount = bitCount / 8;

        var data = new byte[byteCount];
        new Random(DateTime.Now.Microsecond).NextBytes(data);

        var netBitSet = new NetBitSet(data);

        return netBitSet;
    }

    protected Menaver.NetBitSet.LFSR.LFSR BuildRandomLFSR(ulong bitCount, ulong[] polynomial)
    {
        var netBitSet = BuildRandomNetBitSet(bitCount);

        var lfsr = new Menaver.NetBitSet.LFSR.LFSR(netBitSet, polynomial);

        return lfsr;
    }
}