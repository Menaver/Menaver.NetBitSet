using System.Text;
using Menaver.NetBitSet.Internals;

namespace Menaver.NetBitSet;

public partial class NetBitSet
{
    /// <summary>
    ///     Converts the bit-set to bool.
    /// </summary>
    /// <returns>The data converted.</returns>
    public bool ToBool()
    {
        return ToBools().First();
    }

    /// <summary>
    ///     Converts the bit-set to sbyte.
    /// </summary>
    /// <returns>The data converted.</returns>
    public sbyte ToSByte()
    {
        return ToSBytes().First();
    }

    /// <summary>
    ///     Converts the bit-set to byte.
    /// </summary>
    /// <returns>The data converted.</returns>
    public byte ToByte()
    {
        return ToBytes().First();
    }

    /// <summary>
    ///     Converts the bit-set to short.
    /// </summary>
    /// <returns>The data converted.</returns>
    public short ToShort()
    {
        return ToShorts().First();
    }

    /// <summary>
    ///     Converts the bit-set to ushort.
    /// </summary>
    /// <returns>The data converted.</returns>
    public ushort ToUShort()
    {
        return ToUShorts().First();
    }

    /// <summary>
    ///     Converts the bit-set to int.
    /// </summary>
    /// <returns>The data converted.</returns>
    public int ToInt()
    {
        return ToInts().First();
    }

    /// <summary>
    ///     Converts the bit-set to uint.
    /// </summary>
    /// <returns>The data converted.</returns>
    public uint ToUInt()
    {
        return ToUInts().First();
    }

    /// <summary>
    ///     Converts the bit-set to long.
    /// </summary>
    /// <returns>The data converted.</returns>
    public long ToLong()
    {
        return ToLongs().First();
    }

    /// <summary>
    ///     Converts the bit-set to ulong.
    /// </summary>
    /// <returns>The data converted.</returns>
    public ulong ToULong()
    {
        return ToULongs().First();
    }

    /// <summary>
    ///     Converts the bit-set to double.
    /// </summary>
    /// <returns>The data converted.</returns>
    public double ToDouble()
    {
        return ToDoubles().First();
    }

    /// <summary>
    ///     Converts the bit-set to an array of bool.
    /// </summary>
    /// <returns>The data converted.</returns>
    public bool[] ToBools()
    {
        return BitArrayConverter.ConvertToBools(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of sbyte.
    /// </summary>
    /// <returns>The data converted.</returns>
    public sbyte[] ToSBytes()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Byte);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Byte);

        return BitArrayConverter.ConvertToSBytes(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of byte.
    /// </summary>
    /// <returns>The data converted.</returns>
    public byte[] ToBytes()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Byte);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Byte);

        return BitArrayConverter.ConvertToBytes(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of short.
    /// </summary>
    /// <returns>The data converted.</returns>
    public short[] ToShorts()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Short);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Short);

        return BitArrayConverter.ConvertToShorts(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of ushort.
    /// </summary>
    /// <returns>The data converted.</returns>
    public ushort[] ToUShorts()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Short);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Short);

        return BitArrayConverter.ConvertToUShorts(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of int.
    /// </summary>
    /// <returns>The data converted.</returns>
    public int[] ToInts()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Int);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Int);

        return BitArrayConverter.ConvertToInts(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of uint.
    /// </summary>
    /// <returns>The data converted.</returns>
    public uint[] ToUInts()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Int);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Int);

        return BitArrayConverter.ConvertToUInts(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of long.
    /// </summary>
    /// <returns>The data converted.</returns>
    public long[] ToLongs()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Long);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Long);

        return BitArrayConverter.ConvertToLongs(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of ulong.
    /// </summary>
    /// <returns>The data converted.</returns>
    public ulong[] ToULongs()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Long);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Long);

        return BitArrayConverter.ConvertToULongs(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to an array of double.
    /// </summary>
    /// <returns>The data converted.</returns>
    public double[] ToDoubles()
    {
        BitArrayConverter.CheckByWordLength(WordLength, WordLengths.Double);
        BitArrayConverter.CheckByElementCount(Count, WordLengths.Double);

        return BitArrayConverter.ConvertToDoubles(_containers);
    }

    /// <summary>
    ///     Converts the bit-set to a binary string.
    /// </summary>
    /// <returns>The string that consists of binary chars ('1' or '0') representing the underlying bit-set.</returns>
    public string ToBinaryString()
    {
        return BitArrayConverter.ConvertToBinaryString(_containers, WordLength);
    }

    /// <summary>
    ///     Converts the bit-set to an array binary string, each element of which represents a Word, defined by WordLength.
    ///     NOTE: The length of each string does not exceed the WordLength.
    /// </summary>
    /// <returns>The string that consists of binary chars ('1' or '0') representing the underlying bit-set.</returns>
    public string[] ToBinaryStringsByWord()
    {
        return BitArrayConverter.ConvertToBinaryStringsByWord(_containers, WordLength);
    }

    /// <summary>
    ///     Converts the bit-set to an object of type TObj.
    ///     NOTE: the conversion implies a JSON deserialization.
    ///     The BinaryFormatter is obsolete and cannot not be used anymore.
    ///     See https://aka.ms/binaryformatter for more details.
    /// </summary>
    /// <typeparam name="TObj">The type of the object to convert to.</typeparam>
    /// <returns>The data converted.</returns>
    public TObj ToObject<TObj>()
    {
        return BitArrayConverter.ConvertToObject<TObj>(_containers, DefaultSystemEncoding);
    }

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
    public TObj ToObject<TObj>(Encoding encoding)
    {
        return BitArrayConverter.ConvertToObject<TObj>(_containers, encoding);
    }
}