namespace Menaver.NetBitSet.Shared.Interfaces
{
    public interface ILFSR
    {
        INetBitSet Container { get; }
        int[] PolynomIndexes { get; }

        int this[int index] { get; }

        int Shift();
        int[] Shift(int count);
    }
}