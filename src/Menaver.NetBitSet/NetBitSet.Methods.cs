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
            var (packIndex, bitIndex) = BitArrayBuilder.GetComplexIndex(index);
            return _containers[packIndex][bitIndex].ToBit();
        }
        set
        {
            var (packIndex, bitIndex) = BitArrayBuilder.GetComplexIndex(index);
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

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

    public object Clone()
    {
        var bitArraysCloned = _containers.Select(x => (BitArray)x.Clone()).ToArray();
        return new NetBitSet(bitArraysCloned, WordLength);
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
        return BitArrayConverter.ConvertToString(_containers, _defaultSystemEncoding);
    }

    public string ToString(Encoding encoding)
    {
        return BitArrayConverter.ConvertToString(_containers, encoding);
    }
}