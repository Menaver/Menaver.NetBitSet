using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Shared.Lfsr;

/// <summary>
/// Represents an abstraction of a linear-feedback shift register (LFSR).
/// </summary>
public interface ILfsr
{
    INetBitSet Container { get; }
    int[] PolynomIndexes { get; }

    int this[int index] { get; }

    int Shift();
    int[] Shift(int count);
}