using System.Collections;

namespace Menaver.NetBitSet.Internals;

internal static class BitArrayHelper
{
    public static (int PackIndex, int BitIndex) GetComplexIndex(ulong index)
    {
        var (quotient, remainder) = Math.DivRem(index, int.MaxValue);

        return ((int)quotient, (int)remainder);
    }

    public static ulong GetAggregatedCount(BitArray[] arrays)
    {
        return arrays.Aggregate<BitArray, ulong>(0, (current, bitArray) => current + (ulong)bitArray!.Length);
    }

    public static BitArray GetBatch(BitArray[] bitArrays, ulong index, byte count)
    {
        var batch = new BitArray(count);

        for (var i = 0; i < count; i++, index++)
        {
            var (packIndex, bitIndex) = GetComplexIndex(index);

            batch[i] = bitArrays[packIndex][bitIndex];
        }

        return batch;
    }

    public static BitArray[] Inject(BitArray[] bitArrays, ulong index, BitArray bitArrayToInject)
    {
        for (var i = 0; i < bitArrayToInject.Count; i++, index++)
        {
            var (packIndex, bitIndex) = GetComplexIndex(index);

            bitArrays[packIndex][bitIndex] = bitArrayToInject[i];
        }

        return bitArrays;
    }

    public static BitArray[] Clone(BitArray[] bitArray)
    {
        var result = new BitArray[bitArray.Length];

        for (var i = 0; i < bitArray.Length; i++)
        {
            result[i] = (BitArray)bitArray[i].Clone();
        }

        return result;
    }

    public static BitArray[] Reverse(BitArray[] bitArrays, WordLength wordLength)
    {
        switch (wordLength)
        {
            case WordLength.NotFixed:
                throw new InvalidOperationException("Word Length isn't fixed. Operation is invalid.");
            case WordLength.One:
                return Reverse(bitArrays);
            case WordLength.Eight:
            case WordLength.Sixteen:
            case WordLength.ThirtyTwo:
            case WordLength.SixtyFour:
            {
                var wordLengthByte = (byte)wordLength;
                var elementCount = GetAggregatedCount(bitArrays);
                var iterationCount = elementCount / wordLengthByte;

                var temp = Clone(bitArrays);

                for (ulong iteration = 0, index = 0; iteration < iterationCount; iteration++, index += wordLengthByte)
                {
                    var batch = GetBatch(temp, index, wordLengthByte);

                    batch = Reverse(batch);

                    Inject(temp, index, batch);
                }

                return temp;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(wordLength), wordLength, null);
        }
    }

    public static BitArray[] Reverse(BitArray[] bitArrays)
    {
        var bools = BitArrayConverter.ConvertToBools(bitArrays);

        Array.Reverse(bools);

        bitArrays = BitArrayConverter.Convert(bools);

        return bitArrays;
    }

    public static BitArray Reverse(BitArray bitArray)
    {
        var bools = BitArrayConverter.ConvertToBools(new[] { bitArray });

        Array.Reverse(bools);

        bitArray = BitArrayConverter.Convert(bools).First();

        return bitArray;
    }
}