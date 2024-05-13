using System.Collections;
using Menaver.NetBitSet.Extensions;

namespace Menaver.NetBitSet.Internals;

internal static class BitArrayBuilder
{
    public static BitArray[] BuildBitArrays(ulong count, Bit defaultValue)
    {
        var (quotient, remainder) = Math.DivRem(count, int.MaxValue);

        var arraysCount = (int)quotient + 1;
        var lastArrayLength = (int)remainder;

        var bitArrays = new BitArray[arraysCount];

        var defaultValueBool = defaultValue.ToBool();

        for (var i = 0; i < arraysCount; i++)
        {
            var length = i < arraysCount - 1
                ? int.MaxValue
                : lastArrayLength;

            bitArrays[i] = new BitArray(length, defaultValueBool);
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
}