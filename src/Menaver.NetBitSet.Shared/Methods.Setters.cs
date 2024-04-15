using System;
using System.Text;
using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Shared
{
    public partial class NetBitSet
    {
        #region SET

        public void Set(INetBitSet obj)
        {
            if (_wordLength != obj.WordLength)
                throw new Exception(GenerateErrorMessage(_wordLength));

            _container = obj.ToBitArray();
        }


        public void Set(string str, byte wordLength = 0)
        {
            if (str.IsBinary())
            {
                _wordLength = wordLength;

                // if wordLength do not match to data type (unspecified, bool, byte or int)
                if (_wordLength != 0)
                    if (str.Length % _wordLength != 0)
                        throw new ArgumentException(
                            "String length do not match to this kind of type specified by word length");

                // if word length is unspecified or match to any type
                _container = str.ToBitArray();
            }
            else
            {
                byte[] charCodes = Encoding.ASCII.GetBytes(str);
                _container = charCodes.ToBitArray();
                _wordLength = 8;
            }
        }

        public void Set(char[] array, byte wordLength = 0)
        {
            if (array.IsBinary())
            {
                _wordLength = wordLength;

                // if wordLength do not match to data type (bool, byte or int)
                if (_wordLength != 0)
                    if (array.Length % _wordLength != 0)
                        throw new ArgumentException(
                            "String length do not match to this kind of type specified by word length");

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


        public void Set(object obj)
        {
            _container = obj.ToBitArray();
            _wordLength = 0;
        }


        #region From base types and arrays

        public void Set(bool value)
        {
            if (_wordLength != 1)
                throw new Exception(GenerateErrorMessage(_wordLength));

            _container = value.ToBitArray();
        }

        public void Set(byte value)
        {
            if (_wordLength != 8)
                throw new Exception(GenerateErrorMessage(_wordLength));

            _container = value.ToBitArray();
        }

        public void Set(int value)
        {
            if (_wordLength != 32)
                throw new Exception(GenerateErrorMessage(_wordLength));

            _container = value.ToBitArray();
        }


        public void Set(bool[] array)
        {
            if (_wordLength != 1)
                throw new Exception(GenerateErrorMessage(_wordLength));

            _container = array.ToBitArray();
        }

        public void Set(byte[] array)
        {
            if (_wordLength != 8)
                throw new Exception(GenerateErrorMessage(_wordLength));

            _container = array.ToBitArray();
        }

        public void Set(int[] array)
        {
            if (_wordLength != 32)
                throw new Exception(GenerateErrorMessage(_wordLength));

            _container = array.ToBitArray();
        }

        #endregion

        #endregion


        #region TRYSET

        public bool TrySet(INetBitSet obj)
        {
            try
            {
                if (_wordLength != obj.WordLength)
                    return false;

                _container = obj.ToBitArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool TrySet(string str, byte wordLength = 0)
        {
            try
            {
                if (str.IsBinary())
                {
                    _wordLength = wordLength;

                    // if wordLength do not match to data type (unspecified, bool, byte or int)
                    if (_wordLength != 0)
                        if (str.Length % _wordLength != 0)
                            throw new ArgumentException(
                                "String length do not match to this kind of type specified by word length");

                    // if word length is unspecified or match to any type
                    _container = str.ToBitArray();
                    return true;
                }
                else
                {
                    byte[] charCodes = Encoding.ASCII.GetBytes(str);
                    _container = charCodes.ToBitArray();
                    _wordLength = 8;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TrySet(char[] array, byte wordLength = 0)
        {
            if (array.IsBinary())
            {
                _wordLength = wordLength;

                // if wordLength do not match to data type (bool, byte or int)
                if (_wordLength != 0)
                    if (array.Length % _wordLength != 0)
                        throw new ArgumentException(
                            "String length do not match to this kind of type specified by word length");

                // if word length is unspecified or match to any type
                _container = array.ToBitArray();
                return true;
            }
            else
            {
                byte[] charCodes = Encoding.ASCII.GetBytes(new string(array));
                _container = charCodes.ToBitArray();
                _wordLength = 8;
                return true;
            }
        }


        public bool TrySet(object obj)
        {
            try
            {
                _container = obj.ToBitArray();
                _wordLength = 0;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #region From base types and arrays

        public bool TrySet(bool value)
        {
            try
            {
                if (_wordLength != 1)
                    return false;

                _container = value.ToBitArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TrySet(byte value)
        {
            try
            {
                if (_wordLength != 8)
                    return false;

                _container = value.ToBitArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TrySet(int value)
        {
            try
            {
                if (_wordLength != 32)
                    return false;

                _container = value.ToBitArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool TrySet(bool[] array)
        {
            try
            {
                if (_wordLength != 1)
                    return false;

                _container = array.ToBitArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TrySet(byte[] array)
        {
            try
            {
                if (_wordLength != 8)
                    return false;

                _container = array.ToBitArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TrySet(int[] array)
        {
            try
            {
                if (_wordLength != 32)
                    return false;

                _container = array.ToBitArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #endregion


        #region FORCESET

        public void ForceSet(INetBitSet obj)
        {
            _container = obj.ToBitArray();
            _wordLength = obj.WordLength;
        }


        public void ForceSet(string str, byte wordLength = 0)
        {
            if (str.IsBinary())
            {
                _container = str.ToBitArray();
                _wordLength = wordLength;
            }
            else
            {
                byte[] charCodes = Encoding.ASCII.GetBytes(str);
                _container = charCodes.ToBitArray();
                _wordLength = 8;
            }
        }

        public void ForceSet(char[] array, byte wordLength = 0)
        {
            if (array.IsBinary())
            {
                _container = array.ToBitArray();
                _wordLength = wordLength;
            }
            else
            {
                byte[] charCodes = Encoding.ASCII.GetBytes(new string(array));
                _container = charCodes.ToBitArray();
                _wordLength = 8;
            }
        }


        public void ForceSet(object obj)
        {
            _container = obj.ToBitArray();
            _wordLength = 0;
        }


        #region From base types and arrays

        public void ForceSet(bool value)
        {
            _container = value.ToBitArray();
            _wordLength = 1;
        }

        public void ForceSet(byte value)
        {
            _container = value.ToBitArray();
            _wordLength = 8;
        }

        public void ForceSet(int value)
        {
            _container = value.ToBitArray();
            _wordLength = 32;
        }


        public void ForceSet(bool[] array)
        {
            _container = array.ToBitArray();
            _wordLength = 1;
        }

        public void ForceSet(byte[] array)
        {
            _container = array.ToBitArray();
            _wordLength = 8;
        }

        public void ForceSet(int[] array)
        {
            _container = array.ToBitArray();
            _wordLength = 32;
        }

        #endregion

        #endregion


        public void SetAll()
        {
            for (var i = 0; i < _container.Length; i++)
                _container[i] = true;
        }

        public void ResetAll()
        {
            for (var i = 0; i < _container.Length; i++)
                _container[i] = false;
        }
    }
}