using System;
using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Shared
{
    public class LFSR : ILFSR
    {
        public INetBitSet Container { get; }
        public int[] PolynomIndexes { get; }

        // indexer (get-only)
        public int this[int index] => Container[index];


        public LFSR(NetBitSet container, int[] polynomIndexes)
        {
            foreach (var index in polynomIndexes)
                if (index < 0 || index >= container.Count)
                    throw new ArgumentException("One of the indexes is bigger than the container length or less than zero");

            Container = container;
            PolynomIndexes = polynomIndexes;
        }


        public int Shift()
        {
            int outBit = Container[0];
            int inBit = Container[PolynomIndexes[0]];

            for (var i = 1; i < PolynomIndexes.Length; i++) // 0th index has been already used above
                inBit ^= Container[PolynomIndexes[i]];

            Container.ShiftRight(1, inBit); // shift to right (big-endian) and init the last bit with bitIn

            return outBit;
        }

        public int[] Shift(int count)
        {
            int[] outBits = new int[count];

            for (var i = 0; i < count; i++)
            {
                outBits[i] = Container[0];
                int inBit = Container[PolynomIndexes[0]];

                for (var j = 1; j < PolynomIndexes.Length; j++) // 0th index has been already used above
                    inBit ^= Container[PolynomIndexes[j]];

                Container.ShiftRight(1, inBit); // shift to right (big-endian) and init the last bit with bitIn
            }

            return outBits;
        }
    }
}