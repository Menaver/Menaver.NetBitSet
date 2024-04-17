using System.Collections;

namespace Menaver.NetBitSet.Shared.Internals;

internal static class BitArrayConverter
{
    #region To BitArray

    public static BitArray[] Convert(bool value)
    {

    }

    public static BitArray[] Convert(sbyte value)
    {

    }

    public static BitArray[] Convert(byte value)
    {

    }

    public static BitArray[] Convert(short value)
    {

    }

    public static BitArray[] Convert(ushort value)
    {

    }

    public static BitArray[] Convert(int value)
    {

    }

    public static BitArray[] Convert(uint value)
    {

    }

    public static BitArray[] Convert(long value)
    {

    }

    public static BitArray[] Convert(ulong value)
    {

    }

    public static BitArray[] Convert(double value)
    {

    }

    public static BitArray[] Convert(string value)
    {

    }

    public static BitArray[] Convert(object obj, Type type)
    {

    }

    public static BitArray[] Convert(bool[] value)
    {

    }

    public static BitArray[] Convert(sbyte[] value)
    {

    }

    public static BitArray[] Convert(byte[] value)
    {

    }

    public static BitArray[] Convert(short[] value)
    {

    }

    public static BitArray[] Convert(ushort[] value)
    {

    }

    public static BitArray[] Convert(int[] value)
    {

    }

    public static BitArray[] Convert(uint[] value)
    {

    }

    public static BitArray[] Convert(long[] value)
    {

    }

    public static BitArray[] Convert(ulong[] value)
    {

    }

    public static BitArray[] Convert(double[] value)
    {

    }

    public static BitArray[] Convert(string[] value)
    {

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

    }

    public static short ConvertToShort(BitArray[] bitArray)
    {

    }

    public static ushort ConvertUShort(BitArray[] bitArray)
    {

    }

    public static int ConvertToInt(BitArray[] bitArray)
    {

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

    public static string ConvertToString(BitArray[] bitArray, Endian endianness)
    {

    }

    public static T ConvertToObject<T>(BitArray bitArray)
    {

    }

    public static bool[] ConvertToBools(BitArray bitArray)
    {

    }

    public static sbyte[] ConvertToSBytes(BitArray bitArray)
    {

    }

    public static byte[] ConvertToBytes(BitArray bitArray)
    {

    }

    public static short[] ConvertToShorts(BitArray bitArray)
    {

    }

    public static ushort[] ConvertToUShorts(BitArray bitArray)
    {

    }

    public static int[] ConvertToInts(BitArray bitArray)
    {

    }

    public static uint[] ConvertToUInts(BitArray bitArray)
    {

    }

    public static long[] ConvertToLongs(BitArray bitArray)
    {

    }

    public static ulong[] ConvertToULongs(BitArray bitArray)
    {

    }

    public static double[] ConvertToDoubles(BitArray bitArray)
    {

    }

    public static string[] ConvertToStrings(BitArray bitArray)
    {

    }

    #endregion












    //public NetBitSet()
    //{
    //    _container = new BitArray(0, false);

    //    WordLength = 0;
    //}

    //public NetBitSet(int count, byte wordLength = 0, int defaultValue = 0)
    //{
    //    _container = new BitArray(count, defaultValue.ToBool());
    //    WordLength = wordLength;
    //}

    //public NetBitSet(INetBitSet obj)
    //{
    //    _container = obj.ToBitArray();
    //    WordLength = obj.WordLength;
    //}

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

    //public NetBitSet(object obj)
    //{
    //    _container = obj.ToBitArray();
    //    WordLength = 8;
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