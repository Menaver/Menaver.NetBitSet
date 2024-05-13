using System.Text;
using NUnit.Framework.Internal;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMemberTests
{
    private static readonly Randomizer Randomizer = Randomizer.CreateRandomizer();

    [Test]
    public void Bytes_RandomValues_MembersComply()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new byte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextByte();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var expectedWordLength = WordLength.Eight;
        var systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
        var expectedCount = (ulong)(count * (byte)expectedWordLength);
        var expectedWordCount = expectedCount / (byte)expectedWordLength;
        var expectedByteCount = expectedCount / (byte)WordLength.Eight;

        // assert
        Assert.That(netBitSet.Count == expectedCount);
        Assert.That(netBitSet.WordLength == expectedWordLength);
        Assert.That(netBitSet.Endianness == systemEndianness);
        Assert.That(netBitSet.WordCount == expectedWordCount);
        Assert.That(netBitSet.ByteCount == expectedByteCount);
    }

    [Test]
    public void Shorts_RandomValues_MembersComply()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new short[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextShort();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var expectedWordLength = WordLength.Sixteen;
        var systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
        var expectedCount = (ulong)(count * (byte)expectedWordLength);
        var expectedWordCount = expectedCount / (byte)expectedWordLength;
        var expectedByteCount = expectedCount / (byte)WordLength.Eight;

        // assert
        Assert.That(netBitSet.Count == expectedCount);
        Assert.That(netBitSet.WordLength == expectedWordLength);
        Assert.That(netBitSet.Endianness == systemEndianness);
        Assert.That(netBitSet.WordCount == expectedWordCount);
        Assert.That(netBitSet.ByteCount == expectedByteCount);
    }

    [Test]
    public void Ints_RandomValues_MembersComply()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new int[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.Next();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var expectedWordLength = WordLength.ThirtyTwo;
        var systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
        var expectedCount = (ulong)(count * (byte)expectedWordLength);
        var expectedWordCount = expectedCount / (byte)expectedWordLength;
        var expectedByteCount = expectedCount / (byte)WordLength.Eight;

        // assert
        Assert.That(netBitSet.Count == expectedCount);
        Assert.That(netBitSet.WordLength == expectedWordLength);
        Assert.That(netBitSet.Endianness == systemEndianness);
        Assert.That(netBitSet.WordCount == expectedWordCount);
        Assert.That(netBitSet.ByteCount == expectedByteCount);
    }

    [Test]
    public void Longs_RandomValues_MembersComply()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new long[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextLong();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var expectedWordLength = WordLength.SixtyFour;
        var systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
        var expectedCount = (ulong)(count * (byte)expectedWordLength);
        var expectedWordCount = expectedCount / (byte)expectedWordLength;
        var expectedByteCount = expectedCount / (byte)WordLength.Eight;

        // assert
        Assert.That(netBitSet.Count == expectedCount);
        Assert.That(netBitSet.WordLength == expectedWordLength);
        Assert.That(netBitSet.Endianness == systemEndianness);
        Assert.That(netBitSet.WordCount == expectedWordCount);
        Assert.That(netBitSet.ByteCount == expectedByteCount);
    }

    [Test]
    public void Doubles_RandomValues_MembersComply()
    {
        // arrange
        var count = Randomizer.NextByte();
        var randomValues = new double[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextDouble();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var expectedWordLength = WordLength.SixtyFour;
        var systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
        var expectedCount = (ulong)(count * (byte)expectedWordLength);
        var expectedWordCount = expectedCount / (byte)expectedWordLength;
        var expectedByteCount = expectedCount / (byte)WordLength.Eight;

        // assert
        Assert.That(netBitSet.Count == expectedCount);
        Assert.That(netBitSet.WordLength == expectedWordLength);
        Assert.That(netBitSet.Endianness == systemEndianness);
        Assert.That(netBitSet.WordCount == expectedWordCount);
        Assert.That(netBitSet.ByteCount == expectedByteCount);
    }

    [Test]
    public void String_RandomValue_ASCII_MembersComply()
    {
        // arrange
        var value = Randomizer.GetString();

        var netBitSet = new NetBitSet(value, Encoding.ASCII);

        // act
        var expectedWordLength = WordLength.Eight;
        var systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
        var expectedCount = (ulong)(value.Length * (byte)expectedWordLength);
        var expectedWordCount = expectedCount / (byte)expectedWordLength;
        var expectedByteCount = expectedCount / (byte)WordLength.Eight;

        // assert
        Assert.That(netBitSet.Count == expectedCount);
        Assert.That(netBitSet.WordLength == expectedWordLength);
        Assert.That(netBitSet.Endianness == systemEndianness);
        Assert.That(netBitSet.WordCount == expectedWordCount);
        Assert.That(netBitSet.ByteCount == expectedByteCount);
    }

    [Test]
    public void String_RandomValue_Unicode_MembersComply()
    {
        // arrange
        var value = Randomizer.GetString();

        var netBitSet = new NetBitSet(value, Encoding.Unicode);

        // act
        var expectedWordLength = WordLength.NotFixed;
        var systemEndianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
        var expectedCount = Encoding.Unicode.GetBytes(value).Length * (byte)WordLength.Eight;
        var expectedWordCount = (ulong)1;
        var expectedByteCount = expectedCount / (byte)WordLength.Eight;

        // assert
        Assert.That(netBitSet.Count == (ulong)expectedCount);
        Assert.That(netBitSet.WordLength == expectedWordLength);
        Assert.That(netBitSet.Endianness == systemEndianness);
        Assert.That(netBitSet.WordCount == expectedWordCount);
        Assert.That(netBitSet.ByteCount == expectedByteCount);
    }

    [TestCase("1010", WordLength.One, "0101")]
    [TestCase("11110000", WordLength.One, "00001111")]
    [TestCase("11110000", WordLength.Eight, "00001111")]
    [TestCase("1111000010101010", WordLength.Eight, "0000111101010101")]
    [TestCase("1111000010101010", WordLength.Sixteen, "0101010100001111")]
    public void Endianness_BinnaryString_ChangeEndianness_BitsWithinWordReversed(
        string binaryString,
        WordLength wordLength,
        string expectedBinaryString)
    {
        // arrange
        var netBitSet = new NetBitSet(binaryString, wordLength);

        // act
        netBitSet.Endianness = netBitSet.Endianness == Endian.Little ? Endian.Big : Endian.Little;
        binaryString = netBitSet.ToBinaryString();

        // assert
        Assert.That(binaryString == expectedBinaryString);
    }

    [TestCase(69, 162)]
    [TestCase(74, 82)]
    [TestCase(15, 240)]
    [TestCase(33, 132)]
    [TestCase(3, 192)]
    public void Endianness_Byte_ChangeEndianness_BitsWithinWordReversed(
        byte value,
        byte expectedValue)
    {
        // arrange
        var netBitSet = new NetBitSet(value);

        // act
        netBitSet.Endianness = netBitSet.Endianness == Endian.Little ? Endian.Big : Endian.Little;
        value = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(value == expectedValue);
    }

    [TestCase(new byte[] { 69, 74, 15, 33, 3 }, new byte[] { 162, 82, 240, 132, 192 })]
    public void Endianness_Bytes_ChangeEndianness_BitsWithinWordReversed(
        byte[] values,
        byte[] expectedValues)
    {
        // arrange
        var netBitSet = new NetBitSet(values);

        // act
        netBitSet.Endianness = netBitSet.Endianness == Endian.Little ? Endian.Big : Endian.Little;
        values = netBitSet.ToBytes();
        var equals = values.SequenceEqual(expectedValues);

        // assert
        Assert.That(equals);
    }
}