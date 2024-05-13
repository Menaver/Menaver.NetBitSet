using System.Collections;
using System.Text;
using Menaver.NetBitSet.Extensions;
using Newtonsoft.Json;

namespace Menaver.NetBitSet.Internals;

internal static class BitArrayConverter
{
    public static void CheckByWordLength(
        WordLength currentWordLength,
        WordLength targetWordLength)
    {
        if (currentWordLength != targetWordLength)
        {
            throw new InvalidOperationException(
                $"Word length does not match. Current: {currentWordLength}. Expected: {targetWordLength}.");
        }
    }

    public static void CheckByElementCount(
        ulong elementCount,
        WordLength targetWordLength)
    {
        if (elementCount % (byte)targetWordLength != 0)
        {
            throw new InvalidOperationException(
                $"Count does not match. Current: {elementCount}. Expected be multiple of {(byte)targetWordLength}.");
        }
    }

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

    public static BitArray[] Convert(Bit value)
    {
        return new[] { new BitArray(new[] { value.ToBool() }) };
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

    public static BitArray[] Convert(Bit[] value)
    {
        return new[] { new BitArray(value.Select(x => x.ToBool()).ToArray()) };
    }

    public static BitArray[] ConvertFromString(string value, Encoding encoding, WordLength wordLength)
    {
        if (value.Any() && value.All(ch => ch is '1' or '0'))
        {
            return ConvertBinaryString(value, wordLength);
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

    public static BitArray[] ConvertBinaryString(string binaryString, WordLength wordLength)
    {
        var count = (ulong)binaryString.LongCount();
        var bitArrays = BitArrayBuilder.BuildBitArrays(count, Bit.False);

        switch (wordLength)
        {
            case WordLength.NotFixed:
            case WordLength.One:
                {
                    var chars = binaryString.ToCharArray();

                    Array.Reverse(chars);

                    binaryString = new string(chars);

                    for (ulong i = 0; i < count; i++)
                    {
                        if (binaryString[(int)i] == '1')
                        {
                            var (packIndex, bitIndex) = BitArrayBuilder.GetComplexIndex(i);

                            bitArrays[packIndex][bitIndex] = true;
                        }
                    }

                    return bitArrays;
                }
            case WordLength.Eight:
            case WordLength.Sixteen:
            case WordLength.ThirtyTwo:
            case WordLength.SixtyFour:
                {
                    // split binaryString by words 
                    var chunkSize = (byte)wordLength;
                    var binaryStrings = Enumerable.Range(0, binaryString.Length / chunkSize)
                        .Select(i => binaryString.Substring(i * chunkSize, chunkSize)).ToList();

                    ulong index = 0;
                    foreach (var bs in binaryStrings)
                    {
                        var bitArray = ConvertBinaryString(bs, WordLength.One).First();

                        for (var i = 0; i < bitArray.Length; i++, index++)
                        {
                            var (packIndex, bitIndex) = BitArrayBuilder.GetComplexIndex(index);

                            bitArrays[packIndex][bitIndex] = bitArray[i];
                        }
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(wordLength), wordLength, null);
        }

        return bitArrays;
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

    public static string ConvertToBinaryString(BitArray[] bitArray, WordLength wordLength)
    {
        string binaryString;

        switch (wordLength)
        {
            case WordLength.NotFixed:
            case WordLength.One:
                {
                    var chars = ConvertToBools(bitArray)
                        .Select(x => x ? '1' : '0')
                        .ToArray();

                    Array.Reverse(chars);

                    binaryString = new string(chars);
                }
                break;
            case WordLength.Eight:
            case WordLength.Sixteen:
            case WordLength.ThirtyTwo:
            case WordLength.SixtyFour:
                {
                    var stringsByWord = ConvertToBinaryStringsByWord(bitArray, wordLength);

                    binaryString = string.Join(string.Empty, stringsByWord);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(wordLength), wordLength, null);
        }

        return binaryString;
    }

    public static string[] ConvertToBinaryStringsByWord(BitArray[] bitArray, WordLength wordLength)
    {
        var chars = ConvertToBools(bitArray)
            .Select(x => x ? '1' : '0')
            .ToArray();

        var result = new List<string>();

        var wordLengthInt = (int)wordLength;
        for (var i = 0; i < chars.Length; i += wordLengthInt)
        {
            var buffer = new char[wordLengthInt];
            Array.Copy(chars, i, buffer, 0, wordLengthInt);

            Array.Reverse(buffer);

            var str = new string(buffer);
            result.Add(str);
        }

        return result.ToArray();
    }

    public static T ConvertToObject<T>(BitArray[] bitArray, Encoding encoding)
    {
        var json = ConvertToString(bitArray, encoding);
        return JsonConvert.DeserializeObject<T>(json)!;
    }

    #endregion

    public static BitArray[] Reverse(BitArray[] bitArrays, WordLength wordLength)
    {
        var temp = BitArrayBuilder.Clone(bitArrays);

        switch (wordLength)
        {
            case WordLength.NotFixed:
                throw new InvalidOperationException("Word Length isn't fixed. Operation is invalid.");
            case WordLength.One:
            {
                temp = BitArrayBuilder.Reverse(temp);

                break;
            }
            case WordLength.Eight:
            case WordLength.Sixteen:
            case WordLength.ThirtyTwo:
            case WordLength.SixtyFour:
            {
                var wordLengthByte = (byte)wordLength;
                var elementCount = BitArrayBuilder.GetAggregatedCount(temp);
                var iterationCount = elementCount / wordLengthByte;

                for (ulong iteration = 0, index = 0; iteration < iterationCount; iteration++, index += wordLengthByte)
                {
                    var batch = BitArrayBuilder.GetBatch(temp, index, wordLengthByte);

                    batch = BitArrayBuilder.Reverse(batch);

                    BitArrayBuilder.Inject(temp, index, batch);
                }

                break;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(wordLength), wordLength, null);
        }

        return temp;
    }
}