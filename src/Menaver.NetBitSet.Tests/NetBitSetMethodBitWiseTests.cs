using Menaver.NetBitSet.Shared;
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
    public void BitWise_And_Bool_BinaryStringChanged(
        string binaryString,
        int index,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_And_Byte_BinaryStringChanged(
        string binaryString,
        int index,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_And_Int_BinaryStringChanged(
        string binaryString,
        int index,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_And_Double_BinaryStringChanged(
        string binaryString,
        int index,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_And_Bit_BinaryStringChanged(
        string binaryString,
        int index,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_And_NetBitSet_BinaryStringChanged(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new Shared.NetBitSet(binaryStringA);
        var netBitSetB = new Shared.NetBitSet(binaryStringB);

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
    public void BitWise_AndAll_Bool_BinaryStringChanged(
        string binaryString,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_AndAll_Byte_BinaryStringChanged(
        string binaryString,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_AndAll_Int_BinaryStringChanged(
        string binaryString,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_AndAll_Double_BinaryStringChanged(
        string binaryString,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_AndAll_Bit_BinaryStringChanged(
        string binaryString,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Or_Bool_BinaryStringChanged(
        string binaryString,
        int index,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Or_Byte_BinaryStringChanged(
        string binaryString,
        int index,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Or_Int_BinaryStringChanged(
        string binaryString,
        int index,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Or_Double_BinaryStringChanged(
        string binaryString,
        int index,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Or_Bit_BinaryStringChanged(
        string binaryString,
        int index,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Or_NetBitSet_BinaryStringChanged(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new Shared.NetBitSet(binaryStringA);
        var netBitSetB = new Shared.NetBitSet(binaryStringB);

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
    public void BitWise_OrAll_Bool_BinaryStringChanged(
        string binaryString,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_OrAll_Byte_BinaryStringChanged(
        string binaryString,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_OrAll_Int_BinaryStringChanged(
        string binaryString,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_OrAll_Double_BinaryStringChanged(
        string binaryString,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_OrAll_Bit_BinaryStringChanged(
        string binaryString,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Xor_Bool_BinaryStringChanged(
        string binaryString,
        int index,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Xor_Byte_BinaryStringChanged(
        string binaryString,
        int index,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Xor_Int_BinaryStringChanged(
        string binaryString,
        int index,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Xor_Double_BinaryStringChanged(
        string binaryString,
        int index,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Xor_Bit_BinaryStringChanged(
        string binaryString,
        int index,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Xor_NetBitSet_BinaryStringChanged(
        string binaryStringA,
        string binaryStringB,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSetA = new Shared.NetBitSet(binaryStringA);
        var netBitSetB = new Shared.NetBitSet(binaryStringB);

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
    public void BitWise_XorAll_Bool_BinaryStringChanged(
        string binaryString,
        bool bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_XorAll_Byte_BinaryStringChanged(
        string binaryString,
        byte bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_XorAll_Int_BinaryStringChanged(
        string binaryString,
        int bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_XorAll_Double_BinaryStringChanged(
        string binaryString,
        double bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_XorAll_Bit_BinaryStringChanged(
        string binaryString,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_Invert_Position_BinaryStringChanged(
        string binaryString,
        int position,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_InvertAll_BinaryStringChanged(
        string binaryString,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_SetAll_BinaryStringChanged(
        string binaryString,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_ResetAll_BinaryStringChanged(
        string binaryString,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_ArithmeticShiftRight_BinaryString_Count_BinaryStringChanged(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_ArithmeticShiftRight_Byte_Count_BinaryStringChanged(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_ArithmeticShiftRight_SByte_Count_BinaryStringChanged(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_ArithmeticShiftLeft_BinaryString_Count_BinaryStringChanged(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_ArithmeticShiftLeft_Byte_Count_BinaryStringChanged(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_ArithmeticShiftLeft_SByte_Count_BinaryStringChanged(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_LogicalShiftRight_BinaryString_Count_BinaryStringChanged(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_LogicalShiftRight_Byte_Count_BinaryStringChanged(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_LogicalShiftRight_SByte_Count_BinaryStringChanged(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_LogicalShiftLeft_BinaryString_Count_BinaryStringChanged(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_LogicalShiftLeft_Byte_Count_BinaryStringChanged(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_LogicalShiftLeft_SByte_Count_BinaryStringChanged(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_CircularShiftRight_BinaryString_Count_BinaryStringChanged(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_CircularShiftRight_Byte_Count_BinaryStringChanged(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_CircularShiftRight_SByte_Count_BinaryStringChanged(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_CircularShiftLeft_BinaryString_Count_BinaryStringChanged(
        string binaryString,
        int count,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_CircularShiftLeft_Byte_Count_BinaryStringChanged(
        byte value,
        int count,
        byte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_CircularShiftLeft_SByte_Count_BinaryStringChanged(
        sbyte value,
        int count,
        sbyte expectedValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

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
    public void BitWise_ShiftRight_Bit_Count_BinaryStringChanged(
        string binaryString,
        int count,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

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
    public void BitWise_ShiftLeft_Bit_Count_BinaryStringChanged(
        string binaryString,
        int count,
        Bit bit,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(binaryString);

        // act
        netBitSet.ShiftLeft((ulong)count, bit);
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }
}