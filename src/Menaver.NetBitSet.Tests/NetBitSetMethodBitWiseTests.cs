using NUnit.Framework.Internal;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodBitWiseTests
{
    private static readonly Randomizer Randomizer = Randomizer.CreateRandomizer();

    [TestCase("1111", 0, false, "1110")]
    [TestCase("1100", 1, true, "1100")]
    [TestCase("1111", 2, false, "1011")]
    [TestCase("0000", 3, true, "0000")]
    public void BitWise_And_Bool_BinaryStringFits(
        string binaryString,
        int index,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.And((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1110")]
    [TestCase("1100", 1, 1, "1100")]
    [TestCase("1111", 2, 0, "1011")]
    [TestCase("0000", 3, 1, "0000")]
    public void BitWise_And_Byte_BinaryStringFits(
        string binaryString,
        int index,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.And((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1110")]
    [TestCase("1100", 1, 1, "1100")]
    [TestCase("1111", 2, 0, "1011")]
    [TestCase("0000", 3, 1, "0000")]
    public void BitWise_And_Int_BinaryStringFits(
        string binaryString,
        int index,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.And((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1110")]
    [TestCase("1100", 1, 1, "1100")]
    [TestCase("1111", 2, 0, "1011")]
    [TestCase("0000", 3, 1, "0000")]
    public void BitWise_And_Double_BinaryStringFits(
        string binaryString,
        int index,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.And((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, Bit.False, "1110")]
    [TestCase("1100", 1, Bit.True, "1100")]
    [TestCase("1111", 2, Bit.False, "1011")]
    [TestCase("0000", 3, Bit.True, "0000")]
    public void BitWise_And_Bit_BinaryStringFits(
        string binaryString,
        int index,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.And((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", "1110", "1110")]
    [TestCase("1100", "1111", "1100")]
    [TestCase("1111", "1111", "1111")]
    [TestCase("0000", "0000", "0000")]
    public void BitWise_And_NetBitSet_BinaryStringFits(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new NetBitSet(binaryStringA);
        var netBitSetB = new NetBitSet(binaryStringB);

        // act
        netBitSetA.And(netBitSetB);
        var changedBinaryString = netBitSetA.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", false, "0000")]
    [TestCase("1100", true, "1100")]
    [TestCase("0011", false, "0000")]
    [TestCase("0000", true, "0000")]
    public void BitWise_AndAll_Bool_BinaryStringFits(
        string binaryString,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.AndAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "0000")]
    [TestCase("1100", 1, "1100")]
    [TestCase("0011", 0, "0000")]
    [TestCase("0000", 1, "0000")]
    public void BitWise_AndAll_Byte_BinaryStringFits(
        string binaryString,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.AndAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "0000")]
    [TestCase("1100", 1, "1100")]
    [TestCase("0011", 0, "0000")]
    [TestCase("0000", 1, "0000")]
    public void BitWise_AndAll_Int_BinaryStringFits(
        string binaryString,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.AndAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "0000")]
    [TestCase("1100", 1, "1100")]
    [TestCase("0011", 0, "0000")]
    [TestCase("0000", 1, "0000")]
    public void BitWise_AndAll_Double_BinaryStringFits(
        string binaryString,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.AndAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", Bit.False, "0000")]
    [TestCase("1100", Bit.True, "1100")]
    [TestCase("0011", Bit.False, "0000")]
    [TestCase("0000", Bit.True, "0000")]
    public void BitWise_AndAll_Bit_BinaryStringFits(
        string binaryString,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.AndAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, false, "1111")]
    [TestCase("1100", 1, true, "1110")]
    [TestCase("1111", 2, false, "1111")]
    [TestCase("0000", 3, true, "1000")]
    public void BitWise_Or_Bool_BinaryStringFits(
        string binaryString,
        int index,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Or((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1111")]
    [TestCase("1100", 1, 1, "1110")]
    [TestCase("1111", 2, 0, "1111")]
    [TestCase("0000", 3, 1, "1000")]
    public void BitWise_Or_Byte_BinaryStringFits(
        string binaryString,
        int index,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Or((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1111")]
    [TestCase("1100", 1, 1, "1110")]
    [TestCase("1111", 2, 0, "1111")]
    [TestCase("0000", 3, 1, "1000")]
    public void BitWise_Or_Int_BinaryStringFits(
        string binaryString,
        int index,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Or((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1111")]
    [TestCase("1100", 1, 1, "1110")]
    [TestCase("1111", 2, 0, "1111")]
    [TestCase("0000", 3, 1, "1000")]
    public void BitWise_Or_Double_BinaryStringFits(
        string binaryString,
        int index,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Or((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, Bit.False, "1111")]
    [TestCase("1100", 1, Bit.True, "1110")]
    [TestCase("1111", 2, Bit.False, "1111")]
    [TestCase("0000", 3, Bit.True, "1000")]
    public void BitWise_Or_Bit_BinaryStringFits(
        string binaryString,
        int index,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Or((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", "1110", "1111")]
    [TestCase("1100", "1111", "1111")]
    [TestCase("1111", "1111", "1111")]
    [TestCase("0000", "0000", "0000")]
    public void BitWise_Or_NetBitSet_BinaryStringFits(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new NetBitSet(binaryStringA);
        var netBitSetB = new NetBitSet(binaryStringB);

        // act
        netBitSetA.Or(netBitSetB);
        var changedBinaryString = netBitSetA.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", false, "1111")]
    [TestCase("1100", true, "1111")]
    [TestCase("0011", false, "0011")]
    [TestCase("0000", true, "1111")]
    public void BitWise_OrAll_Bool_BinaryStringFits(
        string binaryString,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.OrAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "1111")]
    [TestCase("1100", 1, "1111")]
    [TestCase("0011", 0, "0011")]
    [TestCase("0000", 1, "1111")]
    public void BitWise_OrAll_Byte_BinaryStringFits(
        string binaryString,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.OrAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "1111")]
    [TestCase("1100", 1, "1111")]
    [TestCase("0011", 0, "0011")]
    [TestCase("0000", 1, "1111")]
    public void BitWise_OrAll_Int_BinaryStringFits(
        string binaryString,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.OrAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "1111")]
    [TestCase("1100", 1, "1111")]
    [TestCase("0011", 0, "0011")]
    [TestCase("0000", 1, "1111")]
    public void BitWise_OrAll_Double_BinaryStringFits(
        string binaryString,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.OrAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", Bit.False, "1111")]
    [TestCase("1100", Bit.True, "1111")]
    [TestCase("0011", Bit.False, "0011")]
    [TestCase("0000", Bit.True, "1111")]
    public void BitWise_OrAll_Bit_BinaryStringFits(
        string binaryString,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.OrAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, false, "1111")]
    [TestCase("1100", 1, true, "1110")]
    [TestCase("1111", 2, false, "1111")]
    [TestCase("0000", 3, true, "1000")]
    public void BitWise_Xor_Bool_BinaryStringFits(
        string binaryString,
        int index,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Xor((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1111")]
    [TestCase("1100", 1, 1, "1110")]
    [TestCase("1111", 2, 0, "1111")]
    [TestCase("0000", 3, 1, "1000")]
    public void BitWise_Xor_Byte_BinaryStringFits(
        string binaryString,
        int index,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Xor((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1111")]
    [TestCase("1100", 1, 1, "1110")]
    [TestCase("1111", 2, 0, "1111")]
    [TestCase("0000", 3, 1, "1000")]
    public void BitWise_Xor_Int_BinaryStringFits(
        string binaryString,
        int index,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Xor((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, 0, "1111")]
    [TestCase("1100", 1, 1, "1110")]
    [TestCase("1111", 2, 0, "1111")]
    [TestCase("0000", 3, 1, "1000")]
    public void BitWise_Xor_Double_BinaryStringFits(
        string binaryString,
        int index,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Xor((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, Bit.False, "1111")]
    [TestCase("1100", 1, Bit.True, "1110")]
    [TestCase("1111", 2, Bit.False, "1111")]
    [TestCase("0000", 3, Bit.True, "1000")]
    public void BitWise_Xor_Bit_BinaryStringFits(
        string binaryString,
        int index,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Xor((ulong)index, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", "1110", "0001")]
    [TestCase("1100", "1111", "0011")]
    [TestCase("1111", "1111", "0000")]
    [TestCase("0000", "0000", "0000")]
    public void BitWise_Xor_NetBitSet_BinaryStringFits(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new NetBitSet(binaryStringA);
        var netBitSetB = new NetBitSet(binaryStringB);

        // act
        netBitSetA.Xor(netBitSetB);
        var changedBinaryString = netBitSetA.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", false, "1111")]
    [TestCase("1100", true, "0011")]
    [TestCase("0011", false, "0011")]
    [TestCase("0000", true, "1111")]
    public void BitWise_XorAll_Bool_BinaryStringFits(
        string binaryString,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.XorAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "1111")]
    [TestCase("1100", 1, "0011")]
    [TestCase("0011", 0, "0011")]
    [TestCase("0000", 1, "1111")]
    public void BitWise_XorAll_Byte_BinaryStringFits(
        string binaryString,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.XorAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "1111")]
    [TestCase("1100", 1, "0011")]
    [TestCase("0011", 0, "0011")]
    [TestCase("0000", 1, "1111")]
    public void BitWise_XorAll_Int_BinaryStringFits(
        string binaryString,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.XorAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "1111")]
    [TestCase("1100", 1, "0011")]
    [TestCase("0011", 0, "0011")]
    [TestCase("0000", 1, "1111")]
    public void BitWise_XorAll_Double_BinaryStringFits(
        string binaryString,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.XorAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", Bit.False, "1111")]
    [TestCase("1100", Bit.True, "0011")]
    [TestCase("0011", Bit.False, "0011")]
    [TestCase("0000", Bit.True, "1111")]
    public void BitWise_XorAll_Bit_BinaryStringFits(
        string binaryString,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.XorAll(bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", 0, "1110")]
    [TestCase("1111", 1, "1101")]
    [TestCase("1111", 2, "1011")]
    [TestCase("1111", 3, "0111")]
    public void BitWise_Invert_Position_BinaryStringFits(
        string binaryString,
        int position,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.Invert((ulong)position);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", "0000")]
    [TestCase("1100", "0011")]
    [TestCase("0011", "1100")]
    [TestCase("0000", "1111")]
    public void BitWise_InvertAll_BinaryStringFits(
        string binaryString,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.InvertAll();
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", "1111")]
    [TestCase("1100", "1111")]
    [TestCase("0011", "1111")]
    [TestCase("0000", "1111")]
    public void BitWise_SetAll_BinaryStringFits(
        string binaryString,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.SetAll();
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("1111", "0000")]
    [TestCase("1100", "0000")]
    [TestCase("0011", "0000")]
    [TestCase("0000", "0000")]
    public void BitWise_ResetAll_BinaryStringFits(
        string binaryString,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.ResetAll();
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("10010111", 1, "11001011")]
    [TestCase("10010111", 2, "11100101")]
    [TestCase("10010111", 3, "11110010")]
    [TestCase("10010111", 4, "11111001")]
    [TestCase("01111011", 1, "00111101")]
    [TestCase("01111011", 2, "00011110")]
    [TestCase("01111011", 3, "00001111")]
    [TestCase("01111011", 4, "00000111")]
    public void BitWise_ArithmeticShiftRight_BinaryString_Count_BinaryStringFits(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.ArithmeticShiftRight((ulong)count);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(123, 1, 61)]
    [TestCase(123, 2, 30)]
    [TestCase(123, 3, 15)]
    [TestCase(123, 4, 7)]
    public void BitWise_ArithmeticShiftRight_Byte_Count_NumberFits(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ArithmeticShiftRight((ulong)count);
        var changedBinaryString = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase(-105, 1, -53)]
    [TestCase(-105, 2, -27)]
    [TestCase(-105, 3, -14)]
    [TestCase(-105, 4, -7)]
    public void BitWise_ArithmeticShiftRight_SByte_Count_NumberFits(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ArithmeticShiftRight((ulong)count);
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
    public void BitWise_ArithmeticShiftLeft_BinaryString_Count_BinaryStringFits(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.ArithmeticShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(123, 1, 246)]
    [TestCase(123, 2, 236)]
    [TestCase(123, 3, 216)]
    [TestCase(123, 4, 176)]
    public void BitWise_ArithmeticShiftLeft_Byte_Count_NumberFits(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ArithmeticShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase(-105, 1, 46)]
    [TestCase(-105, 2, 92)]
    [TestCase(-105, 3, -72)]
    [TestCase(-105, 4, 112)]
    public void BitWise_ArithmeticShiftLeft_SByte_Count_NumberFits(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ArithmeticShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase("10010111", 1, "01001011")]
    [TestCase("10010111", 2, "00100101")]
    [TestCase("10010111", 3, "00010010")]
    [TestCase("10010111", 4, "00001001")]
    [TestCase("01111011", 1, "00111101")]
    [TestCase("01111011", 2, "00011110")]
    [TestCase("01111011", 3, "00001111")]
    [TestCase("01111011", 4, "00000111")]
    public void BitWise_LogicalShiftRight_BinaryString_Count_BinaryStringFits(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.LogicalShiftRight((ulong)count);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(123, 1, 61)]
    [TestCase(123, 2, 30)]
    [TestCase(123, 3, 15)]
    [TestCase(123, 4, 7)]
    public void BitWise_LogicalShiftRight_Byte_Count_NumberFits(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.LogicalShiftRight((ulong)count);
        var changedBinaryString = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase(-105, 1, 75)]
    [TestCase(-105, 2, 37)]
    [TestCase(-105, 3, 18)]
    [TestCase(-105, 4, 9)]
    public void BitWise_LogicalShiftRight_SByte_Count_NumberFits(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.LogicalShiftRight((ulong)count);
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
    public void BitWise_LogicalShiftLeft_BinaryString_Count_BinaryStringFits(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.LogicalShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(123, 1, 246)]
    [TestCase(123, 2, 236)]
    [TestCase(123, 3, 216)]
    [TestCase(123, 4, 176)]
    public void BitWise_LogicalShiftLeft_Byte_Count_NumberFits(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.LogicalShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase(-105, 1, 46)]
    [TestCase(-105, 2, 92)]
    [TestCase(-105, 3, -72)]
    [TestCase(-105, 4, 112)]
    public void BitWise_LogicalShiftLeft_SByte_Count_NumberFits(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.LogicalShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase("10010111", 1, "11001011")]
    [TestCase("10010111", 2, "11100101")]
    [TestCase("10010111", 3, "11110010")]
    [TestCase("10010111", 4, "01111001")]
    [TestCase("01111011", 1, "10111101")]
    [TestCase("01111011", 2, "11011110")]
    [TestCase("01111011", 3, "01101111")]
    [TestCase("01111011", 4, "10110111")]
    public void BitWise_CircularShiftRight_BinaryString_Count_BinaryStringFits(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.CircularShiftRight((ulong)count);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(123, 1, 189)]
    [TestCase(123, 2, 222)]
    [TestCase(123, 3, 111)]
    [TestCase(123, 4, 183)]
    public void BitWise_CircularShiftRight_Byte_Count_NumberFits(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.CircularShiftRight((ulong)count);
        var changedBinaryString = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase(-105, 1, -53)]
    [TestCase(-105, 2, -27)]
    [TestCase(-105, 3, -14)]
    [TestCase(-105, 4, 121)]
    public void BitWise_CircularShiftRight_SByte_Count_NumberFits(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.CircularShiftRight((ulong)count);
        var changedBinaryString = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase("10010111", 1, "00101111")]
    [TestCase("10010111", 2, "01011110")]
    [TestCase("10010111", 3, "10111100")]
    [TestCase("10010111", 4, "01111001")]
    [TestCase("01111011", 1, "11110110")]
    [TestCase("01111011", 2, "11101101")]
    [TestCase("01111011", 3, "11011011")]
    [TestCase("01111011", 4, "10110111")]
    public void BitWise_CircularShiftLeft_BinaryString_Count_BinaryStringFits(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.CircularShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(123, 1, 246)]
    [TestCase(123, 2, 237)]
    [TestCase(123, 3, 219)]
    [TestCase(123, 4, 183)]
    public void BitWise_CircularShiftLeft_Byte_Count_NumberFits(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.CircularShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase(-105, 1, 47)]
    [TestCase(-105, 2, 94)]
    [TestCase(-105, 3, -68)]
    [TestCase(-105, 4, 121)]
    public void BitWise_CircularShiftLeft_SByte_Count_NumberFits(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.CircularShiftLeft((ulong)count);
        var changedBinaryString = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(changedBinaryString == expectedValue);
    }

    [TestCase("10010111", 1, Bit.False, "01001011")]
    [TestCase("10010111", 2, Bit.False, "00100101")]
    [TestCase("10010111", 3, Bit.False, "00010010")]
    [TestCase("10010111", 4, Bit.False, "00001001")]
    [TestCase("01111011", 1, Bit.True, "10111101")]
    [TestCase("01111011", 2, Bit.True, "11011110")]
    [TestCase("01111011", 3, Bit.True, "11101111")]
    [TestCase("01111011", 4, Bit.True, "11110111")]
    public void BitWise_ShiftRight_Bit_Count_BinaryStringFits(
        string binaryString,
        int count,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.ShiftRight((ulong)count, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("10010111", 1, Bit.False, "00101110")]
    [TestCase("10010111", 2, Bit.False, "01011100")]
    [TestCase("10010111", 3, Bit.False, "10111000")]
    [TestCase("10010111", 4, Bit.False, "01110000")]
    [TestCase("01111011", 1, Bit.True, "11110111")]
    [TestCase("01111011", 2, Bit.True, "11101111")]
    [TestCase("01111011", 3, Bit.True, "11011111")]
    [TestCase("01111011", 4, Bit.True, "10111111")]
    public void BitWise_ShiftLeft_Bit_Count_BinaryStringFits(
        string binaryString,
        int count,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet.ShiftLeft((ulong)count, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase(64, 1, Bit.False, 32)]
    [TestCase(64, 2, Bit.False, 16)]
    [TestCase(64, 3, Bit.False, 8)]
    [TestCase(64, 4, Bit.False, 4)]
    [TestCase(64, 1, Bit.True, 160)]
    [TestCase(64, 2, Bit.True, 208)]
    [TestCase(64, 3, Bit.True, 232)]
    [TestCase(64, 4, Bit.True, 244)]
    public void BitWise_ShiftRight_Byte_Count_ChangedValueFits(
        byte value,
        int count,
        Bit shiftInBit,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ShiftRight((ulong)count, shiftInBit);
        var changedValue = netBitSet.ToByte();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase((ushort)4096, 1, Bit.False, (ushort)2048)]
    [TestCase((ushort)4096, 2, Bit.False, (ushort)1024)]
    [TestCase((ushort)4096, 3, Bit.False, (ushort)512)]
    [TestCase((ushort)4096, 4, Bit.False, (ushort)256)]
    [TestCase((ushort)4096, 1, Bit.True, (ushort)34816)]
    [TestCase((ushort)4096, 2, Bit.True, (ushort)50176)]
    [TestCase((ushort)4096, 3, Bit.True, (ushort)57856)]
    [TestCase((ushort)4096, 4, Bit.True, (ushort)61696)]
    public void BitWise_ShiftRight_UShort_Count_ChangedValueFits(
        ushort value,
        int count,
        Bit shiftInBit,
        ushort expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ShiftRight((ulong)count, shiftInBit);
        var changedValue = netBitSet.ToUShort();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase((uint)1073741824, 1, Bit.False, (uint)536870912)]
    [TestCase((uint)1073741824, 2, Bit.False, (uint)268435456)]
    [TestCase((uint)1073741824, 3, Bit.False, (uint)134217728)]
    [TestCase((uint)1073741824, 4, Bit.False, (uint)67108864)]
    [TestCase((uint)1073741824, 1, Bit.True, 2684354560)]
    [TestCase((uint)1073741824, 2, Bit.True, 3489660928)]
    [TestCase((uint)1073741824, 3, Bit.True, 3892314112)]
    [TestCase((uint)1073741824, 4, Bit.True, 4093640704)]
    public void BitWise_ShiftRight_UInt_Count_ChangedValueFits(
        uint value,
        int count,
        Bit shiftInBit,
        uint expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ShiftRight((ulong)count, shiftInBit);
        var changedValue = netBitSet.ToUInt();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase((ulong)4611686018427387904, 1, Bit.False, (ulong)2305843009213693952)]
    [TestCase((ulong)4611686018427387904, 2, Bit.False, (ulong)1152921504606846976)]
    [TestCase((ulong)4611686018427387904, 3, Bit.False, (ulong)576460752303423488)]
    [TestCase((ulong)4611686018427387904, 4, Bit.False, (ulong)288230376151711744)]
    [TestCase((ulong)4611686018427387904, 1, Bit.True, 11529215046068469760)]
    [TestCase((ulong)4611686018427387904, 2, Bit.True, 14987979559889010688)]
    [TestCase((ulong)4611686018427387904, 3, Bit.True, 16717361816799281152)]
    [TestCase((ulong)4611686018427387904, 4, Bit.True, 17582052945254416384)]
    public void BitWise_ShiftRight_ULong_Count_ChangedValueFits(
        ulong value,
        int count,
        Bit shiftInBit,
        ulong expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ShiftRight((ulong)count, shiftInBit);
        var changedValue = netBitSet.ToULong();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase(8, 1, Bit.False, 16)]
    [TestCase(8, 2, Bit.False, 32)]
    [TestCase(8, 3, Bit.False, 64)]
    [TestCase(8, 4, Bit.False, 128)]
    [TestCase(8, 1, Bit.True, 17)]
    [TestCase(8, 2, Bit.True, 35)]
    [TestCase(8, 3, Bit.True, 71)]
    [TestCase(8, 4, Bit.True, 143)]
    public void BitWise_ShiftLeft_Byte_Count_ChangedValueFits(
        byte value,
        int count,
        Bit shiftInBit,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ShiftLeft((ulong)count, shiftInBit);
        var changedValue = netBitSet.ToByte();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase((ushort)4096, 1, Bit.False, (ushort)8192)]
    [TestCase((ushort)4096, 2, Bit.False, (ushort)16384)]
    [TestCase((ushort)4096, 3, Bit.False, (ushort)32768)]
    [TestCase((ushort)4096, 4, Bit.False, (ushort)0)]
    [TestCase((ushort)4096, 1, Bit.True, (ushort)8193)]
    [TestCase((ushort)4096, 2, Bit.True, (ushort)16387)]
    [TestCase((ushort)4096, 3, Bit.True, (ushort)32775)]
    [TestCase((ushort)4096, 4, Bit.True, (ushort)15)]
    public void BitWise_ShiftLeft_UShort_Count_ChangedValueFits(
        ushort value,
        int count,
        Bit shiftInBit,
        ushort expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ShiftLeft((ulong)count, shiftInBit);
        var changedValue = netBitSet.ToUShort();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase((uint)4096, 1, Bit.False, (uint)8192)]
    [TestCase((uint)4096, 2, Bit.False, (uint)16384)]
    [TestCase((uint)4096, 3, Bit.False, (uint)32768)]
    [TestCase((uint)4096, 4, Bit.False, (uint)65536)]
    [TestCase((uint)4096, 1, Bit.True, (uint)8193)]
    [TestCase((uint)4096, 2, Bit.True, (uint)16387)]
    [TestCase((uint)4096, 3, Bit.True, (uint)32775)]
    [TestCase((uint)4096, 4, Bit.True, (uint)65551)]
    public void BitWise_ShiftLeft_UInt_Count_ChangedValueFits(
        uint value,
        int count,
        Bit shiftInBit,
        uint expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ShiftLeft((ulong)count, shiftInBit);
        var changedValue = netBitSet.ToUInt();

        // assert
        Assert.That(changedValue == expectedValue);
    }

    [TestCase((ulong)1073741824, 1, Bit.False, (ulong)2147483648)]
    [TestCase((ulong)1073741824, 2, Bit.False, (ulong)4294967296)]
    [TestCase((ulong)1073741824, 3, Bit.False, (ulong)8589934592)]
    [TestCase((ulong)1073741824, 4, Bit.False, (ulong)17179869184)]
    [TestCase((ulong)1073741824, 1, Bit.True, (ulong)2147483649)]
    [TestCase((ulong)1073741824, 2, Bit.True, (ulong)4294967299)]
    [TestCase((ulong)1073741824, 3, Bit.True, (ulong)8589934599)]
    [TestCase((ulong)1073741824, 4, Bit.True, (ulong)17179869199)]
    public void BitWise_ShiftLeft_ULong_Count_ChangedValueFits(
        ulong value,
        int count,
        Bit shiftInBit,
        ulong expectedValue)
    {
        // arrange 
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.ShiftLeft((ulong)count, shiftInBit);
        var changedValue = netBitSet.ToULong();

        // assert
        Assert.That(changedValue == expectedValue);
    }
}