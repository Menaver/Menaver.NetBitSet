using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Shared.Internals;

public static class Extensions
{









































    #region CONVERSIONS
    

    


    #region BitArray <--> base types and arrays

    // converts the BitArray object to 
    // its equivalent bool value representation
    public static bool ToBool(this BitArray array)
    {
        return array[0];
    }

    // converts the BitArray object to 
    // its equivalent byte value representation
    public static byte ToByte(this BitArray array)
    {
        var temp = new byte[array.Length / 8];
        array.CopyTo(temp, 0);
        return temp[0];
    }

    // converts the BitArray object to 
    // its equivalent int value representation
    public static int ToInt(this BitArray array)
    {
        var temp = new int[array.Length / 32];
        array.CopyTo(temp, 0);
        return temp[0];
    }


    // converts the BitArray object to 
    // its equivalent array of bools representation
    public static bool[] ToBoolArray(this BitArray array)
    {
        var temp = new bool[array.Length];
        array.CopyTo(temp, 0);
        return temp;
    }

    // converts the BitArray object to 
    // its equivalent array of bytes representation
    public static byte[] ToByteArray(this BitArray array, Endian endian = Endian.Little)
    {
        var temp = new byte[array.Length / 8];
        array.CopyTo(temp, 0);

        if (endian == Endian.Big) Array.Reverse(temp);

        return temp;
    }

    // converts the BitArray object to 
    // its equivalent array of ints representation
    public static int[] ToIntArray(this BitArray array, Endian endian = Endian.Little)
    {
        var temp = new int[array.Length / 32];
        array.CopyTo(temp, 0);

        if (endian == Endian.Big) temp = temp.ReverseBytes();

        return temp;
    }


    // converts a bool value to its equivalent BitArray object
    public static BitArray ToBitArray(this bool value)
    {
        return new BitArray(new[] { value });
    }

    // converts a byte value to its equivalent BitArray object
    public static BitArray ToBitArray(this byte value)
    {
        return new BitArray(new[] { value });
    }

    // converts a int value to its equivalent BitArray object
    public static BitArray ToBitArray(this int value)
    {
        return new BitArray(new[] { value });
    }


    // converts array of bools to its equivalent BitArray object
    public static BitArray ToBitArray(this bool[] array)
    {
        return new BitArray(array);
    }

    // converts array of bytes to its equivalent BitArray object
    public static BitArray ToBitArray(this byte[] array)
    {
        return new BitArray(array);
    }

    // converts array of ints to its equivalent BitArray object
    public static BitArray ToBitArray(this int[] array)
    {
        return new BitArray(array);
    }

    #endregion



    #region BitArray <--> binary string and array of chars

    // converts the BitArray object to its 
    // equivalent binary string representation
    public static string ToBinaryString(this BitArray array, string bytesSeparator = "", Endian endian = Endian.Little)
    {
        if (endian == Endian.Big) array = array.ReverseBytes();

        var result = new char[array.Length];
        for (int i = 0, j = array.Length - 1; i < array.Length && j >= 0; i++, j--)
            // converting bools to ints (forming of array of chars)
            result[i] = array[j] == false ? '0' : '1';

        // array of chars --> string
        var sresult = new string(result);

        if (bytesSeparator != "")
        {
            var j = 1;
            for (var i = sresult.Length - 1; i >= 0; i--)
            {
                if (j == 8) // after each 8th bit insert separator
                {
                    if (i > 0) sresult = sresult.Insert(i, bytesSeparator);
                    j = 1;
                }
                else
                    j++;
            }
        }

        return sresult;
    }

    // converts the BitArray object to its 
    // equivalent array of chars representation
    public static char[] ToCharArray(this BitArray array, Endian endian = Endian.Little)
    {
        if (endian == Endian.Big) array = array.ReverseBytes();

        var result = new char[array.Length];
        for (int i = 0, j = array.Length - 1; i < array.Length && j >= 0; i++, j--)
            // converting bools to ints (forming of array of chars)
            result[i] = array[j] == false ? '0' : '1';

        return result;
    }


    // converts the binary string to its equivalent BitArray object
    public static BitArray ToBitArray(this string binaryString)
    {
        var result = new BitArray(binaryString.Length);
        for (int i = 0, j = binaryString.Length - 1; i < result.Length && j >= 0; i++, j--)
        {
            switch (binaryString[j])
            {
                case '0':
                    result[i] = false;
                    break;
                case '1':
                    result[i] = true;
                    break;
                default:
                    throw new ArgumentException("Binary string contains incorrect signs. Correct signs: 0 and 1");
            }
        }

        return result;
    }

    // converts array of chars to its equivalent BitArray object
    public static BitArray ToBitArray(this char[] array)
    {
        var result = new BitArray(array.Length);
        for (int i = 0, j = array.Length - 1; i < result.Length && j >= 0; i++, j--)
        {
            switch (array[j])
            {
                case '0':
                    result[i] = false;
                    break;
                case '1':
                    result[i] = true;
                    break;
                default:
                    throw new ArgumentException("Array of chars contains incorrect signs. Correct signs: 0 and 1");
            }
        }

        return result;
    }

    #endregion

    #endregion
}