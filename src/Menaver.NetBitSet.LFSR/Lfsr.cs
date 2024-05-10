//using Menaver.NetBitSet.Shared.Interfaces;

//namespace Menaver.NetBitSet.Shared.Lfsr;

///// <summary>
///// Represents an implementation of a linear-feedback shift register (LFSR).
///// </summary>
//public class Lfsr : ILfsr
//{
//    public Lfsr(NetBitSet container, int[] polynomIndexes)
//    {
//        foreach (var index in polynomIndexes)
//            if (index < 0 || index >= container.Count)
//                throw new ArgumentException("One of the indexes is bigger than the container length or less than zero");

//        Container = container;
//        PolynomIndexes = polynomIndexes;
//    }

//    public INetBitSet Container { get; }
//    public int[] PolynomIndexes { get; }

//    // indexer (get-only)
//    public int this[int index] => Container[index];


//    public int Shift()
//    {
//        var outBit = Container[0];
//        var inBit = Container[PolynomIndexes[0]];

//        for (var i = 1; i < PolynomIndexes.Length; i++) // 0th index has been already used above
//            inBit ^= Container[PolynomIndexes[i]];

//        Container.ShiftRight(1, inBit); // shift to right (big-endian) and init the last bit with bitIn

//        return outBit;
//    }

//    public int[] Shift(int count)
//    {
//        var outBits = new int[count];

//        for (var i = 0; i < count; i++)
//        {
//            outBits[i] = Container[0];
//            var inBit = Container[PolynomIndexes[0]];

//            for (var j = 1; j < PolynomIndexes.Length; j++) // 0th index has been already used above
//                inBit ^= Container[PolynomIndexes[j]];

//            Container.ShiftRight(1, inBit); // shift to right (big-endian) and init the last bit with bitIn
//        }

//        return outBits;
//    }
//}