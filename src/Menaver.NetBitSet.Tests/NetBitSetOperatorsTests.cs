using NUnit.Framework.Internal;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetOperatorsTests
{
    private static readonly Randomizer Randomizer = Randomizer.CreateRandomizer();

    [Test]
    public void Equals_RandomData_Equals()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new byte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextByte();
        }

        var netBitSetA = new NetBitSet(randomValues);
        var netBitSetB = new NetBitSet(randomValues);

        // act
        var equals = netBitSetA == netBitSetB;

        // assert
        Assert.That(equals);
    }

    [Test]
    public void NotEquals_RandomData_Equals()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new byte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextByte();
        }

        var netBitSetA = new NetBitSet(randomValues, WordLength.Sixteen);
        var netBitSetB = new NetBitSet(randomValues, WordLength.ThirtyTwo);

        // act
        var notEquals = netBitSetA != netBitSetB;

        // assert
        Assert.That(notEquals);
    }

    [Test]
    public void Operator_Implicit_Bool_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextBool();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToBools().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_Byte_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextByte();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_SByte_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextSByte();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_Short_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextShort();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToShorts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_UShort_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextUShort();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToUShorts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_Int_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.Next();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToInts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_UInt_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextUInt();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToUInts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_Long_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextLong();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToLongs().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_ULong_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextULong();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToULongs().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_Double_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextDouble();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToDoubles().FirstOrDefault();

        // assert
        Assert.That(revertedValue - value < 0.0000001);
    }

    [Test]
    public void Operator_Implicit_String_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.GetString();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = netBitSet.ToString();

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Implicit_Bools_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToBools();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Implicit_Bytes_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new byte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextByte();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToBytes();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Implicit_SBytes_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new sbyte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextSByte();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToSBytes();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Implicit_Shorts_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new short[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextShort();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToShorts();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Implicit_Ints_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new int[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.Next();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToInts();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Implicit_UInts_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new uint[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUInt();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToUInts();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Implicit_Longs_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new long[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextLong();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToLongs();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Implicit_ULongs_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new ulong[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextULong();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToULongs();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Implicit_Doubles_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new double[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextULong();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = netBitSet.ToDoubles();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_Bool_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextBool();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (bool)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_Byte_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextByte();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (byte)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_SByte_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextSByte();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (sbyte)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_Short_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextShort();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (short)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_UShort_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextUShort();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (ushort)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_Int_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.Next();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (int)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_UInt_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextUInt();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (uint)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_Long_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextLong();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (long)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_ULong_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextULong();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (ulong)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_Double_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.NextDouble();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (double)netBitSet;

        // assert
        Assert.That(revertedValue - value < 0.0000001);
    }

    [Test]
    public void Operator_Explicit_String_RandomData_ValueFits()
    {
        // arrange
        var value = Randomizer.GetString();
        NetBitSet netBitSet = value;

        // act
        var revertedValue = (string)netBitSet;

        // assert
        Assert.That(revertedValue == value);
    }

    [Test]
    public void Operator_Explicit_Bools_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (bool[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_Bytes_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new byte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextByte();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (byte[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_SBytes_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new sbyte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextSByte();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (sbyte[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_Shorts_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new short[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextShort();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (short[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_UShorts_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new ushort[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUShort();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (ushort[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_Ints_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new int[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.Next();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (int[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_UInts_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new uint[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUInt();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (uint[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_Longs_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new long[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextLong();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (long[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_ULongs_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new ulong[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextULong();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (ulong[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Operator_Explicit_Doubles_RandomData_ValueFits()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new double[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextULong();
        }

        NetBitSet netBitSet = randomValues;

        // act
        var revertedValues = (double[])netBitSet;
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [TestCase("10010111", 1, "01001011")]
    [TestCase("10010111", 2, "00100101")]
    [TestCase("10010111", 3, "00010010")]
    [TestCase("10010111", 4, "00001001")]
    [TestCase("01111011", 1, "00111101")]
    [TestCase("01111011", 2, "00011110")]
    [TestCase("01111011", 3, "00001111")]
    [TestCase("01111011", 4, "00000111")]
    public void Operator_ShiftRight_BinaryString_Count_BinaryStringFits(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet >>= count;
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(123, 1, 61)]
    [TestCase(123, 2, 30)]
    [TestCase(123, 3, 15)]
    [TestCase(123, 4, 7)]
    public void Operator_ShiftRight_Byte_Count_NumberFits(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet >>= count;
        var changedBinaryString = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase(-105, 1, 75)]
    [TestCase(-105, 2, 37)]
    [TestCase(-105, 3, 18)]
    [TestCase(-105, 4, 9)]
    public void Operator_ShiftRight_SByte_Count_NumberFits(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet >>= count;
        var changedBinaryString = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase("10010111", 1, "00101110")]
    [TestCase("10010111", 2, "01011100")]
    [TestCase("10010111", 3, "10111000")]
    [TestCase("10010111", 4, "01110000")]
    [TestCase("01111011", 1, "11110110")]
    [TestCase("01111011", 2, "11101100")]
    [TestCase("01111011", 3, "11011000")]
    [TestCase("01111011", 4, "10110000")]
    public void Operator_ShiftLeft_BinaryString_Count_BinaryStringFits(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet <<= count;
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(123, 1, 246)]
    [TestCase(123, 2, 236)]
    [TestCase(123, 3, 216)]
    [TestCase(123, 4, 176)]
    public void Operator_ShiftLeft_Byte_Count_NumberFits(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet <<= count;
        var changedBinaryString = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase(-105, 1, 46)]
    [TestCase(-105, 2, 92)]
    [TestCase(-105, 3, -72)]
    [TestCase(-105, 4, 112)]
    public void Operator_ShiftLeft_SByte_Count_NumberFits(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet <<= count;
        var changedBinaryString = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase("10101010", "00000000", "00000000")]
    [TestCase("10101010", "11111111", "10101010")]
    [TestCase("10101010", "01010101", "00000000")]
    [TestCase("10101010", "11001100", "10001000")]
    [TestCase("10101010", "00110011", "00100010")]
    [TestCase("10101010", "11110000", "10100000")]
    public void Operator_And_BinaryString_BinaryStringFits(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new NetBitSet(binaryStringA);
        var netBitSetB = new NetBitSet(binaryStringB);

        // act
        netBitSetA &= netBitSetB;
        var changedBinaryString = netBitSetA.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(170, 0, 0)]
    [TestCase(170, 255, 170)]
    [TestCase(170, 85, 0)]
    [TestCase(170, 204, 136)]
    [TestCase(170, 51, 34)]
    [TestCase(170, 240, 160)]
    public void Operator_And_Byte_NumberFits(
        byte valueA,
        byte valueB,
        byte expectedValue)
    {
        // arrange 
        var netBitSetA = new NetBitSet(valueA);
        var netBitSetB = new NetBitSet(valueB);

        // act
        netBitSetA &= netBitSetB;
        var changedValue = netBitSetA.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase(-86, 0, 0)]
    [TestCase(-86, -1, -86)]
    [TestCase(-86, 85, 0)]
    [TestCase(-86, -52, -120)]
    [TestCase(-86, 51, 34)]
    [TestCase(-86, -16, -96)]
    public void Operator_And_SByte_NumberFits(
        sbyte valueA,
        sbyte valueB,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSetA = new NetBitSet(valueA);
        var netBitSetB = new NetBitSet(valueB);

        // act
        netBitSetA &= netBitSetB;
        var changedValue = netBitSetA.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase("10101010", "00000000", "10101010")]
    [TestCase("10101010", "11111111", "11111111")]
    [TestCase("10101010", "01010101", "11111111")]
    [TestCase("10101010", "11001100", "11101110")]
    [TestCase("10101010", "00110011", "10111011")]
    [TestCase("10101010", "11110000", "11111010")]
    public void Operator_Or_BinaryString_BinaryStringFits(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new NetBitSet(binaryStringA);
        var netBitSetB = new NetBitSet(binaryStringB);

        // act
        netBitSetA |= netBitSetB;
        var changedBinaryString = netBitSetA.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(170, 0, 170)]
    [TestCase(170, 255, 255)]
    [TestCase(170, 85, 255)]
    [TestCase(170, 204, 238)]
    [TestCase(170, 51, 187)]
    [TestCase(170, 240, 250)]
    public void Operator_Or_Byte_NumberFits(
        byte valueA,
        byte valueB,
        byte expectedValue)
    {
        // arrange 
        var netBitSetA = new NetBitSet(valueA);
        var netBitSetB = new NetBitSet(valueB);

        // act
        netBitSetA |= netBitSetB;
        var changedValue = netBitSetA.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase(-86, 0, -86)]
    [TestCase(-86, -1, -1)]
    [TestCase(-86, 85, -1)]
    [TestCase(-86, -52, -18)]
    [TestCase(-86, 51, -69)]
    [TestCase(-86, -16, -6)]
    public void Operator_Or_SByte_NumberFits(
        sbyte valueA,
        sbyte valueB,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSetA = new NetBitSet(valueA);
        var netBitSetB = new NetBitSet(valueB);

        // act
        netBitSetA |= netBitSetB;
        var changedValue = netBitSetA.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase("10101010", "00000000", "10101010")]
    [TestCase("10101010", "11111111", "01010101")]
    [TestCase("10101010", "01010101", "11111111")]
    [TestCase("10101010", "11001100", "01100110")]
    [TestCase("10101010", "00110011", "10011001")]
    [TestCase("10101010", "11110000", "01011010")]
    public void Operator_Xor_BinaryString_BinaryStringFits(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new NetBitSet(binaryStringA);
        var netBitSetB = new NetBitSet(binaryStringB);

        // act
        netBitSetA ^= netBitSetB;
        var changedBinaryString = netBitSetA.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(170, 0, 170)]
    [TestCase(170, 255, 85)]
    [TestCase(170, 85, 255)]
    [TestCase(170, 204, 102)]
    [TestCase(170, 51, 153)]
    [TestCase(170, 240, 90)]
    public void Operator_Xor_Byte_NumberFits(
        byte valueA,
        byte valueB,
        byte expectedValue)
    {
        // arrange 
        var netBitSetA = new NetBitSet(valueA);
        var netBitSetB = new NetBitSet(valueB);

        // act
        netBitSetA ^= netBitSetB;
        var changedValue = netBitSetA.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase(-86, 0, -86)]
    [TestCase(-86, -1, 85)]
    [TestCase(-86, 85, -1)]
    [TestCase(-86, -52, 102)]
    [TestCase(-86, 51, -103)]
    [TestCase(-86, -16, 90)]
    public void Operator_Xor_SByte_NumberFits(
        sbyte valueA,
        sbyte valueB,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSetA = new NetBitSet(valueA);
        var netBitSetB = new NetBitSet(valueB);

        // act
        netBitSetA ^= netBitSetB;
        var changedValue = netBitSetA.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase("10101010", "01010101")]
    [TestCase("11111111", "00000000")]
    [TestCase("00000000", "11111111")]
    public void Operator_Invert_BinaryString_BinaryStringFits(
        string binaryString,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet = ~netBitSet;
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(170, 85)]
    [TestCase(255, 0)]
    [TestCase(0, 255)]
    public void Operator_Invert_Byte_NumberFits(
        byte value,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet = ~netBitSet;
        var changedValue = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase(-86, 85)]
    [TestCase(-1, 0)]
    [TestCase(0, -1)]
    public void Operator_Invert_SByte_NumberFits(
        sbyte value,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet = ~netBitSet;
        var changedValue = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedValue == expectedValue);
    }
}