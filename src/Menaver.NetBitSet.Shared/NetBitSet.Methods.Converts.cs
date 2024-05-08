using System.Text;
using Menaver.NetBitSet.Shared.Internals;

namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    public bool[] ToBools()
    {
        return BitArrayConverter.ConvertToBools(_containers);
    }

    public sbyte[] ToSBytes()
    {
        CheckConversionByWordLength(WordLengths.Byte);

        return BitArrayConverter.ConvertToSBytes(_containers);
    }

    public byte[] ToBytes()
    {
        CheckConversionByWordLength(WordLengths.Byte);

        return BitArrayConverter.ConvertToBytes(_containers);
    }

    public short[] ToShorts()
    {
        CheckConversionByWordLength(WordLengths.Short);

        return BitArrayConverter.ConvertToShorts(_containers);
    }

    public ushort[] ToUShorts()
    {
        CheckConversionByWordLength(WordLengths.Short);

        return BitArrayConverter.ConvertToUShorts(_containers);
    }

    public int[] ToInts()
    {
        CheckConversionByWordLength(WordLengths.Int);

        return BitArrayConverter.ConvertToInts(_containers);
    }

    public uint[] ToUInts()
    {
        CheckConversionByWordLength(WordLengths.Int);

        return BitArrayConverter.ConvertToUInts(_containers);
    }

    public long[] ToLongs()
    {
        CheckConversionByWordLength(WordLengths.Long);

        return BitArrayConverter.ConvertToLongs(_containers);
    }

    public ulong[] ToULongs()
    {
        CheckConversionByWordLength(WordLengths.Long);

        return BitArrayConverter.ConvertToULongs(_containers);
    }

    public double[] ToDoubles()
    {
        CheckConversionByWordLength(WordLengths.Double);

        return BitArrayConverter.ConvertToDoubles(_containers);
    }

    public string ToBinaryString()
    {
        return BitArrayConverter.ConvertToBinaryString(_containers, WordLength);
    }

    public string[] ToBinaryStringsByWord()
    {
        return BitArrayConverter.ConvertToBinaryStringsByWord(_containers, WordLength);
    }

    public T ToObject<T>()
    {
        return BitArrayConverter.ConvertToObject<T>(_containers, _defaultSystemEncoding);
    }

    public T ToObject<T>(Encoding encoding)
    {
        return BitArrayConverter.ConvertToObject<T>(_containers, encoding);
    }

    private void CheckConversionByWordLength(WordLength wordLength)
    {
        if (WordLength != wordLength)
        {
            throw new InvalidOperationException(
                $"Word length does not match. Current: {WordLength}. Expected: {wordLength}.");
        }

        if (Count % (byte)wordLength != 0)
        {
            throw new InvalidOperationException(
                $"Count does not match. Current: {Count}. Expected be multiple of {(byte)wordLength}.");
        }
    }
}