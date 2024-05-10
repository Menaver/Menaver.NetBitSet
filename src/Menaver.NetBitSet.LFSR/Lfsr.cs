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
    /// <param name="container"></param>
    /// <param name="polynomial"></param>
    /// <exception cref="ArgumentException"></exception>
    public LFSR(NetBitSet container, ulong[] polynomial)
    {
        if (container == null)
        {
            throw new ArgumentException("Container must be not-null.");
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
        var outBit = _container[0].ToBool();
        var inBit = _container[_polynomial[0]].ToBool();

        for (var i = 1; i < _polynomial.Length; i++)
        {
            inBit ^= _container[_polynomial[i]].ToBool();
        }

        _container.ShiftRight(1, inBit);

        return outBit.ToBit();
    }

    /// <summary>
    ///     Performs a sequence of N shift operations, where N is defined by count.
    /// </summary>
    /// <param name="count">The number of shift operations.</param>
    /// <returns>The output bits.</returns>
    public Bit[] Shift(ulong count)
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

        return outBits.Select(x => x.ToBit()).ToArray();
    }
}