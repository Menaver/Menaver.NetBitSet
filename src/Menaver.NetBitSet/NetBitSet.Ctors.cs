using System.Collections;
using System.Text;
using Menaver.NetBitSet.Internals;

namespace Menaver.NetBitSet;

public partial class NetBitSet
{
    private static readonly Endian SystemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;

    private static readonly Encoding DefaultSystemEncoding = Encoding.UTF8;

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="bitArray">The array of BitArray representing the data.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    private NetBitSet(BitArray[] bitArray, WordLength wordLength)
    {
        _containers = bitArray;
        WordLength = wordLength;
        _endianness = SystemEndianness;
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="count">The number of elements.</param>
    /// <param name="defaultValue">The default value to initialize the bit-set with.</param>
    public NetBitSet(ulong count, Bit defaultValue)
        : this(BitArrayBuilder.BuildBitArrays(count, defaultValue), WordLengths.Bool)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="count">The number of elements.</param>
    /// <param name="defaultValue">The default value to initialize the bit-set with.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(ulong count, Bit defaultValue, WordLength wordLength)
        : this(BitArrayBuilder.BuildBitArrays(count, defaultValue), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(bool value)
        : this(BitArrayConverter.Convert(value), WordLengths.Bool)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(bool value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(sbyte value)
        : this(BitArrayConverter.Convert(value), WordLengths.Byte)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(sbyte value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(byte value)
        : this(BitArrayConverter.Convert(value), WordLengths.Byte)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(byte value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(short value)
        : this(BitArrayConverter.Convert(value), WordLengths.Short)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(short value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(ushort value)
        : this(BitArrayConverter.Convert(value), WordLengths.Short)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(ushort value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(int value)
        : this(BitArrayConverter.Convert(value), WordLengths.Int)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(int value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(uint value)
        : this(BitArrayConverter.Convert(value), WordLengths.Int)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(uint value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(long value)
        : this(BitArrayConverter.Convert(value), WordLengths.Long)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(long value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(ulong value)
        : this(BitArrayConverter.Convert(value), WordLengths.Long)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(ulong value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(double value)
        : this(BitArrayConverter.Convert(value), WordLengths.Double)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(double value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(Bit value)
        : this(BitArrayConverter.Convert(value), WordLength.One)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(Bit value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">
    ///     The string to be presented as set of bits.
    ///     If it's a binary string (consists of '0' and '1' only), the string would be converted to 1-to-1 array of bits.
    ///     Otherwise, the value is converted to array of bytes (using the system current encoding), which then becomes a set
    ///     of bits.
    /// </param>
    public NetBitSet(string value)
        : this(
            BitArrayConverter.ConvertFromString(value, DefaultSystemEncoding,
                WordLengths.String(value, DefaultSystemEncoding)), WordLengths.String(value, DefaultSystemEncoding))
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">
    ///     The string to be presented as set of bits.
    ///     If it's a binary string (consists of '0' and '1' only), the string would be converted to 1-to-1 array of bits.
    ///     Otherwise, the value is converted to array of bytes (using the system current encoding), which then becomes a set
    ///     of bits.
    /// </param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(string value, WordLength wordLength)
        : this(BitArrayConverter.ConvertFromString(value, DefaultSystemEncoding, wordLength), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">
    ///     The string to be presented as set of bits.
    ///     If it's a binary string (consists of '0' and '1' only), the string would be converted to 1-to-1 array of bits.
    ///     Otherwise, the value is converted to array of bytes (using the system current encoding), which then becomes a set
    ///     of bits.
    /// </param>
    /// <param name="encoding">The encoding the string is driven by.</param>
    public NetBitSet(string value, Encoding encoding)
        : this(BitArrayConverter.ConvertFromString(value, encoding, WordLengths.String(value, encoding)),
            WordLengths.String(value, encoding))
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">
    ///     The string to be presented as set of bits.
    ///     If it's a binary string (consists of '0' and '1' only), the string would be converted to 1-to-1 array of bits.
    ///     Otherwise, the value is converted to array of bytes (using the system current encoding), which then becomes a set
    ///     of bits.
    /// </param>
    /// <param name="encoding">The encoding the string is driven by.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(string value, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.ConvertFromString(value, encoding, wordLength), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="obj">
    ///     The object to be presented as set of bits.
    ///     NOTE: first, the object is converted to JSON string, and then to set of bits.
    /// </param>
    public NetBitSet(object obj)
        : this(BitArrayConverter.Convert(obj, DefaultSystemEncoding),
            WordLengths.String(string.Empty, DefaultSystemEncoding))
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="obj">
    ///     The object to be presented as set of bits.
    ///     NOTE: first, the object is converted to JSON string, and then to set of bits.
    /// </param>
    /// <param name="encoding">The encoding the JSON string to be driven by.</param>
    public NetBitSet(object obj, Encoding encoding)
        : this(BitArrayConverter.Convert(obj, encoding), WordLengths.String(string.Empty, encoding))
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="obj">
    ///     The object to be presented as set of bits.
    ///     NOTE: first, the object is converted to JSON string, and then to set of bits.
    /// </param>
    /// <param name="encoding">The encoding the JSON string to be driven by.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(object obj, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.Convert(obj, encoding), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(bool[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Bool)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(bool[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(sbyte[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Byte)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(sbyte[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(byte[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Byte)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(byte[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(short[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Short)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(short[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(ushort[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Short)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(ushort[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(int[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Int)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(int[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(uint[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Int)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(uint[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(long[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Long)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(long[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(ulong[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Long)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(ulong[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(double[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Double)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(double[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(Bit[] value)
        : this(BitArrayConverter.Convert(value), WordLength.One)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(Bit[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    public NetBitSet(string[] value)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), DefaultSystemEncoding),
            WordLengths.String(string.Join(string.Empty, value), DefaultSystemEncoding))
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="encoding">The encoding the string is driven by.</param>
    public NetBitSet(string[] value, Encoding encoding)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), encoding),
            WordLengths.String(string.Join(string.Empty, value), encoding))
    {
    }

    /// <summary>
    ///     The ctor.
    /// </summary>
    /// <param name="value">The data to be presented as set of bits.</param>
    /// <param name="encoding">The encoding the string is driven by.</param>
    /// <param name="wordLength">The word length representing the length of element data block.</param>
    public NetBitSet(string[] value, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), encoding), wordLength)
    {
    }
}