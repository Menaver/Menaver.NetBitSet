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
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(byte value)
    {
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(short value)
    {
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(ushort value)
    {
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(int value)
    {
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(uint value)
    {
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(long value)
    {
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(ulong value)
    {
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
    }

    public static BitArray[] Convert(double value)
    {
        return new[] { new BitArray(System.BitConverter.GetBytes(value)) };
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
        var bytes = value.SelectMany(System.BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(sbyte[] value)
    {
        var bytes = value.SelectMany(x => System.BitConverter.GetBytes(x)).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(byte[] value)
    {
        var bytes = value.SelectMany(x => System.BitConverter.GetBytes(x)).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(short[] value)
    {
        var bytes = value.SelectMany(System.BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(ushort[] value)
    {
        var bytes = value.SelectMany(System.BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(int[] value)
    {
        var bytes = value.SelectMany(System.BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(uint[] value)
    {
        var bytes = value.SelectMany(System.BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(long[] value)
    {
        var bytes = value.SelectMany(System.BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(ulong[] value)
    {
        var bytes = value.SelectMany(System.BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    public static BitArray[] Convert(double[] value)
    {
        var bytes = value.SelectMany(System.BitConverter.GetBytes).ToArray();
        return BitArrayBuilder.BuildBitArrays(bytes);
    }

    #endregion

    #region From BitArray

    public static bool ConvertToBool(BitArray[] bitArray)
    {

    }

    public static sbyte ConvertToSByte(BitArray[] bitArray)
    {

    }

    public static byte ConvertToByte(BitArray[] bitArray)
    {
        //    if (WordLength != 8)
        //    {
        //        // note: use temp container to protect current data

        //        // resizing to convert to this king of type
        //        var temp = (BitArray)_containers.Clone();
        //        temp.Length = GetNewArraySize(temp.Length, 8);
        //        return temp.ToByte();
        //    }

        //    return _containers.ToByte();
    }

    public static short ConvertToShort(BitArray[] bitArray)
    {

    }

    public static ushort ConvertUShort(BitArray[] bitArray)
    {

    }

    public static int ConvertToInt(BitArray[] bitArray)
    {
        //    if (WordLength != 32)
        //    {
        //        // note: use temp container to protect current data

        //        // resizing to convert to this king of type
        //        var temp = (BitArray)_containers.Clone();
        //        temp.Length = GetNewArraySize(temp.Length, 32);
        //        return temp.ToInt();
        //    }

        //    return _containers.ToInt();
    }

    public static uint ConvertToUInt(BitArray[] bitArray)
    {

    }

    public static long ConvertToLong(BitArray[] bitArray)
    {

    }

    public static ulong ConvertToULong(BitArray[] bitArray)
    {

    }

    public static double ConvertToDouble(BitArray[] bitArray)
    {

    }

    public static string ConvertToString(BitArray[] bitArray, Encoding encoding)
    {
        //    if (WordLength == 8)
        //    {
        //        // convert to non-binary string

        //        var bytes = _containers.ToByteArray();

        //        if (endian == Endian.Big) Array.Reverse(bytes);

        //        var chars = Encoding.Unicode.GetChars(bytes);

        //        if (bytesSeparator != "")
        //        {
        //            var separatedChars = "";
        //            for (var i = 0; i < chars.Length; i++)
        //            {
        //                separatedChars += chars[i];

        //                if (i < chars.Length - 1) // for the last one skip adding bytesSeparator
        //                    separatedChars += bytesSeparator;
        //            }

        //            return separatedChars;
        //        }

        //        return new string(chars);
        //    }

        //    return _containers.ToBinaryString(bytesSeparator, endian);
    }

    public static T ConvertToObject<T>(BitArray[] bitArray)
    {

    }

    public static bool[] ConvertToBools(BitArray[] bitArray)
    {

    }

    public static sbyte[] ConvertToSBytes(BitArray[] bitArray)
    {

    }

    public static byte[] ConvertToBytes(BitArray[] bitArray)
    {

    }

    public static short[] ConvertToShorts(BitArray[] bitArray)
    {

    }

    public static ushort[] ConvertToUShorts(BitArray[] bitArray)
    {

    }

    public static int[] ConvertToInts(BitArray[] bitArray)
    {

    }

    public static uint[] ConvertToUInts(BitArray[] bitArray)
    {

    }

    public static long[] ConvertToLongs(BitArray[] bitArray)
    {

    }

    public static ulong[] ConvertToULongs(BitArray[] bitArray)
    {

    }

    public static double[] ConvertToDoubles(BitArray[] bitArray)
    {

    }

    public static string ConvertToBinaryString(BitArray[] bitArray)
    {

    }

    public static string[] ConvertToBinaryStringsByWord(BitArray[] bitArray)
    {

    }

    #endregion


    public static BitArray[] ReverseBytes(BitArray[] bitArrays)
    {

    }









    //public NetBitSet(string str, byte wordLength = 0)
    //{
    //    if (str.IsBinary())
    //    {
    //        WordLength = wordLength;

    //        // if wordLength does not match to data type (unspecified, bool, byte or int)
    //        if (WordLength != 0)
    //            if (str.Length % WordLength != 0)
    //                throw new ArgumentException(
    //                    "String length does not fit word length.");

    //        // if word length is unspecified or match to any data type
    //        _container = str.ToBitArray();
    //    }
    //    else
    //    {
    //        var charCodes = Encoding.UTF8.GetBytes(str);
    //        _container = charCodes.ToBitArray();
    //        WordLength = 8;
    //    }
    //}

    //public NetBitSet(char[] array, byte wordLength = 0)
    //{
    //    if (array.IsBinary())
    //    {
    //        WordLength = wordLength;

    //        // if wordLength does not match to data type (bool, byte or int)
    //        if (WordLength != 0)
    //            if (array.Length % WordLength != 0)
    //                throw new ArgumentException(
    //                    "Array length does not match to this kind of type specified by wordLength");

    //        // if word length is unspecified or match to any type
    //        _container = array.ToBitArray();
    //    }
    //    else
    //    {
    //        var charCodes = Encoding.Unicode.GetBytes(new string(array));
    //        _container = charCodes.ToBitArray();
    //        WordLength = 8;
    //    }
    //}

    //#region FROM BASE TYPES AND BASE-TYPED ARRAYS

    //public NetBitSet(bool value)
    //{
    //    _container = value.ToBitArray();
    //    WordLength = 1;
    //}

    //public NetBitSet(byte value)
    //{
    //    _container = value.ToBitArray();
    //    WordLength = 8;
    //}

    //public NetBitSet(int value)
    //{
    //    _container = value.ToBitArray();
    //    WordLength = 32;
    //}


    //public NetBitSet(bool[] array)
    //{
    //    _container = array.ToBitArray();
    //    WordLength = 1;
    //}

    //public NetBitSet(byte[] array)
    //{
    //    _container = array.ToBitArray();
    //    WordLength = 8;
    //}

    //public NetBitSet(int[] array)
    //{
    //    _container = array.ToBitArray();
    //    WordLength = 32;
    //}

    //#endregion
}