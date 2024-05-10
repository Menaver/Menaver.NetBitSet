using System.Text;

namespace Menaver.NetBitSet.Interfaces;

/// <summary>
///     Represents an abstraction of a convertible bit-level data structure.
/// </summary>
public interface INetBitSetConvertible
{
    bool[] ToBools();
    sbyte[] ToSBytes();
    byte[] ToBytes();
    short[] ToShorts();
    ushort[] ToUShorts();
    int[] ToInts();
    uint[] ToUInts();
    long[] ToLongs();
    ulong[] ToULongs();
    double[] ToDoubles();

    string ToBinaryString();
    string[] ToBinaryStringsByWord();

    T ToObject<T>();
    T ToObject<T>(Encoding encoding);
}