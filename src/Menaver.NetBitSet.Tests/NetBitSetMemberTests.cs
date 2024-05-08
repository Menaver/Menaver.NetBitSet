using System.Text;
using Menaver.NetBitSet.Shared;
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

        var netBitSet = new Shared.NetBitSet(randomValues);

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

        var netBitSet = new Shared.NetBitSet(randomValues);

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

        var netBitSet = new Shared.NetBitSet(randomValues);

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

        var netBitSet = new Shared.NetBitSet(randomValues);

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

        var netBitSet = new Shared.NetBitSet(randomValues);

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

        var netBitSet = new Shared.NetBitSet(value, Encoding.ASCII);

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

        var netBitSet = new Shared.NetBitSet(value, Encoding.Unicode);

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
}