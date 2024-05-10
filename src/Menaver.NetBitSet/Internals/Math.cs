using System.Runtime.CompilerServices;

namespace Menaver.NetBitSet.Internals;

internal class Math
{
    /// <summary>
    ///     Produces the quotient and the remainder of two unsigned 64-bit numbers.
    ///     Copied from: https://github.com/dotnet/runtime/blob/7f2e0287ab57c7bbac87e85a05d805806ab26610/src/libraries/System.Private.CoreLib/src/System/Math.cs#L450
    /// </summary>
    /// <param name="left">The dividend.</param>
    /// <param name="right">The divisor.</param>
    /// <returns>The quotient and the remainder of the specified numbers.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (ulong Quotient, ulong Remainder) DivRem(ulong left, ulong right)
    {
        var quotient = left / right;
        return (quotient, left - quotient * right);
    }
}