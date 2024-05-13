using System.Collections;
using System.Text;
using Menaver.NetBitSet.Extensions;
using Menaver.NetBitSet.Internals;

namespace Menaver.NetBitSet;

public partial class NetBitSet
{
    /// <summary>
    ///     The indexer.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <returns>The bit stored by the index specified.</returns>
    public Bit this[ulong index]
    {
        get
        {
            var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(index);
            return _containers[packIndex][bitIndex].ToBit();
        }
        set
        {
            var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(index);
            _containers[packIndex][bitIndex] = value.ToBool();
        }
    }

    /// <summary>
    ///     Resized the structure: reduces or extends depending on the parameter value.
    /// </summary>
    /// <param name="newSize">The new size, in bits.</param>
    public void Resize(ulong newSize)
    {
        _containers = BitArrayBuilder.ResizeBitArrays(_containers, newSize);
    }

    /// <summary>
    ///     Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    ///     An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the
    ///     collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public IEnumerator<Bit> GetEnumerator()
    {
        foreach (var container in _containers)
        {
            foreach (bool bit in container)
            {
                yield return bit.ToBit();
            }
        }
    }

    /// <summary>
    ///     Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public object Clone()
    {
        var bitArraysCloned = _containers.Select(x => (BitArray)x.Clone()).ToArray();
        return new NetBitSet(bitArraysCloned, WordLength);
    }

    /// <summary>Determines whether the specified object is equal to the current object.</summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
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

    /// <summary>Serves as the default hash function.</summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return unchecked((_containers.Sum(x => x.GetHashCode()) * 4873)
                         ^ WordLength.GetHashCode()
                         ^ Endianness.GetHashCode());
    }

    /// <summary>
    ///     Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return BitArrayConverter.ConvertToString(_containers, DefaultSystemEncoding);
    }

    /// <summary>
    ///     Returns a string in a given encoding that represents the current object.
    /// </summary>
    /// <param name="encoding">The encoding the string is driven by.</param>
    /// <returns>A string that represents the current object.</returns>
    public string ToString(Encoding encoding)
    {
        return BitArrayConverter.ConvertToString(_containers, encoding);
    }
}