namespace Menaver.NetBitSet.LFSR;

/// <summary>
///     Represents an abstraction of a linear-feedback shift register (LFSR).
/// </summary>
public interface ILFSR
{
    /// <summary>
    ///     Performs the shift operation and outcomes the calculated bit.
    /// </summary>
    /// <returns>The output bit.</returns>
    Bit Shift();

    /// <summary>
    ///     Performs a sequence of N shift operations,
    ///     where N is defined by count, and outcomes the calculated N bits.
    /// </summary>
    /// <param name="count">The number of shifts.</param>
    /// <returns>The output bits.</returns>
    Bit[] Shift(ulong count);
}