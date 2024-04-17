using System.Collections;
using Menaver.NetBitSet.Shared.Internals;

namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    private BitArray[] _containers;

    public byte WordLength { get; }

    public Endian Endianness { get; }

    public ulong Count =>
        _containers.Aggregate<BitArray, ulong>(0, (current, bitArray) => current + (ulong)bitArray!.Length);

    public ulong BlockCount
    {
        get
        {
            if (WordLength == 0)
            {
                return 0;
            }

            return Count / WordLength;
        }
    }

    public double ByteCount => (double)Count / (byte)Extras.WordLength.Eight;
}