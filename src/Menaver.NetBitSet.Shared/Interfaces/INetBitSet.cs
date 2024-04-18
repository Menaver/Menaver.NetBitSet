namespace Menaver.NetBitSet.Shared.Interfaces;

/// <summary>
///     Represents an abstraction of a bit-level data structure.
/// </summary>
public interface INetBitSet : INetBitSetBitwise, INetBitSetConvertible, IEnumerable<Bit>, ICloneable
{
    /// <summary>
    ///     The fixed length of a stored data unit, defined by its data type, in bits.
    ///     If the stored data does not have a fixed length, the WordLength would be WordLength.NotFixed.
    /// </summary>
    WordLength WordLength { get; }

    /// <summary>
    ///     The order in which bytes within a word of data are read.
    /// </summary>
    Endian Endianness { get; }

    /// <summary>
    ///     The number of bits stored.
    /// </summary>
    ulong Count { get; }

    /// <summary>
    ///     The number of words stored.
    ///     If WordLength is NotFixed, the this property would return 1 as the whole structure is one single word.
    /// </summary>
    ulong WordCount { get; }

    /// <summary>
    ///     The number of bytes stored.
    /// </summary>
    double ByteCount { get; }

    /// <summary>
    ///     The indexer.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns>The bit stored by the index specified.</returns>
    Bit this[ulong index] { get; set; }

    /// <summary>
    ///     Resized the structure: reduces or extends depending on the parameter value.
    /// </summary>
    /// <param name="newSize">The new size, in bits.</param>
    void Resize(ulong newSize);
}