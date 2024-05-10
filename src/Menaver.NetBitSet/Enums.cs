namespace Menaver.NetBitSet;

/// <summary>
///     Representation of a bit, the data structure is built from.
/// </summary>
public enum Bit : byte
{
    False = 0,
    True = 1
}

/// <summary>
///     The fixed length of an elementary data unit, defined by the data type, in bits.
/// </summary>
public enum WordLength : byte
{
    NotFixed = 0,
    One = 1,
    Eight = 8,
    Sixteen = 16,
    ThirtyTwo = 32,
    SixtyFour = 64
}

/// <summary>
///     The order in which bytes within a word of data are read.
/// </summary>
public enum Endian : byte
{
    Big = 0, // left to right
    Little = 1 // right to left
}