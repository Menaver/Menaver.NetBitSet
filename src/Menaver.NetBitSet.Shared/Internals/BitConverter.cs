using System.Runtime.CompilerServices;

namespace Menaver.NetBitSet.Shared.Internals;

internal static class BitConverter
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
        return System.Math.Abs(value) < precision ? Bit.False : Bit.True;
    }
}