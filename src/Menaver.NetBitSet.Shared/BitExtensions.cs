using System.Runtime.CompilerServices;

namespace Menaver.NetBitSet.Shared;

public static class BitExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ToBool(this Bit bit)
    {
        return bit == Bit.True;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToBinaryString(this Bit bit)
    {
        return bit == Bit.True ? "1" : "0";
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToBinaryChar(this Bit bit)
    {
        return bit == Bit.True ? '1' : '0';
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bit ToBit(this bool value)
    {
        return value ? Bit.True : Bit.False;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bit ToBit(this byte value)
    {
        return value == 0 ? Bit.False : Bit.True;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bit ToBit(this int value)
    {
        return value == 0 ? Bit.False : Bit.True;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bit ToBit(this double value, double precision = 0.0000001)
    {
        return Math.Abs(value) < precision ? Bit.False : Bit.True;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bit And(this Bit bitA, Bit bitB)
    {
        return (bitA.ToBool() & bitB.ToBool()).ToBit();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bit Or(this Bit bitA, Bit bitB)
    {
        return (bitA.ToBool() | bitB.ToBool()).ToBit();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bit Xor(this Bit bitA, Bit bitB)
    {
        return (bitA.ToBool() ^ bitB.ToBool()).ToBit();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bit Not(this Bit bit)
    {
        return (!bit.ToBool()).ToBit();
    }
}