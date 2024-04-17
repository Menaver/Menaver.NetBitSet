using System.Collections;
using Menaver.NetBitSet.Shared.Internals;

namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    private static Endian _systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;

    private NetBitSet(BitArray[] bitArray, WordLength wordLength, Endian endianness)
    {
        _containers = bitArray;
        WordLength = (byte)wordLength;
        Endianness = endianness;
    }

    public NetBitSet(ulong count, Bit defaultValue)
        : this(BitArrayBuilder.BuildBitArrays(count, defaultValue), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(ulong count, Bit defaultValue, WordLength wordLength)
        : this(BitArrayBuilder.BuildBitArrays(count, defaultValue), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(ulong count, Bit defaultValue, WordLength wordLength, Endian endianness)
        : this(BitArrayBuilder.BuildBitArrays(count, defaultValue), wordLength, endianness)
    {
    }

    public NetBitSet(bool value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(bool value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(bool value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(sbyte value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(sbyte value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(sbyte value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(byte value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(byte value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(byte value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(short value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(short value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(short value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(ushort value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(ushort value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(ushort value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(int value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(int value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(int value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(uint value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(uint value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(uint value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(long value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(long value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(long value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(ulong value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(ulong value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(ulong value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(double value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(double value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(double value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(string value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(string value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(string value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(object obj, Type type)
        : this(BitArrayConverter.Convert(obj, type), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(object obj, Type type, WordLength wordLength)
        : this(BitArrayConverter.Convert(obj, type), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(object obj, Type type, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(obj, type), wordLength, endianness)
    {
    }

    public NetBitSet(bool[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(bool[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(bool[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(sbyte[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(sbyte[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(sbyte[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(byte[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(byte[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(byte[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(short[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(short[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(short[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(ushort[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(ushort[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(ushort[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(int[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(int[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(int[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(uint[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(uint[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(uint[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(long[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(long[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(long[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(ulong[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(ulong[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(ulong[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(double[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(double[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(double[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }

    public NetBitSet(string[] value)
        : this(BitArrayConverter.Convert(value), Extras.WordLength.Eight, _systemEndianness)
    {
    }

    public NetBitSet(string[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(string[] value, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value), wordLength, endianness)
    {
    }
}