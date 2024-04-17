using System.Collections;
using Menaver.NetBitSet.Shared.Extras;

namespace Menaver.NetBitSet.Shared.Interfaces;

/// <summary>
///     Represents an abstraction of a bit-level data structure.
/// </summary>
public interface INetBitSet : INetBitSetBitwise, INetBitSetConvertible, ICollection, ICloneable
{
    byte WordLength { get; }

    Endian Endianness { get; }

    ulong Count { get; }

    ulong BlocksCount { get; }

    double BytesCount { get; }

    Bit this[ulong index] { get; set; }

    void Resize(ulong newSize);
}