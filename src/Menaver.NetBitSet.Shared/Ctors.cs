using System;
using System.Text;
using System.Collections;
using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Shared
{
    public partial class NetBitSet
    {
        public NetBitSet()
        {
            _container = new BitArray(0, false);
            _wordLength = 0;
        }



        public NetBitSet(int count, byte wordLength = 0, int defaultValue = 0)
        {
            _container = new BitArray(count, defaultValue.ToBool());
            _wordLength = wordLength;
        }


        public NetBitSet(INetBitSet obj)
        {
            _container = obj.ToBitArray();
            _wordLength = obj.WordLength;
        }


        public NetBitSet(string str, byte wordLength = 0)
        {
            if (str.IsBinary())
            {
                _wordLength = wordLength;

                // if wordLength do not match to data type (unspecified, bool, byte or int)
                if (_wordLength != 0)
                    if (str.Length % _wordLength != 0)
                        throw new ArgumentException("String length do not match to this kind of type specified by wordLength");

                // if word length is unspecified or match to any data type
                _container = str.ToBitArray();
            }
            else
            {
                byte[] charCodes = Encoding.ASCII.GetBytes(str);
                _container = charCodes.ToBitArray();
                _wordLength = 8;
            }
        }

        public NetBitSet(char[] array, byte wordLength = 0)
        {
            if (array.IsBinary())
            {
                _wordLength = wordLength;

                // if wordLength do not match to data type (bool, byte or int)
                if (_wordLength != 0)
                    if (array.Length % _wordLength != 0)
                        throw new ArgumentException("Array length do not match to this kind of type specified by wordLength");

                // if word length is unspecified or match to any type
                _container = array.ToBitArray();
            }
            else
            {
                byte[] charCodes = Encoding.ASCII.GetBytes(new string(array));
                _container = charCodes.ToBitArray();
                _wordLength = 8;
            }
        }


        public NetBitSet(object obj)
        {
            _container = obj.ToBitArray();
            _wordLength = 8;
        }


        #region FROM BASE TYPES AND BASE-TYPED ARRAYS

        public NetBitSet(bool value)
        {
            _container = value.ToBitArray();
            _wordLength = 1;
        }

        public NetBitSet(byte value)
        {
            _container = value.ToBitArray();
            _wordLength = 8;
        }

        public NetBitSet(int value)
        {
            _container = value.ToBitArray();
            _wordLength = 32;
        }


        public NetBitSet(bool[] array)
        {
            _container = array.ToBitArray();
            _wordLength = 1;
        }

        public NetBitSet(byte[] array)
        {
            _container = array.ToBitArray();
            _wordLength = 8;
        }

        public NetBitSet(int[] array)
        {
            _container = array.ToBitArray();
            _wordLength = 32;
        }

        #endregion
    }
}