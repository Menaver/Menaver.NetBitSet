using System.Text;

namespace Menaver.NetBitSet.Interfaces;

/// <summary>
///     Represents an abstraction of a convertible bit-level data structure.
/// </summary>
public interface INetBitSetConvertible
{
    /// <summary>
    ///     Converts the bit-set to bool.
    /// </summary>
    /// <returns>The data converted.</returns>
    bool ToBool();

    /// <summary>
    ///     Converts the bit-set to sbyte.
    /// </summary>
    /// <returns>The data converted.</returns>
    sbyte ToSByte();

    /// <summary>
    ///     Converts the bit-set to byte.
    /// </summary>
    /// <returns>The data converted.</returns>
    byte ToByte();

    /// <summary>
    ///     Converts the bit-set to short.
    /// </summary>
    /// <returns>The data converted.</returns>
    short ToShort();

    /// <summary>
    ///     Converts the bit-set to ushort.
    /// </summary>
    /// <returns>The data converted.</returns>
    ushort ToUShort();

    /// <summary>
    ///     Converts the bit-set to int.
    /// </summary>
    /// <returns>The data converted.</returns>
    int ToInt();

    /// <summary>
    ///     Converts the bit-set to uint.
    /// </summary>
    /// <returns>The data converted.</returns>
    uint ToUInt();

    /// <summary>
    ///     Converts the bit-set to long.
    /// </summary>
    /// <returns>The data converted.</returns>
    long ToLong();

    /// <summary>
    ///     Converts the bit-set to ulong.
    /// </summary>
    /// <returns>The data converted.</returns>
    ulong ToULong();

    /// <summary>
    ///     Converts the bit-set to double.
    /// </summary>
    /// <returns>The data converted.</returns>
    double ToDouble();

    /// <summary>
    ///     Converts the bit-set to an array of bool.
    /// </summary>
    /// <returns>The data converted.</returns>
    bool[] ToBools();

    /// <summary>
    ///     Converts the bit-set to an array of sbyte.
    /// </summary>
    /// <returns>The data converted.</returns>
    sbyte[] ToSBytes();

    /// <summary>
    ///     Converts the bit-set to an array of byte.
    /// </summary>
    /// <returns>The data converted.</returns>
    byte[] ToBytes();

    /// <summary>
    ///     Converts the bit-set to an array of short.
    /// </summary>
    /// <returns>The data converted.</returns>
    short[] ToShorts();

    /// <summary>
    ///     Converts the bit-set to an array of ushort.
    /// </summary>
    /// <returns>The data converted.</returns>
    ushort[] ToUShorts();

    /// <summary>
    ///     Converts the bit-set to an array of int.
    /// </summary>
    /// <returns>The data converted.</returns>
    int[] ToInts();

    /// <summary>
    ///     Converts the bit-set to an array of uint.
    /// </summary>
    /// <returns>The data converted.</returns>
    uint[] ToUInts();

    /// <summary>
    ///     Converts the bit-set to an array of long.
    /// </summary>
    /// <returns>The data converted.</returns>
    long[] ToLongs();

    /// <summary>
    ///     Converts the bit-set to an array of ulong.
    /// </summary>
    /// <returns>The data converted.</returns>
    ulong[] ToULongs();

    /// <summary>
    ///     Converts the bit-set to an array of double.
    /// </summary>
    /// <returns>The data converted.</returns>
    double[] ToDoubles();

    /// <summary>
    ///     Converts the bit-set to a binary string.
    /// </summary>
    /// <returns>The string that consists of binary chars ('1' or '0') representing the underlying bit-set.</returns>
    string ToBinaryString();

    /// <summary>
    ///     Converts the bit-set to an array binary string, each element of which represents a Word, defined by WordLength.
    ///     NOTE: The length of each string does not exceed the WordLength.
    /// </summary>
    /// <returns>The string that consists of binary chars ('1' or '0') representing the underlying bit-set.</returns>
    string[] ToBinaryStringsByWord();

    /// <summary>
    ///     Converts the bit-set to an object of type TObj.
    ///     NOTE: the conversion implies a JSON deserialization.
    ///     The BinaryFormatter is obsolete and cannot not be used anymore.
    ///     See https://aka.ms/binaryformatter for more details.
    /// </summary>
    /// <typeparam name="TObj">The type of the object to convert to.</typeparam>
    /// <returns>The data converted.</returns>
    TObj ToObject<TObj>();

    /// <summary>
    ///     Converts the bit-set to an object of type TObj.
    ///     NOTE: the conversion implies a JSON deserialization.
    ///     The BinaryFormatter is obsolete and cannot not be used anymore.
    ///     See https://aka.ms/binaryformatter for more details.
    /// </summary>
    /// <typeparam name="TObj">The type of the object to convert to.</typeparam>
    /// <param name="encoding">
    ///     Since this the process implies a JSON deserialization, you may want specify the encoding the
    ///     string is driven by.
    /// </param>
    /// <returns>The data converted.</returns>
    TObj ToObject<TObj>(Encoding encoding);
}