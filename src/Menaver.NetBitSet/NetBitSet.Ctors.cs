﻿using System.Collections;
using System.Text;
using Menaver.NetBitSet.Internals;

namespace Menaver.NetBitSet;

public partial class NetBitSet
{
    private static readonly Endian _systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
    private static readonly Encoding _defaultSystemEncoding = Encoding.UTF8;

    private NetBitSet(BitArray[] bitArray, WordLength wordLength)
    {
        _containers = bitArray;
        WordLength = wordLength;
        _endianness = _systemEndianness;
    }

    public NetBitSet(ulong count, Bit defaultValue)
        : this(BitArrayBuilder.BuildBitArrays(count, defaultValue), WordLengths.Bool)
    {
    }

    public NetBitSet(ulong count, Bit defaultValue, WordLength wordLength)
        : this(BitArrayBuilder.BuildBitArrays(count, defaultValue), wordLength)
    {
    }

    public NetBitSet(bool value)
        : this(BitArrayConverter.Convert(value), WordLengths.Bool)
    {
    }

    public NetBitSet(bool value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(sbyte value)
        : this(BitArrayConverter.Convert(value), WordLengths.Byte)
    {
    }

    public NetBitSet(sbyte value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(byte value)
        : this(BitArrayConverter.Convert(value), WordLengths.Byte)
    {
    }

    public NetBitSet(byte value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(short value)
        : this(BitArrayConverter.Convert(value), WordLengths.Short)
    {
    }

    public NetBitSet(short value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(ushort value)
        : this(BitArrayConverter.Convert(value), WordLengths.Short)
    {
    }

    public NetBitSet(ushort value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(int value)
        : this(BitArrayConverter.Convert(value), WordLengths.Int)
    {
    }

    public NetBitSet(int value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(uint value)
        : this(BitArrayConverter.Convert(value), WordLengths.Int)
    {
    }

    public NetBitSet(uint value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(long value)
        : this(BitArrayConverter.Convert(value), WordLengths.Long)
    {
    }

    public NetBitSet(long value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(ulong value)
        : this(BitArrayConverter.Convert(value), WordLengths.Long)
    {
    }

    public NetBitSet(ulong value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(double value)
        : this(BitArrayConverter.Convert(value), WordLengths.Double)
    {
    }

    public NetBitSet(double value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(Bit value)
        : this(BitArrayConverter.Convert(value), WordLength.One)
    {
    }

    public NetBitSet(Bit value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(string value)
        : this(BitArrayConverter.ConvertFromString(value, _defaultSystemEncoding, WordLengths.String(value, _defaultSystemEncoding)), WordLengths.String(value, _defaultSystemEncoding))
    {
    }

    public NetBitSet(string value, WordLength wordLength)
        : this(BitArrayConverter.ConvertFromString(value, _defaultSystemEncoding, wordLength), wordLength)
    {
    }

    public NetBitSet(string value, Encoding encoding)
        : this(BitArrayConverter.ConvertFromString(value, encoding, WordLengths.String(value, encoding)), WordLengths.String(value, encoding))
    {
    }

    public NetBitSet(string value, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.ConvertFromString(value, encoding, wordLength), wordLength)
    {
    }

    public NetBitSet(object obj)
        : this(BitArrayConverter.Convert(obj, _defaultSystemEncoding), WordLengths.String(string.Empty, _defaultSystemEncoding))
    {
    }

    public NetBitSet(object obj, Encoding encoding)
        : this(BitArrayConverter.Convert(obj, encoding), WordLengths.String(string.Empty, encoding))
    {
    }

    public NetBitSet(object obj, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.Convert(obj, encoding), wordLength)
    {
    }

    public NetBitSet(bool[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Bool)
    {
    }

    public NetBitSet(bool[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(sbyte[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Byte)
    {
    }

    public NetBitSet(sbyte[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(byte[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Byte)
    {
    }

    public NetBitSet(byte[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(short[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Short)
    {
    }

    public NetBitSet(short[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(ushort[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Short)
    {
    }

    public NetBitSet(ushort[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(int[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Int)
    {
    }

    public NetBitSet(int[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(uint[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Int)
    {
    }

    public NetBitSet(uint[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(long[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Long)
    {
    }

    public NetBitSet(long[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(ulong[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Long)
    {
    }

    public NetBitSet(ulong[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(double[] value)
        : this(BitArrayConverter.Convert(value), WordLengths.Double)
    {
    }

    public NetBitSet(double[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(Bit[] value)
        : this(BitArrayConverter.Convert(value), WordLength.One)
    {
    }

    public NetBitSet(Bit[] value, WordLength wordLength)
        : this(BitArrayConverter.Convert(value), wordLength)
    {
    }

    public NetBitSet(string[] value)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), _defaultSystemEncoding),
            WordLengths.String(string.Join(string.Empty, value), _defaultSystemEncoding))
    {
    }

    public NetBitSet(string[] value, Encoding encoding)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), encoding),
            WordLengths.String(string.Join(string.Empty, value), encoding))
    {
    }

    public NetBitSet(string[] value, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), encoding), wordLength)
    {
    }
}