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
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(byte value)
    {
        return new[] { new BitArray(BitConverter.GetBytes(value)) };
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

    public static BitArray[] Convert(string value, Encoding encoding)
    {
        var bytes = encoding.GetBytes(value);
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(object obj, Encoding encoding)
    {
        var json = JsonConvert.SerializeObject(obj);
        var bytes = encoding.GetBytes(json);
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(bool[] value)
    {
        var bytes = value.SelectMany(BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(sbyte[] value)
    {
        var bytes = value.SelectMany(x => BitConverter.GetBytes(x)).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(byte[] value)
    {
        var bytes = value.SelectMany(x => BitConverter.GetBytes(x)).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
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

    #endregion

    #region From BitArray

    public static string ConvertToString(BitArray[] bitArray, Encoding encoding)
    {
        var bytes = ConvertToBytes(bitArray);

        return encoding.GetString(bytes);
    }

    public static T ConvertToObject<T>(BitArray[] bitArray, Encoding encoding)
    {
        var json = ConvertToString(bitArray, encoding);

        var obj = JsonConvert.DeserializeObject<T>(json);

        return obj!;
    }

    public static bool[] ConvertToBools(BitArray[] bitArray)
    {
        return bitArray.SelectMany(array => array.Cast<bool>()).ToArray();
    }

    public static sbyte[] ConvertToSBytes(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Bool;

        var temp = new sbyte[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static byte[] ConvertToBytes(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Byte;

        var temp = new byte[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static short[] ConvertToShorts(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Short;

        var temp = new short[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static ushort[] ConvertToUShorts(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Short;

        var temp = new ushort[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static int[] ConvertToInts(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Int;

        var temp = new int[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static uint[] ConvertToUInts(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Int;

        var temp = new uint[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static long[] ConvertToLongs(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Long;

        var temp = new long[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static ulong[] ConvertToULongs(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Long;

        var temp = new ulong[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static double[] ConvertToDoubles(BitArray[] bitArray)
    {
        var arrayLength = bitArray.Length / (byte)WordLengths.Double;

        var temp = new double[arrayLength];
        bitArray.CopyTo(temp, 0);

        return temp;
    }

    public static string ConvertToBinaryString(BitArray[] bitArray)
    {
        var chars = ConvertToBools(bitArray)
            .Select(x => x ? '1' : '0')
            .ToArray();

        return new string(chars);
    }

    public static string[] ConvertToBinaryStringsByWord(BitArray[] bitArray, WordLength wordLength)
    {
        var chars = ConvertToBools(bitArray)
            .Select(x => x ? '1' : '0')
            .ToArray();

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

    #endregion
}