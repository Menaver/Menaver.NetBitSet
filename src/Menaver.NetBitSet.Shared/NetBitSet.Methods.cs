using System.Collections;
using Menaver.NetBitSet.Shared.Extras;

namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    public Bit this[ulong index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public void Resize(ulong newSize)
    {
        _container.Length = (int)newSize;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    int ICollection.Count { get; }

    public object Clone()
    {
        throw new NotImplementedException();
    }


    //public void SetAll()
    //{
    //    for (var i = 0; i < _container.Length; i++)
    //        _container[i] = true;
    //}

    //public void ResetAll()
    //{
    //    for (var i = 0; i < _container.Length; i++)
    //        _container[i] = false;
    //}

    //#region IMPLEMENTATIONS & OVERRIDES

    //public override bool Equals(object obj)
    //{
    //    if (ReferenceEquals(null, obj)) return false;
    //    if (ReferenceEquals(this, obj)) return true;
    //    if (obj.GetType() != typeof(NetBitSet)) return false;
    //    return Equals((NetBitSet)obj);
    //}

    //public override int GetHashCode()
    //{
    //    return unchecked(((_container != null ? _container.GetHashCode() : 0) * 873) ^ WordLength.GetHashCode());
    //}


    //public int this[int index]
    //{
    //    // represents all bits (bools) as numbers (ints): 0 --> false, any other value --> true

    //    get => _container[index] == false ? 0 : 1;
    //    set => _container[index] = value != 0;
    //}


    //IEnumerator IEnumerable.GetEnumerator()
    //{
    //    return GetEnumerator();
    //}

    //public IEnumerator<int> GetEnumerator()
    //{
    //    foreach (bool bit in _container)
    //        // converting of bools to ints
    //        yield return bit == false ? 0 : 1;
    //}


    //public void CopyTo(Array array, int index = 0)
    //{
    //    _container.CopyTo(array, index);
    //}


    //public object Clone()
    //{
    //    return new NetBitSet { _container = (BitArray)_container.Clone(), WordLength = WordLength };
    //}

    //private bool Equals(NetBitSet other)
    //{
    //    if (_container.Count != other._container.Count)
    //        return false;

    //    for (var i = 0; i < _container.Count; i++)
    //        if (_container[i] != other._container[i])
    //            return false;

    //    if (_container.IsReadOnly != other._container.IsReadOnly)
    //        return false;

    //    if (_container.IsSynchronized != other._container.IsSynchronized)
    //        return false;

    //    if (WordLength != other.WordLength)
    //        return false;

    //    return true;
    //}

    //#endregion


    //#region BITWISE

    //public void And(int position, int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    _container[position] = _container[position] & bValue;
    //}

    //public void AndAll(int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    for (var i = 0; i < _container.Count; i++)
    //        _container[i] = _container[i] & bValue;
    //}


    //public void Or(int position, int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    _container[position] = _container[position] | bValue;
    //}

    //public void OrAll(int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    for (var i = 0; i < _container.Count; i++)
    //        _container[i] = _container[i] | bValue;
    //}


    //public void Xor(int position, int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    _container[position] = _container[position] ^ bValue;
    //}

    //public void XorAll(int value)
    //{
    //    // converting bool to int
    //    var bValue = value != 0;
    //    for (var i = 0; i < _container.Count; i++)
    //        _container[i] = _container[i] ^ bValue;
    //}


    //public void Invert(int position)
    //{
    //    _container[position] = !_container[position];
    //}

    //public void InvertAll()
    //{
    //    for (var i = 0; i < _container.Count; i++)
    //        _container[i] = !_container[i];
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


    //// generate error message in case of mismatch 
    //// of word length and required type to convert
    //private static string GenerateErrorMessage(byte wordLength)
    //{
    //    var errorMessage = $"Word length ({wordLength}) does not match to this kind of type. Data type is ";

    //    switch (wordLength)
    //    {
    //        case 1:
    //            errorMessage += "bool (1-bit values)";
    //            break;
    //        case 8:
    //            errorMessage += "byte (8-bit values)";
    //            break;
    //        case 32:
    //            errorMessage += "int (32-bit values)";
    //            break;
    //        default:
    //            errorMessage += "unspecified";
    //            break;
    //    }

    //    return errorMessage;
    //}


    //// calculate new size to match of wordLength to required type to convert
    //private static int GetNewArraySize(int currentBitCount, int wordLength)
    //{
    //    var temp = currentBitCount % wordLength;

    //    if (temp == 0)
    //        // if current bit count in array is in accordance with wordLength
    //        return currentBitCount;
    //    // if it is not then expand to accordance
    //    return currentBitCount + (wordLength - temp);
    //}


    //public string ToString(string bytesSeparator = "", Endian endian = Endian.Little)
    //{
    //    if (WordLength == 8)
    //    {
    //        // convert to non-binary string

    //        var bytes = _container.ToByteArray();

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

    //    return _container.ToBinaryString(bytesSeparator, endian);
    //}


    //public string ToBinaryString(string bytesSeparator = "", Endian endian = Endian.Little)
    //{
    //    return _container.ToBinaryString(bytesSeparator, endian);
    //}


    //public char[] ToCharArray(Endian endian = Endian.Little)
    //{
    //    if (WordLength == 8)
    //    {
    //        // convert to non-binary char set

    //        var bytes = _container.ToByteArray(endian);

    //        if (endian == Endian.Big) Array.Reverse(bytes);

    //        return Encoding.Unicode.GetChars(bytes);
    //    }

    //    return _container.ToCharArray(endian);
    //}

    //public char[] ToBinaryCharArray(Endian endian = Endian.Little)
    //{
    //    return _container.ToCharArray(endian);
    //}


    //public object ToObject()
    //{
    //    return _container.ToObject();
    //}


    //#region BASE TYPES

    //public bool ToBool()
    //{
    //    return _container.ToBool();
    //}

    //public byte ToByte()
    //{
    //    if (WordLength != 8)
    //    {
    //        // note: use temp container to protect current data

    //        // resizing to convert to this king of type
    //        var temp = (BitArray)_container.Clone();
    //        temp.Length = GetNewArraySize(temp.Length, 8);
    //        return temp.ToByte();
    //    }

    //    return _container.ToByte();
    //}

    //public int ToInt()
    //{
    //    if (WordLength != 32)
    //    {
    //        // note: use temp container to protect current data

    //        // resizing to convert to this king of type
    //        var temp = (BitArray)_container.Clone();
    //        temp.Length = GetNewArraySize(temp.Length, 32);
    //        return temp.ToInt();
    //    }

    //    return _container.ToInt();
    //}


    //public bool[] ToBoolArray()
    //{
    //    return _container.ToBoolArray();
    //}

    //public byte[] ToByteArray(Endian endian = Endian.Little)
    //{
    //    if (WordLength != 8)
    //    {
    //        // note: use temp container to protect current data

    //        // resizing to convert to this king of type
    //        var temp = (BitArray)_container.Clone();
    //        temp.Length = GetNewArraySize(temp.Length, 8);
    //        return temp.ToByteArray();
    //    }

    //    return _container.ToByteArray(endian);
    //}

    //public int[] ToIntArray(Endian endian = Endian.Little)
    //{
    //    if (WordLength != 32)
    //    {
    //        // note: use temp container to protect current data

    //        // resizing to convert to this king of type
    //        var temp = (BitArray)_container.Clone();
    //        temp.Length = GetNewArraySize(temp.Length, 32);
    //        return temp.ToIntArray(endian);
    //    }

    //    return _container.ToIntArray(endian);
    //}

    //#endregion


    //#region NUMERIC

    //public byte ToNumericAsByte()
    //{
    //    // if data type is...
    //    switch (WordLength)
    //    {
    //        case 8:
    //            return _container.ToByte();
    //        default:
    //            {
    //                // resizing to convert to byte
    //                var temp = (BitArray)_container.Clone();
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
    //            return _container.ToInt();
    //        default:
    //            {
    //                // resizing to convert to int
    //                var temp = (BitArray)_container.Clone();
    //                temp.Length = 32;
    //                return temp.ToInt();
    //            }
    //    }
    //}

    //#endregion
}