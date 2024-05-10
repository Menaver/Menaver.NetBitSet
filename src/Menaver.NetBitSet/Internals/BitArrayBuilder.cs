using System.Collections;
using Menaver.NetBitSet.Extensions;

namespace Menaver.NetBitSet.Internals;

internal static class BitArrayBuilder
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

    public static BitArray[] BuildBitArrays(ulong count, Bit defaultValue)
    {
        var (quotient, remainder) = Math.DivRem(count, int.MaxValue);

        var arraysCount = (int)quotient + 1;
        var lastArrayLength = (int)remainder;

        var bitArrays = new BitArray[arraysCount];

        for (var i = 0; i < arraysCount; i++)
        {
            var length = i < arraysCount - 1
                ? int.MaxValue
                : lastArrayLength;

            bitArrays[i] = new BitArray(length, defaultValue.ToBool());
        }

        return bitArrays;
    }

    public static BitArray[] BuildBitArrays(byte[] bytes)
    {
        if (bytes.LongLength <= int.MaxValue)
        {
            return new BitArray[] { new(bytes) };
        }

        var (quotient, _) = Math.DivRem((ulong)bytes.LongLength, int.MaxValue);

        var arraysCount = (int)quotient + 1;

        var bitArrays = new BitArray[arraysCount];

        for (var i = 0; i < arraysCount; i++)
        {
            var pagedBatch = bytes.Skip(int.MaxValue * i).Take(int.MaxValue).ToArray();

            bitArrays[i] = new BitArray(pagedBatch);
        }

        return bitArrays;
    }

    public static BitArray[] ResizeBitArrays(BitArray[] bitArrays, ulong newSize)
    {
        var (quotient, remainder) = Math.DivRem(newSize, int.MaxValue);

        var initialArraysCount = bitArrays.Length;
        var arraysCount = (int)quotient + 1;
        var lastArrayLength = (int)remainder;

        if (arraysCount == initialArraysCount)
        {
            // the number of packs retains
            bitArrays[initialArraysCount - 1].Length = lastArrayLength;
        }
        else if (arraysCount < initialArraysCount)
        {
            // the number of packs reduces
            Array.Resize(ref bitArrays, arraysCount);
        }
        else if (arraysCount > initialArraysCount)
        {
            // the number of packs extends
            Array.Resize(ref bitArrays, arraysCount);

            for (var i = initialArraysCount; i < arraysCount; i++)
            {
                var length = i < arraysCount - 1
                    ? int.MaxValue
                    : lastArrayLength;

                bitArrays[i] = new BitArray(length, false);
            }
        }

        return bitArrays;
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
}