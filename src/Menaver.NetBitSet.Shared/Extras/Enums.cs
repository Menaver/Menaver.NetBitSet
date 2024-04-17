namespace Menaver.NetBitSet.Shared.Extras;

public enum Bit : byte
{
    False = 0,
    True = 1
}

public enum WordLength : byte
{
    Eight = 8,
    Sixteen = 16,
    ThirtyTwo = 32,
    SixtyFour = 64
}

public enum Endian : byte
{
    Big = 0,
    Little = 1
}