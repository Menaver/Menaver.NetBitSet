using System.Collections;
using Menaver.NetBitSet.Shared.Extras;

namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    private BitArray _container;

    public byte WordLength { get; }

    public Endian Endianness { get; }

    public ulong Count => (ulong)_container.Length;

    public ulong BlocksCount
    {
        get
        {
            if (WordLength == 0)
            {
                return 0;
            }

            return (ulong)(_container.Length / WordLength);
        }
    }

    public double BytesCount => (double)_container.Count / (byte)Extras.WordLength.Eight;

    public object SyncRoot => _container.SyncRoot;

    public bool IsSynchronized => _container.IsSynchronized;
}