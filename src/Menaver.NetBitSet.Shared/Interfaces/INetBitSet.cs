using System;
using System.Collections;

namespace Menaver.NetBitSet.Shared.Interfaces
{
    public enum Endian
    {
        Little = 0, Big = 1
    }

    public interface INetBitSet : ICollection, ICloneable
    {
        byte WordLength { get; }
        int BlocksCount { get; }
        float BytesCount { get; }


        int this[int index] { get; set; }

        #region SETTERS

        #region SET

        void Set(INetBitSet obj);
        void Set(string str, byte wordLength);
        void Set(char[] array, byte wordLength);
        void Set(object obj);


        void Set(bool value);
        void Set(byte value);
        void Set(int value);

        void Set(bool[] array);
        void Set(byte[] array);
        void Set(int[] array);

        #endregion

        #region TRYSET

        bool TrySet(INetBitSet obj);
        bool TrySet(string str, byte wordLength);
        bool TrySet(char[] array, byte wordLength);
        bool TrySet(object obj);


        bool TrySet(bool value);
        bool TrySet(byte value);
        bool TrySet(int value);

        bool TrySet(bool[] array);
        bool TrySet(byte[] array);
        bool TrySet(int[] array);

        #endregion

        #region FORCESET

        void ForceSet(INetBitSet obj);
        void ForceSet(string str, byte wordLength);
        void ForceSet(char[] array, byte wordLength);
        void ForceSet(object obj);


        void ForceSet(bool value);
        void ForceSet(byte value);
        void ForceSet(int value);

        void ForceSet(bool[] array);
        void ForceSet(byte[] array);
        void ForceSet(int[] array);

        #endregion

        void SetAll();
        void ResetAll();

        #endregion

        #region BITWISE

        void And(int position, int value);
        void AndAll(int value);

        void Or(int position, int value);
        void OrAll(int value);

        void Xor(int position, int value);
        void XorAll(int value);

        void Invert(int position);
        void InvertAll();

        void ShiftRight(int count, int shiftInValue = 0);
        void ShiftLeft(int count, int shiftInValue = 0);

        #endregion

        #region TOXXX

        string ToString(string bytesSeparator = "", Endian endian = Endian.Little);
        string ToBinaryString(string bytesSeparator = "", Endian endian = Endian.Little);

        char[] ToCharArray(Endian endian = Endian.Little);
        char[] ToBinaryCharArray(Endian endian = Endian.Little);

        object ToObject();

        ILFSR ToLFSR(int[] polynom);

        #region BASE TYPES

        bool ToBool();
        byte ToByte();
        int ToInt();
        bool[] ToBoolArray();
        byte[] ToByteArray(Endian endian = Endian.Little);
        int[] ToIntArray(Endian endian = Endian.Little);

        #endregion

        #region NUMERIC

        byte ToNumericAsByte();
        int ToNumericAsInt();

        #endregion

        #endregion

        void Resize(int newSize);
    }
}