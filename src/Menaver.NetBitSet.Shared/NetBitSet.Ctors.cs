using System.Collections;
using System.Text;
using Menaver.NetBitSet.Shared.Internals;
using BitConverter = System.BitConverter;

namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    private static Endian _systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
    private static Encoding _defaultSystemEncoding = Encoding.UTF8;

    private NetBitSet(BitArray[] bitArray, WordLength wordLength, Endian endianness)
    {
        if (endianness != _systemEndianness)
        {
            bitArray = BitArrayConverter.ReverseBytes(bitArray);
        }

        _containers = bitArray;
        WordLength = wordLength;
        Endianness = endianness;
    }

    public NetBitSet(ulong count, Bit defaultValue)
        : this(BitArrayBuilder.BuildBitArrays(count, defaultValue), Internals.BitConverter.GetBoolMachineWordLength(),
            _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetBoolMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetByteMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetByteMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetShortMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetShortMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetIntMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetIntMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetLongMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetLongMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetDoubleMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value, _defaultSystemEncoding),
            Internals.BitConverter.GetStringMachineWordLength(_defaultSystemEncoding), _systemEndianness)
    {
    }

    public NetBitSet(string value, Encoding encoding)
        : this(BitArrayConverter.Convert(value, encoding), Internals.BitConverter.GetStringMachineWordLength(encoding),
            _systemEndianness)
    {
    }

    public NetBitSet(string value, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.Convert(value, encoding), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(string value, Encoding encoding, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(value, encoding), wordLength, endianness)
    {
    }

    public NetBitSet(object obj)
        : this(BitArrayConverter.Convert(obj, _defaultSystemEncoding),
            Internals.BitConverter.GetStringMachineWordLength(_defaultSystemEncoding), _systemEndianness)
    {
    }

    public NetBitSet(object obj, Encoding encoding)
        : this(BitArrayConverter.Convert(obj, encoding),
            Internals.BitConverter.GetStringMachineWordLength(encoding), _systemEndianness)
    {
    }

    public NetBitSet(object obj, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.Convert(obj, encoding), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(object obj, Encoding encoding, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(obj, encoding), wordLength, endianness)
    {
    }

    public NetBitSet(bool[] value)
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetBoolMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetByteMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetByteMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetShortMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetShortMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetIntMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetIntMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetLongMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetLongMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(value), Internals.BitConverter.GetDoubleMachineWordLength(), _systemEndianness)
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
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), _defaultSystemEncoding),
            Internals.BitConverter.GetStringMachineWordLength(_defaultSystemEncoding), _systemEndianness)
    {
    }

    public NetBitSet(string[] value, Encoding encoding)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), encoding), Internals.BitConverter.GetStringMachineWordLength(encoding),
            _systemEndianness)
    {
    }

    public NetBitSet(string[] value, Encoding encoding, WordLength wordLength)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), encoding), wordLength, _systemEndianness)
    {
    }

    public NetBitSet(string[] value, Encoding encoding, WordLength wordLength, Endian endianness)
        : this(BitArrayConverter.Convert(string.Join(string.Empty, value), encoding), wordLength, endianness)
    {
    }
}