using System.Collections;
using System.Text;
using Newtonsoft.Json;

namespace Menaver.NetBitSet.Shared.Internals;

internal static class BitArrayConverter
{
    #region To BitArray

    public static BitArray[] Convert(bool value)
    {
        return new[] { new BitArray(new[] { value }) };
    }

    public static BitArray[] Convert(sbyte value)
    {
        return new[] { new BitArray(new[] { unchecked((byte)value) }) };
    }

    public static BitArray[] Convert(byte value)
    {
        return new[] { new BitArray(new[] { value }) };
    }

    public static BitArray[] Convert(short value)
    {
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(ushort value)
    {
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(int value)
    {
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(uint value)
    {
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(long value)
    {
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(ulong value)
    {
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(double value)
    {
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(bool[] value)
    {
        return new[] { new BitArray(value) };
    }

    public static BitArray[] Convert(sbyte[] value)
    {
        var bytes = value.Select(x => unchecked((byte)x)).ToArray();

        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(byte[] value)
    {
        return BitArrayBuilder.BuildBitArrays(value);
    }

    public static BitArray[] Convert(short[] value)
    {
        var bytes = value.SelectMany(BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(ushort[] value)
    {
        var bytes = value.SelectMany(BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(int[] value)
    {
        var bytes = value.SelectMany(BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(uint[] value)
    {
        var bytes = value.SelectMany(BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(long[] value)
    {
        var bytes = value.SelectMany(BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(ulong[] value)
    {
        var bytes = value.SelectMany(BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(double[] value)
    {
        var bytes = value.SelectMany(BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(string value, Encoding encoding)
    {
        if (value.All(ch => ch is '1' or '0')) // binary string
        {
            var chars = value.ToCharArray();
            Array.Reverse(chars);
            value = new string(chars);

            var count = (ulong)value.LongCount();

            var bitArrays = BitArrayBuilder.BuildBitArrays(count, Bit.False);

            for (ulong i = 0; i < count; i++)
            {
                if (value[(int)i] == '1')
                {
                    var (packIndex, bitIndex) = BitArrayBuilder.GetComplexIndex(i);

                    bitArrays[packIndex][bitIndex] = true;
                }
            }



            return bitArrays;
        }

        var bytes = encoding.GetBytes(value);
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(object obj, Encoding encoding)
    {
        var json = JsonConvert.SerializeObject(obj);
        var bytes = encoding.GetBytes(json);
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    #endregion

    #region From BitArray

    public static bool[] ConvertToBools(BitArray[] bitArrays)
    {
        return bitArrays.SelectMany(array => array.Cast<bool>()).ToArray();
    }

    public static sbyte[] ConvertToSBytes(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Byte;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new sbyte[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new sbyte[1];
            batch.CopyTo(temp, 0);
            result[i] = temp[0];
        }

        return result;
    }

    public static byte[] ConvertToBytes(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Byte;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new byte[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new byte[1];
            batch.CopyTo(temp, 0);
            result[i] = temp[0];
        }

        return result;
    }

    public static short[] ConvertToShorts(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Short;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new short[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new byte[2];
            batch.CopyTo(temp, 0);
            result[i] = BitConverter.ToInt16(temp, 0);
        }

        return result;
    }

    public static ushort[] ConvertToUShorts(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Short;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new ushort[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new byte[2];
            batch.CopyTo(temp, 0);
            result[i] = BitConverter.ToUInt16(temp, 0);
        }

        return result;
    }

    public static int[] ConvertToInts(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Int;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new int[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new int[1];
            batch.CopyTo(temp, 0);
            result[i] = temp[0];
        }

        return result;
    }

    public static uint[] ConvertToUInts(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Int;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new uint[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new uint[1];
            batch.CopyTo(temp, 0);
            result[i] = temp[0];
        }

        return result;
    }

    public static long[] ConvertToLongs(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Long;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new long[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new byte[8];
            batch.CopyTo(temp, 0);
            result[i] = BitConverter.ToInt64(temp, 0);
        }

        return result;
    }

    public static ulong[] ConvertToULongs(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Long;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new ulong[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new byte[8];
            batch.CopyTo(temp, 0);
            result[i] = BitConverter.ToUInt64(temp, 0);
        }

        return result;
    }

    public static double[] ConvertToDoubles(BitArray[] bitArrays)
    {
        var wordLength = (byte)WordLengths.Double;
        var elementCount = BitArrayBuilder.GetAggregatedCount(bitArrays);
        var arrayLength = elementCount / wordLength;

        var result = new double[arrayLength];

        for (ulong i = 0, j = 0; i < arrayLength; i++, j += wordLength)
        {
            var batch = BitArrayBuilder.GetBatch(bitArrays, j, wordLength);

            var temp = new byte[8];
            batch.CopyTo(temp, 0);
            result[i] = BitConverter.ToDouble(temp, 0);
        }

        return result;
    }

    public static string ConvertToString(BitArray[] bitArray, Encoding encoding)
    {
        var bytes = ConvertToBytes(bitArray);

        return encoding.GetString(bytes);
    }

    public static string ConvertToBinaryString(BitArray[] bitArray)
    {
        var chars = ConvertToBools(bitArray)
            .Select(x => x ? '1' : '0')
            .ToArray();

        Array.Reverse(chars);

        return new string(chars);
    }

    public static string[] ConvertToBinaryStringsByWord(BitArray[] bitArray, WordLength wordLength)
    {
        var chars = ConvertToBools(bitArray)
            .Select(x => x ? '1' : '0')
            .ToArray();

        Array.Reverse(chars);

        var result = new List<string>();

        var wordLengthInt = (int)wordLength;
        for (var i = 0; i < chars.Length; i++)
        {
            var sb = new StringBuilder();

            for (var j = 0; j < wordLengthInt; j++)
            {
                if (i == chars.Length - 1)
                {
                    break;
                }

                sb.Append(chars[i]);
            }

            result.Add(sb.ToString());
        }

        return result.ToArray();
    }

    public static T ConvertToObject<T>(BitArray[] bitArray, Encoding encoding)
    {
        var json = ConvertToString(bitArray, encoding);
        return JsonConvert.DeserializeObject<T>(json)!;
    }

    #endregion
}