using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Shared
{
    public static class Extensions
    {
        // defines if the input string 
        // is binary - contains '0' and '1' only
        public static bool IsBinary(this string str)
        {
            foreach (char ch in str)
                if (ch != '0' && ch != '1')
                    return false;

            return true;
        }

        // defines if the input array of chars 
        // is binary - contains '0' and '1' only
        public static bool IsBinary(this char[] array)
        {
            foreach (char ch in array)
                if (ch != '0' && ch != '1')
                    return false;

            return true;
        }


        public static BitArray ReverseBytes(this BitArray array)
        {
            byte[] bytes = array.ToByteArray();
            Array.Reverse(bytes);
            return bytes.ToBitArray();
        }

        public static int[] ReverseBytes(this int[] values)
        {
            List<int> result = new List<int>();

            foreach (int value in values)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                result.Add(BitConverter.ToInt32(bytes, 0));
            }

            return result.ToArray();
        }


        #region CONVERSIONS

        #region Bool <--> int

        // rule: 0 == false, any other int value == 1

        // note: somewhere in code this methods is not 
        // called because of lightness of its realization

        public static int ToInt(this bool value)
        {
            if (value == false)
                return 0;
            else
                return 1;
        }

        public static bool ToBool(this int value)
        {
            if (value == 0)
                return false;
            else
                return true;
        }

        #endregion


        #region BitArray <--> NetBitSet

        public static INetBitSet ToNetBitSet(this BitArray array)
        {
            return new NetBitSet(ToBoolArray(array));
        }

        public static BitArray ToBitArray(this INetBitSet obj)
        {
            return ToBitArray(obj.ToBoolArray());
        }

        #endregion


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
            byte[] temp = new byte[array.Length / 8];
            array.CopyTo(temp, 0);
            return temp[0];
        }

        // converts the BitArray object to 
        // its equivalent int value representation
        public static int ToInt(this BitArray array)
        {
            int[] temp = new int[array.Length / 32];
            array.CopyTo(temp, 0);
            return temp[0];
        }


        // converts the BitArray object to 
        // its equivalent array of bools representation
        public static bool[] ToBoolArray(this BitArray array)
        {
            bool[] temp = new bool[array.Length];
            array.CopyTo(temp, 0);
            return temp;
        }

        // converts the BitArray object to 
        // its equivalent array of bytes representation
        public static byte[] ToByteArray(this BitArray array, Endian endian = Endian.Little)
        {
            byte[] temp = new byte[array.Length / 8];
            array.CopyTo(temp, 0);

            if (endian == Endian.Big) Array.Reverse(temp);

            return temp;
        }

        // converts the BitArray object to 
        // its equivalent array of ints representation
        public static int[] ToIntArray(this BitArray array, Endian endian = Endian.Little)
        {
            int[] temp = new int[array.Length / 32];
            array.CopyTo(temp, 0);

            if (endian == Endian.Big) temp = temp.ReverseBytes();

            return temp;
        }



        // converts a bool value to its equivalent BitArray object
        public static BitArray ToBitArray(this bool value)
        {
            return new BitArray(new bool[] { value });
        }

        // converts a byte value to its equivalent BitArray object
        public static BitArray ToBitArray(this byte value)
        {
            return new BitArray(new byte[] { value });
        }

        // converts a int value to its equivalent BitArray object
        public static BitArray ToBitArray(this int value)
        {
            return new BitArray(new int[] { value });
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


        #region BitArray <--> object

        // converts object to its equivalent 
        // bit array, represented by BitArray type
        public static BitArray ToBitArray(this object obj)
        {
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                return new BitArray(stream.ToArray());
            }
        }

        // converts a BitArray object to its 
        // equivalent object instance if it's possible
        public static object ToObject(this BitArray array)
        {
            byte[] byteArray = ToByteArray(array);
            using (var stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                stream.Position = 0;
                return new BinaryFormatter().Deserialize(stream);
            }
        }

        #endregion


        #region BitArray <--> binary string and array of chars

        // converts the BitArray object to its 
        // equivalent binary string representation
        public static string ToBinaryString(this BitArray array, string bytesSeparator = "", Endian endian = Endian.Little)
        {
            if (endian == Endian.Big) array = array.ReverseBytes();

            char[] result = new char[array.Length];
            for (int i = 0, j = array.Length - 1; i < array.Length && j >= 0; i++, j--)
                // converting bools to ints (forming of array of chars)
                result[i] = array[j] == false ? '0' : '1';

            // array of chars --> string
            string sresult = new string(result);

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

            char[] result = new char[array.Length];
            for (int i = 0, j = array.Length - 1; i < array.Length && j >= 0; i++, j--)
                // converting bools to ints (forming of array of chars)
                result[i] = array[j] == false ? '0' : '1';

            return result;
        }


        // converts the binary string to its equivalent BitArray object
        public static BitArray ToBitArray(this string binaryString)
        {
            BitArray result = new BitArray(binaryString.Length);
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
            BitArray result = new BitArray(array.Length);
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
}