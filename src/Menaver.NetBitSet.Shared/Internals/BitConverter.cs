using System.Runtime.CompilerServices;
using System.Text;

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

    public static WordLength GetBoolMachineWordLength()
    {
        return WordLength.One;
    }

    public static WordLength GetByteMachineWordLength()
    {
        return (WordLength)(System.BitConverter.GetBytes((byte)1).Length * 8);
    }

    public static WordLength GetShortMachineWordLength()
    {
        return (WordLength)(System.BitConverter.GetBytes((short)1).Length * 8);
    }

    public static WordLength GetIntMachineWordLength()
    {
        return (WordLength)(System.BitConverter.GetBytes(1).Length * 8);
    }

    public static WordLength GetLongMachineWordLength()
    {
        return (WordLength)(System.BitConverter.GetBytes((long)1).Length * 8);
    }

    public static WordLength GetDoubleMachineWordLength()
    {
        return (WordLength)(System.BitConverter.GetBytes((double)1).Length * 8);
    }

    public static WordLength GetStringMachineWordLength(Encoding encoding)
    {
        if (encoding.EncodingName == Encoding.ASCII.EncodingName)
        {
            return (WordLength)(System.BitConverter.GetBytes((char)1).Length * 8);
        }

        // other string encoding do not guarantee a fixed length 
        return WordLength.NotFixed;
    }
}