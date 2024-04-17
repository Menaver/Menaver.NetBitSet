using System.Collections;
using Menaver.NetBitSet.Shared.Internals;

namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    public Bit this[ulong index]
    {
        get
        {
            var (packIndex, bitIndex) = BitArrayBuilder.GetComplexIndex(index);
            return _containers[packIndex][bitIndex].ToBit();
        }
        set
        {
            var (packIndex, bitIndex) = BitArrayBuilder.GetComplexIndex(index);
            _containers[packIndex][bitIndex] = value.ToBool();
        }
    }

    public void Resize(ulong newSize)
    {
        _containers = BitArrayBuilder.ResizeBitArrays(_containers, newSize);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<Bit> GetEnumerator()
    {
        foreach (var bit in _containers.SelectMany(BitArrayConverter.ConvertToBools))
        {
            yield return bit.ToBit();
        }
    }

    public object Clone()
    {
        var bitArraysCloned = _containers.Select(x => (BitArray)x.Clone()).ToArray();
        return new NetBitSet(bitArraysCloned, (WordLength)WordLength, Endianness);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != typeof(NetBitSet)) return false;

        return Equals((NetBitSet)obj);
    }

    private bool Equals(NetBitSet other)
    {
        if (WordLength != other.WordLength)
            return false;

        if (Endianness != other.Endianness)
            return false;

        if (_containers.Length != other._containers.Length)
            return false;

        if (Count != other.Count)
            return false;

        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                if (_containers[i][k] != other._containers[i][k])
                    return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return unchecked((_containers.Sum(x => x.GetHashCode()) * 4873)
                         ^ WordLength.GetHashCode()
                         ^ Endianness.GetHashCode());
    }

    public override string ToString()
    {
        return BitArrayConverter.ConvertToString(_containers, Endianness);
    }













    //public void SetAll()
    //{
    //    for (var i = 0; i < _containers.Length; i++)
    //        _containers[i] = true;
    //}

    //public void ResetAll()
    //{
    //    for (var i = 0; i < _containers.Length; i++)
    //        _containers[i] = false;
    //}

    //#region IMPLEMENTATIONS & OVERRIDES


    //#endregion


    //#region BITWISE


    //public void AndAll(int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    for (var i = 0; i < _containers.Count; i++)
    //        _containers[i] = _containers[i] & bValue;
    //}




    //public void OrAll(int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    for (var i = 0; i < _containers.Count; i++)
    //        _containers[i] = _containers[i] | bValue;
    //}
    

    //public void XorAll(int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    for (var i = 0; i < _containers.Count; i++)
    //        _containers[i] = _containers[i] ^ bValue;
    //}


    //public void Invert(int position)
    //{
    //    _containers[position] = !_containers[position];
    //}

    //public void InvertAll()
    //{
    //    for (var i = 0; i < _containers.Count; i++)
    //        _containers[i] = !_containers[i];
    //}


    //public void ShiftRight(int count, int shiftInValue = 0)
    //{
    //    for (var i = 0; i < count; i++)
    //    {
    //        for (var j = 0; j < Count - 1; j++)
    //            this[j] = this[j + 1];

    //        this[Count - 1] = shiftInValue;
    //    }
    //}

    //public void ShiftLeft(int count, int shiftInValue = 0)
    //{
    //    for (var i = 0; i < count; i++)
    //    {
    //        for (var j = Count - 1; j > 0; j--)
    //            this[j] = this[j - 1];

    //        this[0] = shiftInValue;
    //    }
    //}

    //#endregion

    


    //public string ToString(string bytesSeparator = "", Endian endian = Endian.Little)
    //{
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
    //}


    //public string ToBinaryString(string bytesSeparator = "", Endian endian = Endian.Little)
    //{
    //    return _containers.ToBinaryString(bytesSeparator, endian);
    //}


    //public char[] ToCharArray(Endian endian = Endian.Little)
    //{
    //    if (WordLength == 8)
    //    {
    //        // convert to non-binary char set

    //        var bytes = _containers.ToByteArray(endian);

    //        if (endian == Endian.Big) Array.Reverse(bytes);

    //        return Encoding.Unicode.GetChars(bytes);
    //    }

    //    return _containers.ToCharArray(endian);
    //}

    //public char[] ToBinaryCharArray(Endian endian = Endian.Little)
    //{
    //    return _containers.ToCharArray(endian);
    //}


    //public object ToObject()
    //{
    //    return _containers.ToObject();
    //}


    //#region BASE TYPES

    //public bool ToBool()
    //{
    //    return _containers.ToBool();
    //}

    //public byte ToByte()
    //{
    //    if (WordLength != 8)
    //    {
    //        // note: use temp container to protect current data

    //        // resizing to convert to this king of type
    //        var temp = (BitArray)_containers.Clone();
    //        temp.Length = GetNewArraySize(temp.Length, 8);
    //        return temp.ToByte();
    //    }

    //    return _containers.ToByte();
    //}

    //public int ToInt()
    //{
    //    if (WordLength != 32)
    //    {
    //        // note: use temp container to protect current data

    //        // resizing to convert to this king of type
    //        var temp = (BitArray)_containers.Clone();
    //        temp.Length = GetNewArraySize(temp.Length, 32);
    //        return temp.ToInt();
    //    }

    //    return _containers.ToInt();
    //}


    //public bool[] ToBoolArray()
    //{
    //    return _containers.ToBoolArray();
    //}

    //public byte[] ToByteArray(Endian endian = Endian.Little)
    //{
    //    if (WordLength != 8)
    //    {
    //        // note: use temp container to protect current data

    //        // resizing to convert to this king of type
    //        var temp = (BitArray)_containers.Clone();
    //        temp.Length = GetNewArraySize(temp.Length, 8);
    //        return temp.ToByteArray();
    //    }

    //    return _containers.ToByteArray(endian);
    //}

    //public int[] ToIntArray(Endian endian = Endian.Little)
    //{
    //    if (WordLength != 32)
    //    {
    //        // note: use temp container to protect current data

    //        // resizing to convert to this king of type
    //        var temp = (BitArray)_containers.Clone();
    //        temp.Length = GetNewArraySize(temp.Length, 32);
    //        return temp.ToIntArray(endian);
    //    }

    //    return _containers.ToIntArray(endian);
    //}

    //#endregion


    //#region NUMERIC

    //public byte ToNumericAsByte()
    //{
    //    // if data type is...
    //    switch (WordLength)
    //    {
    //        case 8:
    //            return _containers.ToByte();
    //        default:
    //            {
    //                // resizing to convert to byte
    //                var temp = (BitArray)_containers.Clone();
    //                temp.Length = 8;
    //                return temp.ToByte();
    //            }
    //    }
    //}

    //public int ToNumericAsInt()
    //{
    //    // if data type is...
    //    switch (WordLength)
    //    {
    //        case 32:
    //            return _containers.ToInt();
    //        default:
    //            {
    //                // resizing to convert to int
    //                var temp = (BitArray)_containers.Clone();
    //                temp.Length = 32;
    //                return temp.ToInt();
    //            }
    //    }
    //}

    //#endregion
}