using Menaver.NetBitSet.Extensions;
using Menaver.NetBitSet.Interfaces;
using Menaver.NetBitSet.Internals;

namespace Menaver.NetBitSet;

public partial class NetBitSet
{
    public void And(ulong position, bool bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] &= bit;
    }

    public void And(ulong position, byte bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] &= bit.ToBit().ToBool();
    }

    public void And(ulong position, int bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] &= bit.ToBit().ToBool();
    }

    public void And(ulong position, double bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] &= bit.ToBit().ToBool();
    }

    public void And(ulong position, Bit bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] &= bit.ToBool();
    }

    public void And(INetBitSet bitSet)
    {
        var countA = Count;
        var countB = bitSet.Count;

        if (countA != countB)
        {
            throw new InvalidOperationException($"The lengths do not match. Count A: {countA}. Count B: {countB}.");
        }

        for (ulong i = 0; i < countA; i++)
        {
            this[i] = (this[i].ToBool() & bitSet[i].ToBool()).ToBit();
        }
    }

    public void AndAll(bool bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] &= bit;
            }
        }
    }

    public void AndAll(byte bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] &= bit.ToBit().ToBool();
            }
        }
    }

    public void AndAll(int bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] &= bit.ToBit().ToBool();
            }
        }
    }

    public void AndAll(double bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] &= bit.ToBit().ToBool();
            }
        }
    }

    public void AndAll(Bit bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] &= bit.ToBool();
            }
        }
    }

    public void Or(ulong position, bool bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] |= bit;
    }

    public void Or(ulong position, byte bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] |= bit.ToBit().ToBool();
    }

    public void Or(ulong position, int bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] |= bit.ToBit().ToBool();
    }

    public void Or(ulong position, double bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] |= bit.ToBit().ToBool();
    }

    public void Or(ulong position, Bit bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] |= bit.ToBool();
    }

    public void Or(INetBitSet bitSet)
    {
        var countA = Count;
        var countB = bitSet.Count;

        if (countA != countB)
        {
            throw new InvalidOperationException($"The lengths do not match. Count A: {countA}. Count B: {countB}.");
        }

        for (ulong i = 0; i < countA; i++)
        {
            this[i] = (this[i].ToBool() | bitSet[i].ToBool()).ToBit();
        }
    }

    public void OrAll(bool bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] |= bit;
            }
        }
    }

    public void OrAll(byte bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] |= bit.ToBit().ToBool();
            }
        }
    }

    public void OrAll(int bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] |= bit.ToBit().ToBool();
            }
        }
    }

    public void OrAll(double bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] |= bit.ToBit().ToBool();
            }
        }
    }

    public void OrAll(Bit bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] |= bit.ToBool();
            }
        }
    }

    public void Xor(ulong position, bool bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] ^= bit;
    }

    public void Xor(ulong position, byte bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] ^= bit.ToBit().ToBool();
    }

    public void Xor(ulong position, int bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] ^= bit.ToBit().ToBool();
    }

    public void Xor(ulong position, double bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] ^= bit.ToBit().ToBool();
    }

    public void Xor(ulong position, Bit bit)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] ^= bit.ToBool();
    }

    public void Xor(INetBitSet bitSet)
    {
        var countA = Count;
        var countB = bitSet.Count;

        if (countA != countB)
        {
            throw new InvalidOperationException($"The lengths do not match. Count A: {countA}. Count B: {countB}.");
        }

        for (ulong i = 0; i < countA; i++)
        {
            this[i] = (this[i].ToBool() ^ bitSet[i].ToBool()).ToBit();
        }
    }

    public void XorAll(bool bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] ^= bit;
            }
        }
    }

    public void XorAll(byte bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] ^= bit.ToBit().ToBool();
            }
        }
    }

    public void XorAll(int bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] ^= bit.ToBit().ToBool();
            }
        }
    }

    public void XorAll(double bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] ^= bit.ToBit().ToBool();
            }
        }
    }

    public void XorAll(Bit bit)
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] ^= bit.ToBool();
            }
        }
    }

    public void Invert(ulong position)
    {
        var (packIndex, bitIndex) = BitArrayHelper.GetComplexIndex(position);
        _containers[packIndex][bitIndex] = !_containers[packIndex][bitIndex];
    }

    public void InvertAll()
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] = !_containers[i][k];
            }
        }
    }

    public void SetAll()
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] = true;
            }
        }
    }

    public void ResetAll()
    {
        for (var i = 0; i < _containers.Length; i++)
        {
            for (var k = 0; k < _containers[i].Count; k++)
            {
                _containers[i][k] = false;
            }
        }
    }

    public void ArithmeticShiftRight(ulong count)
    {
        ShiftRight(count, this[Count - 1]);
    }

    public void LogicalShiftRight(ulong count)
    {
        ShiftRight(count, Bit.False);
    }

    public void CircularShiftRight(ulong count)
    {
        for (ulong i = 0; i < count; i++)
        {
            ShiftRight(1, this[0]);
        }
    }

    public void ArithmeticShiftLeft(ulong count)
    {
        ShiftLeft(count, Bit.False);
    }

    public void LogicalShiftLeft(ulong count)
    {
        ShiftLeft(count, Bit.False);
    }

    public void CircularShiftLeft(ulong count)
    {
        for (ulong i = 0; i < count; i++)
        {
            ShiftLeft(1, this[Count - 1]);
        }
    }

    public void ShiftRight(ulong count, bool shiftInBit)
    {
        ShiftRight(count, shiftInBit.ToBit());
    }

    public void ShiftRight(ulong count, byte shiftInBit)
    {
        ShiftRight(count, shiftInBit.ToBit());
    }

    public void ShiftRight(ulong count, int shiftInBit)
    {
        ShiftRight(count, shiftInBit.ToBit());
    }

    public void ShiftRight(ulong count, double shiftInBit)
    {
        ShiftRight(count, shiftInBit.ToBit());
    }

    public void ShiftLeft(ulong count, bool shiftInBit)
    {
        ShiftLeft(count, shiftInBit.ToBit());
    }

    public void ShiftLeft(ulong count, byte shiftInBit)
    {
        ShiftLeft(count, shiftInBit.ToBit());
    }

    public void ShiftLeft(ulong count, int shiftInBit)
    {
        ShiftLeft(count, shiftInBit.ToBit());
    }

    public void ShiftLeft(ulong count, double shiftInBit)
    {
        ShiftLeft(count, shiftInBit.ToBit());
    }

    public void ShiftLeft(ulong count, Bit shiftInBit)
    {
        var elementCount = Count;
        var iterationCount = elementCount - 1;

        for (ulong i = 0; i < count; i++)
        {
            if (elementCount <= int.MaxValue)
            {
                // a little optimization: if element count fits the 1-dimensional BitArray size limit,
                // let's then do the shift over this array only,
                // without needing to calculate a complex index on each iteration

                var shiftInBitBool = shiftInBit.ToBool();
                var iterationCountInt = (int)iterationCount;

                for (var j = iterationCountInt; j > 0; j--)
                {
                    _containers[0][j] = _containers[0][j - 1];
                }

                _containers[0][0] = shiftInBitBool;
            }
            else
            {
                for (var j = iterationCount; j > 0; j--)
                {
                    this[j] = this[j - 1];
                }

                this[0] = shiftInBit;
            }
        }
    }

    public void ShiftRight(ulong count, Bit shiftInBit)
    {
        var elementCount = Count;
        var iterationCount = elementCount - 1;

        for (ulong i = 0; i < count; i++)
        {
            if (elementCount <= int.MaxValue)
            {
                // a little optimization: if element count fits the 1-dimensional BitArray size limit,
                // let's then do the shift over this array only,
                // without needing to calculate a complex index on each iteration

                var shiftInBitBool = shiftInBit.ToBool();
                var iterationCountInt = (int)iterationCount;

                for (var j = 0; j < iterationCountInt; j++)
                {
                    _containers[0][j] = _containers[0][j + 1];
                }

                _containers[0][iterationCountInt] = shiftInBitBool;
            }
            else
            {
                for (ulong j = 0; j < iterationCount; j++)
                {
                    this[j] = this[j + 1];
                }

                this[iterationCount] = shiftInBit;
            }
        }
    }
}