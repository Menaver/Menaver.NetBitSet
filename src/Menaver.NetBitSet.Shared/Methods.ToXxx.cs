using System;
using System.Text;
using System.Collections;
using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Shared
{
    public partial class NetBitSet
    {
        public string ToString(string bytesSeparator = "", Endian endian = Endian.Little)
        {
            if (_wordLength == 8)
            {
                // convert to non-binary string

                byte[] bytes = _container.ToByteArray();

                if (endian == Endian.Big) Array.Reverse(bytes);

                char[] chars = Encoding.ASCII.GetChars(bytes);

                if (bytesSeparator != "")
                {
                    string separatedChars = "";
                    for (var i = 0; i < chars.Length; i++)
                    {
                        separatedChars += chars[i];

                        if (i < chars.Length - 1)  // for the last one skip adding bytesSeparator
                            separatedChars += bytesSeparator;
                    }

                    return separatedChars;
                }

                return new string(chars);
            }
            else
                return _container.ToBinaryString(bytesSeparator, endian);
        }


        public string ToBinaryString(string bytesSeparator = "", Endian endian = Endian.Little)
        {
            return _container.ToBinaryString(bytesSeparator, endian);
        }


        public char[] ToCharArray(Endian endian = Endian.Little)
        {
            if (_wordLength == 8)
            {
                // convert to non-binary char set

                byte[] bytes = _container.ToByteArray(endian);

                if (endian == Endian.Big) Array.Reverse(bytes);

                return Encoding.ASCII.GetChars(bytes);
            }
            else
                return _container.ToCharArray(endian);
        }

        public char[] ToBinaryCharArray(Endian endian = Endian.Little)
        {
            return _container.ToCharArray(endian);
        }


        public object ToObject()
        {
            return _container.ToObject();
        }


        public ILFSR ToLFSR(int[] polynom)
        {
            return new LFSR((NetBitSet)this.Clone(), polynom);
        }


        #region BASE TYPES

        public bool ToBool()
        {
            return _container.ToBool();
        }

        public byte ToByte()
        {
            if (_wordLength != 8)
            {
                // note: use temp container to protect current data

                // resizing to convert to this king of type
                BitArray temp = (BitArray)_container.Clone();
                temp.Length = GetNewArraySize(temp.Length, 8);
                return temp.ToByte();
            }

            return _container.ToByte();
        }

        public int ToInt()
        {
            if (_wordLength != 32)
            {
                // note: use temp container to protect current data

                // resizing to convert to this king of type
                BitArray temp = (BitArray)_container.Clone();
                temp.Length = GetNewArraySize(temp.Length, 32);
                return temp.ToInt();
            }

            return _container.ToInt();
        }


        public bool[] ToBoolArray()
        {
            return _container.ToBoolArray();
        }

        public byte[] ToByteArray(Endian endian = Endian.Little)
        {
            if (_wordLength != 8)
            {
                // note: use temp container to protect current data

                // resizing to convert to this king of type
                BitArray temp = (BitArray)_container.Clone();
                temp.Length = GetNewArraySize(temp.Length, 8);
                return temp.ToByteArray();
            }

            return _container.ToByteArray(endian);
        }

        public int[] ToIntArray(Endian endian = Endian.Little)
        {
            if (_wordLength != 32)
            {
                // note: use temp container to protect current data

                // resizing to convert to this king of type
                BitArray temp = (BitArray)_container.Clone();
                temp.Length = GetNewArraySize(temp.Length, 32);
                return temp.ToIntArray(endian);
            }

            return _container.ToIntArray(endian);
        }

        #endregion


        #region NUMERIC

        public byte ToNumericAsByte()
        {
            // if data type is...
            switch (_wordLength)
            {
                case 8:
                    return _container.ToByte();
                default:
                    {
                        // resizing to convert to byte
                        BitArray temp = (BitArray)_container.Clone();
                        temp.Length = 8;
                        return temp.ToByte();
                    }
            }
        }

        public int ToNumericAsInt()
        {
            // if data type is...
            switch (_wordLength)
            {
                case 32:
                    return _container.ToInt();
                default:
                    {
                        // resizing to convert to int
                        BitArray temp = (BitArray)_container.Clone();
                        temp.Length = 32;
                        return temp.ToInt();
                    }
            }
        }

        #endregion
    }
}