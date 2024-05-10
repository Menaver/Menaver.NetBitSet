using Menaver.NetBitSet.Extensions;
using NUnit.Framework.Internal;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodTests
{
    private static readonly Randomizer Randomizer = Randomizer.CreateRandomizer();

    [TestCase(0, 0, 1)]
    [TestCase(0, 1, 2)]
    [TestCase(0, 2, 4)]
    [TestCase(0, 3, 8)]
    public void Indexer_Int_SetElementByIndex_NumberChanged(
        int number,
        int indexOfElementToSet,
        int expectedNumber)
    {
        // arrange 
        var netBitSet = new NetBitSet(number);

        // act
        netBitSet[(ulong)indexOfElementToSet] = Bit.True;
        var changedNumber = netBitSet.ToInts().FirstOrDefault();

        // assert
        Assert.That(changedNumber == expectedNumber);
    }

    [TestCase("0000", 0, "0001")]
    [TestCase("0000", 1, "0010")]
    [TestCase("0000", 2, "0100")]
    [TestCase("0000", 3, "1000")]
    public void Indexer_BinaryString_SetElementByIndex_BinaryStringChanged(
        string binaryString,
        int indexOfElementToSet,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet[(ulong)indexOfElementToSet] = Bit.True;
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("00000000", 0, 1)] // 00000001
    [TestCase("00000000", 1, 2)] // 00000010
    [TestCase("00000000", 2, 4)] // 00000100
    [TestCase("00000000", 3, 8)] // 00001000
    public void Indexer_BinaryString_SetElementByIndex_NumberChanged(
        string binaryString,
        int indexOfElementToSet,
        byte expectedNumber)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString, WordLength.Eight);

        // act
        netBitSet[(ulong)indexOfElementToSet] = Bit.True;
        var changedNumber = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedNumber == expectedNumber);
    }

    [TestCase(15, 0, 14)]
    [TestCase(15, 1, 13)]
    [TestCase(15, 2, 11)]
    [TestCase(15, 3, 7)]
    public void Indexer_Int_ResetElementByIndex_NumberChanged(
        int number,
        int indexOfElementToSet,
        int expectedNumber)
    {
        // arrange 
        var netBitSet = new NetBitSet(number);

        // act
        netBitSet[(ulong)indexOfElementToSet] = Bit.False;
        var changedNumber = netBitSet.ToInts().FirstOrDefault();

        // assert
        Assert.That(changedNumber == expectedNumber);
    }

    [TestCase("1111", 0, "1110")]
    [TestCase("1111", 1, "1101")]
    [TestCase("1111", 2, "1011")]
    [TestCase("1111", 3, "0111")]
    public void Indexer_BinaryString_ResetElementByIndex_BinaryStringChanged(
        string binaryString,
        int indexOfElementToSet,
        string expectedBinaryString)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString);

        // act
        netBitSet[(ulong)indexOfElementToSet] = Bit.False;
        var changedBinaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(changedBinaryString == expectedBinaryString);
    }

    [TestCase("00001111", 0, 14)] // 00001110
    [TestCase("00001111", 1, 13)] // 00001101
    [TestCase("00001111", 2, 11)] // 00001011
    [TestCase("00001111", 3, 7)] // 00000111
    public void Indexer_BinaryString_ResetElementByIndex_NumberChanged(
        string binaryString,
        int indexOfElementToSet,
        byte expectedNumber)
    {
        // arrange 
        var netBitSet = new NetBitSet(binaryString, WordLength.Eight);

        // act
        netBitSet[(ulong)indexOfElementToSet] = Bit.False;
        var changedNumber = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(changedNumber == expectedNumber);
    }

    [Test]
    public void Indexer_Bytes_SetElementByIndex_NumberChanged()
    {
        // arrange 
        var bytes = new byte[] { 0, 34, 2, 5, 9, 34, 7, 255 };
        var netBitSet = new NetBitSet(bytes);

        // act
        netBitSet[3] = Bit.True;
        netBitSet[12] = Bit.True;
        netBitSet[22] = Bit.False;
        netBitSet[27] = Bit.True;
        netBitSet[38] = Bit.False;
        netBitSet[42] = Bit.True;
        netBitSet[48] = Bit.True;
        netBitSet[63] = Bit.False;

        var changedBytes = netBitSet.ToBytes();

        // assert
        Assert.That(changedBytes[0] == 8);
        Assert.That(changedBytes[1] == 50);
        Assert.That(changedBytes[2] == 2);
        Assert.That(changedBytes[3] == 13);
        Assert.That(changedBytes[4] == 9);
        Assert.That(changedBytes[5] == 38);
        Assert.That(changedBytes[6] == 7);
        Assert.That(changedBytes[7] == 127);
    }

    [Test]
    public void Resize_RandomData_Shrink_CountComplies()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var newCount = Randomizer.NextByte(max: (byte)(count - 1));
        netBitSet.Resize(newCount);

        // assert
        Assert.That(netBitSet.Count == newCount);
    }

    [Test]
    public void Resize_RandomData_Expand_CountComplies()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var newCount = Randomizer.NextUInt(min: count, max: ushort.MaxValue);
        netBitSet.Resize(newCount);

        var addedDataIsCorrect = true;
        for (int i = count; i < newCount; i++)
        {
            if (netBitSet[(ulong)i] != Bit.False)
            {
                addedDataIsCorrect = false;

                break;
            }
        }

        // assert
        Assert.That(netBitSet.Count == newCount);
        Assert.That(addedDataIsCorrect);
    }

    [Test]
    public void GetEnumerator_RandomData_SelectedValuesEqual()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var buffer = netBitSet.Select(x => x.ToBool()).ToArray();
        var equal = randomValues.SequenceEqual(buffer);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Clone_RandomData_Equals()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var netBitSetCloned = (NetBitSet)netBitSet.Clone();

        var countsEqual = netBitSet.Count == netBitSetCloned.Count;
        var wordLengthsEqual = netBitSet.WordLength == netBitSetCloned.WordLength;
        var dataEqual = true;
        for (int i = count; i < count; i++)
        {
            if (netBitSet[(ulong)i] != netBitSetCloned[(ulong)i])
            {
                dataEqual = false;

                break;
            }
        }

        // assert
        Assert.That(countsEqual);
        Assert.That(wordLengthsEqual);
        Assert.That(dataEqual);
    }

    [Test]
    public void Equals_RandomData_Equals()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var netBitSetCloned = (NetBitSet)netBitSet.Clone();

        // assert
        Assert.That(netBitSet.Equals(netBitSetCloned));
    }
}