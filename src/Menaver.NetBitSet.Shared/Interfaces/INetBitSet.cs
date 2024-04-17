using Menaver.NetBitSet.Shared.Internals;

namespace Menaver.NetBitSet.Shared.Interfaces;

/// <summary>
///     Represents an abstraction of a bit-level data structure.
/// </summary>
public interface INetBitSet : INetBitSetBitwise, INetBitSetConvertible, IEnumerable<Bit>, ICloneable
{
    byte WordLength { get; }

    Endian Endianness { get; }

    ulong Count { get; }

    ulong BlockCount { get; }

    double ByteCount { get; }

    Bit this[ulong index] { get; set; }

    void Resize(ulong newSize);
}