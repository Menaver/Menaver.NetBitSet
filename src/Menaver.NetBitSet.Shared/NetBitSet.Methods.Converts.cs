﻿using System.Text;
using Menaver.NetBitSet.Shared.Internals;

namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    public bool[] ToBools()
    {
        return BitArrayConverter.ConvertToBools(_containers);
    }

    public sbyte[] ToSBytes()
    {
        return BitArrayConverter.ConvertToSBytes(_containers);
    }

    public byte[] ToBytes()
    {
        return BitArrayConverter.ConvertToBytes(_containers);
    }

    public short[] ToShorts()
    {
        return BitArrayConverter.ConvertToShorts(_containers);
    }

    public ushort[] ToUShorts()
    {
        return BitArrayConverter.ConvertToUShorts(_containers);
    }

    public int[] ToInts()
    {
        return BitArrayConverter.ConvertToInts(_containers);
    }

    public uint[] ToUInts()
    {
        return BitArrayConverter.ConvertToUInts(_containers);
    }

    public long[] ToLongs()
    {
        return BitArrayConverter.ConvertToLongs(_containers);
    }

    public ulong[] ToULongs()
    {
        return BitArrayConverter.ConvertToULongs(_containers);
    }

    public double[] ToDoubles()
    {
        return BitArrayConverter.ConvertToDoubles(_containers);
    }

    public string ToBinaryString()
    {
        return BitArrayConverter.ConvertToBinaryString(_containers);
    }

    public string[] ToBinaryStringsByWord()
    {
        return BitArrayConverter.ConvertToBinaryStringsByWord(_containers, WordLength);
    }

    public T ToObject<T>()
    {
        return BitArrayConverter.ConvertToObject<T>(_containers, _defaultSystemEncoding);
    }

    public T ToObject<T>(Encoding encoding)
    {
        return BitArrayConverter.ConvertToObject<T>(_containers, encoding);
    }
}