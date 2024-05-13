using System.Collections;
using Menaver.NetBitSet.Internals;

namespace Menaver.NetBitSet;

public partial class NetBitSet
{
    /// <summary>
    ///     The bit-data storage.
    /// </summary>
    private BitArray[] _containers;

    /// <summary>
    ///     The order in which bytes within a word of data are read.
    /// </summary>
    private Endian _endianness;

    /// <summary>
    ///     The fixed length of a stored data unit, defined by its data type, in bits.
    ///     If the stored data does not have a fixed length, the WordLength would be WordLength.NotFixed.
    /// </summary>
    public WordLength WordLength { get; set; }

    /// <summary>
    ///     The order in which bytes within a word of data are read.
    /// </summary>
    public Endian Endianness
    {
        get => _endianness;
        set
        {
            if (_endianness != value)
            {
                _containers = BitArrayHelper.Reverse(_containers, WordLength);
            }

            _endianness = value;
        }
    }

    /// <summary>
    ///     The number of bits stored.
    /// </summary>
    public ulong Count => BitArrayHelper.GetAggregatedCount(_containers);

    /// <summary>
    ///     The number of words stored.
    ///     If WordLength is NotFixed, the this property would return 1 as the whole structure is one single word.
    /// </summary>
    public ulong WordCount
    {
        get
        {
            if (WordLength == WordLength.NotFixed)
            {
                return 1;
            }

            return Count / (byte)WordLength;
        }
    }

    /// <summary>
    ///     The number of bytes stored.
    /// </summary>
    public double ByteCount => (double)Count / (byte)WordLength.Eight;
}