using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Shared
{
    public partial class NetBitSet
    {
        public static object BinaryStringToObject(string binaryString, Endian endian = Endian.Little)
        {
            if (string.IsNullOrEmpty(binaryString))
                throw new NullReferenceException("Binary string can not be null or empty");

            BitArray bitArray = binaryString.ToBitArray();

            if (endian == Endian.Big) bitArray = bitArray.ReverseBytes();

            byte[] byteArray = bitArray.ToByteArray();

            using (var stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                stream.Position = 0;

                return new BinaryFormatter().Deserialize(stream);
            }
        }

        public static string ObjectToBinaryString(object obj, string bytesSeparator = "", Endian endian = Endian.Little)
        {
            BitArray temp;
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                temp = new BitArray(stream.ToArray());
            }

            return temp.ToBinaryString(bytesSeparator, endian);
        }


        public static long GetObjectSize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                return stream.Length;
            }
        }
    }
}