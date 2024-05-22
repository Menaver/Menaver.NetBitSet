using Menaver.NetBitSet.Extensions;

namespace Menaver.NetBitSet.LFSR;

/// <summary>
///     Represents an implementation of a linear-feedback shift register (LFSR).
/// </summary>
public class LFSR : ILFSR
{
    /// <summary>
    ///     The bit-set container.
    /// </summary>
    private readonly NetBitSet _container;

    /// <summary>
    ///     The numbers representing a feedback polynomial.
    /// </summary>
    private readonly ulong[] _polynomial;

    /// <summary>
    ///     Constructs the instance.
    /// </summary>
    /// <param name="container">The bit-set data container.</param>
    /// <param name="polynomial">The numbers representing a feedback polynomial.</param>
    /// <exception cref="ArgumentException"></exception>
    public LFSR(NetBitSet container, ulong[] polynomial)
    {
        if (container == null || container.Count < 2)
        {
            throw new ArgumentException("Container must be not-null and contain at least 2 bits.");
        }

        if (polynomial == null || !polynomial.Any())
        {
            throw new ArgumentException("Polynomial must be not-null and not-empty array of numbers.");
        }

        if (polynomial.Any(index => index >= container.Count))
        {
            throw new ArgumentException("One of the polynomial numbers is greater than the container's length.");
        }

        _container = container;
        _polynomial = polynomial;
    }

    /// <summary>
    ///     Performs the shift operation.
    /// </summary>
    /// <returns>The output bit.</returns>
    public Bit Shift()
    {
        var containerLength = _container.Count;

        var outBits = containerLength switch
        {
            8 => ShiftAsByte(1),
            16 => ShiftAsShort(1),
            32 => ShiftAsInt(1),
            64 => ShiftAsLong(1),
            _ => ShiftAsFreeLength(1)
        };

        return outBits[0];
    }

    /// <summary>
    ///     Performs a sequence of N shift operations, where N is defined by count.
    /// </summary>
    /// <param name="count">The number of shift operations.</param>
    /// <returns>The output bits.</returns>
    public Bit[] Shift(ulong count)
    {
        var containerLength = _container.Count;

        return containerLength switch
        {
            8 => ShiftAsByte(count),
            16 => ShiftAsShort(count),
            32 => ShiftAsInt(count),
            64 => ShiftAsLong(count),
            _ => ShiftAsFreeLength(count)
        };
    }

    private Bit[] ShiftAsByte(ulong count)
    {
        const byte resetValue = 1;
        const int resetShiftCount = 7;

        var outBits = new Bit[count];

        var register = _container.ToByte();

        for (ulong i = 0; i < count; i++)
        {
            var shiftOutBit = (byte)(register & resetValue);
            outBits[i] = shiftOutBit == 0 ? Bit.False : Bit.True;

            var xors = new byte[_polynomial.Length];
            for (var j = 0; j < _polynomial.Length; j++)
            {
                xors[j] = (byte)(register >> (int)_polynomial[j]);
            }

            var xored = xors[0];
            for (var j = 1; j < xors.Length; j++)
            {
                xored = (byte)(xored ^ xors[j]);
            }

            var shiftInBit = (byte)(xored & resetValue);
            shiftInBit = (byte)(shiftInBit << resetShiftCount);

            register >>= 1;
            register = (byte)(register | shiftInBit);
        }

        return outBits;
    }

    private Bit[] ShiftAsShort(ulong count)
    {
        const ushort resetValue = 1;
        const int resetShiftCount = 15;

        var outBits = new Bit[count];

        var register = _container.ToUShort();

        for (ulong i = 0; i < count; i++)
        {
            var shiftOutBit = (ushort)(register & resetValue);
            outBits[i] = shiftOutBit == 0 ? Bit.False : Bit.True;

            var xors = new ushort[_polynomial.Length];
            for (var j = 0; j < _polynomial.Length; j++)
            {
                xors[j] = (ushort)(register >> (int)_polynomial[j]);
            }

            var xored = xors[0];
            for (var j = 1; j < xors.Length; j++)
            {
                xored = (ushort)(xored ^ xors[j]);
            }

            var shiftInBit = (ushort)(xored & resetValue);
            shiftInBit = (ushort)(shiftInBit << resetShiftCount);

            register >>= 1;
            register = (ushort)(register | shiftInBit);
        }

        return outBits;
    }

    private Bit[] ShiftAsInt(ulong count)
    {
        const uint resetValue = 1;
        const int resetShiftCount = 31;

        var outBits = new Bit[count];

        var register = _container.ToUInt();

        for (ulong i = 0; i < count; i++)
        {
            var shiftOutBit = register & resetValue;
            outBits[i] = shiftOutBit == 0 ? Bit.False : Bit.True;

            var xors = new uint[_polynomial.Length];
            for (var j = 0; j < _polynomial.Length; j++)
            {
                xors[j] = register >> (int)_polynomial[j];
            }

            var xored = xors[0];
            for (var j = 1; j < xors.Length; j++)
            {
                xored = xored ^ xors[j];
            }

            var shiftInBit = xored & resetValue;
            shiftInBit = shiftInBit << resetShiftCount;

            register >>= 1;
            register = register | shiftInBit;
        }

        return outBits;
    }

    private Bit[] ShiftAsLong(ulong count)
    {
        const ulong resetValue = 1;
        const int resetShiftCount = 63;

        var outBits = new Bit[count];

        var register = _container.ToULong();

        for (ulong i = 0; i < count; i++)
        {
            var shiftOutBit = register & resetValue;
            outBits[i] = shiftOutBit == 0 ? Bit.False : Bit.True;

            var xors = new ulong[_polynomial.Length];
            for (var j = 0; j < _polynomial.Length; j++)
            {
                xors[j] = register >> (int)_polynomial[j];
            }

            var xored = xors[0];
            for (var j = 1; j < xors.Length; j++)
            {
                xored = xored ^ xors[j];
            }

            var shiftInBit = xored & resetValue;
            shiftInBit = shiftInBit << resetShiftCount;

            register >>= 1;
            register = register | shiftInBit;
        }

        return outBits;
    }

    private Bit[] ShiftAsFreeLength(ulong count)
    {
        var outBits = new bool[count];

        for (ulong i = 0; i < count; i++)
        {
            outBits[i] = _container[0].ToBool();

            var inBit = _container[_polynomial[0]].ToBool();

            for (var j = 1; j < _polynomial.Length; j++)
            {
                inBit ^= _container[_polynomial[j]].ToBool();
            }

            _container.ShiftRight(1, inBit);
        }

        var result = new Bit[count];
        for (ulong i = 0; i < count; i++)
        {
            result[i] = outBits[i] ? Bit.True : Bit.False;
        }

        return result;
    }
}