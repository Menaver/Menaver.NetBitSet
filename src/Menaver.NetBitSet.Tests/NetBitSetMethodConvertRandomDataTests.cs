using System.Text;
using Menaver.NetBitSet.Extensions;
using NUnit.Framework.Internal;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodConvertRandomDataTests
{
    private static readonly Randomizer Randomizer = Randomizer.CreateRandomizer();

    [Test]
    public void Count_RandomLength_RandomDefaultValue_RevertedValueEquals()
    {
        // arrange
        var randomCount = Randomizer.NextULong((ulong)short.MaxValue);
        var randomDefaultValue = Randomizer.NextBool().ToBit();
        var netBitSet = new NetBitSet(randomCount, randomDefaultValue);

        // act
        var compliesWithDefaultValue = netBitSet.All(bit => bit == randomDefaultValue);

        // assert
        Assert.That(compliesWithDefaultValue);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Count_RandomLength_RandomDefaultValue_WordLength_RevertedValueEquals(
        WordLength wordLength)
    {
        // arrange 
        var randomCount = Randomizer.NextULong((ulong)short.MaxValue);
        var randomDefaultValue = Randomizer.NextBool().ToBit();
        var netBitSet = new NetBitSet(randomCount, randomDefaultValue, wordLength);

        // act
        var compliesWithDefaultValue = netBitSet.All(bit => bit == randomDefaultValue);

        // assert
        Assert.That(compliesWithDefaultValue);
    }

    [Test]
    public void Bool_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextBool();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToBools().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void SByte_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextSByte();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void Byte_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextByte();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void Short_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextShort();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToShorts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void UShort_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextUShort();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToUShorts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void Int_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.Next();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToInts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void UInt_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextUInt();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToUInts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void Long_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextLong();
        var netBitSet = new NetBitSet(randomValue);

        // act

        // act
        var revertedValue = netBitSet.ToLongs().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void ULong_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextULong();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToULongs().FirstOrDefault();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [Test]
    public void Double_RandomValue_RevertedValueEquals()
    {
        // arrange 
        var randomValue = Randomizer.NextDouble();
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToDoubles().FirstOrDefault();

        // assert
        Assert.That(revertedValue - randomValue < 0.00000001);
    }

    [TestCase(25)]
    [TestCase(2)]
    [TestCase(75)]
    public void String_RandomNormalString_RevertedValueEquals(
        int stringLengthLimit)
    {
        // arrange 
        var randomValue = Randomizer.GetString(stringLengthLimit);
        var netBitSet = new NetBitSet(randomValue);

        // act
        var revertedValue = netBitSet.ToString();

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [TestCase(25, "us-ascii")]
    [TestCase(2, "utf-8")]
    [TestCase(75, "us-ascii")]
    [TestCase(16, "utf-8")]
    [TestCase(7, "utf-8")]
    public void String_RandomNormalString_Encoding_RevertedValueEquals(
        int stringLengthLimit,
        string encodingName)
    {
        // arrange 
        var randomValue = Randomizer.GetString(stringLengthLimit);
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new NetBitSet(randomValue, encoding);

        // act
        var revertedValue = netBitSet.ToString(encoding);

        // assert
        Assert.That(revertedValue == randomValue);
    }

    [TestCase(25, "us-ascii", WordLength.Sixteen)]
    [TestCase(2, "utf-8", WordLength.NotFixed)]
    [TestCase(75, "us-ascii", WordLength.Sixteen)]
    [TestCase(16, "utf-8", WordLength.NotFixed)]
    [TestCase(7, "utf-8", WordLength.NotFixed)]
    public void String_RandomNormalString_Encoding_RevertedValueEquals(
        int stringLengthLimit,
        string encodingName,
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.GetString(stringLengthLimit);
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new NetBitSet(randomValue, encoding, wordLength);

        // act
        var revertedValue = netBitSet.ToString(encoding);

        // assert
        Assert.That(revertedValue == randomValue);
    }


    [Test]
    public void Bools_RandomValues_RevertedValueEquals()
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
        var revertedValues = netBitSet.ToBools();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Bools_RandomValues_WordLength_RevertedValueEquals(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        var netBitSet = new NetBitSet(randomValues, wordLength);

        // act
        var revertedValues = netBitSet.ToBools();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void SBytes_RandomValues_RevertedValueEquals()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new sbyte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextSByte();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var revertedValues = netBitSet.ToSBytes();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Bytes_RandomValues_RevertedValueEquals()
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
        var revertedValues = netBitSet.ToBytes();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Shorts_RandomValues_RevertedValueEquals()
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
        var revertedValues = netBitSet.ToShorts();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void UShorts_RandomValues_RevertedValueEquals()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new ushort[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUShort();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var revertedValues = netBitSet.ToUShorts();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Ints_RandomValues_RevertedValueEquals()
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
        var revertedValues = netBitSet.ToInts();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void UInts_RandomValues_RevertedValueEquals()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new uint[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUInt();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var revertedValues = netBitSet.ToUInts();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Longs_RandomValues_RevertedValueEquals()
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
        var revertedValues = netBitSet.ToLongs();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void ULongs_RandomValues_RevertedValueEquals()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new ulong[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextULong();
        }

        var netBitSet = new NetBitSet(randomValues);

        // act
        var revertedValues = netBitSet.ToULongs();
        var equal = randomValues.SequenceEqual(revertedValues);

        // assert
        Assert.That(equal);
    }

    [Test]
    public void Doubles_RandomValues_RevertedValueEquals()
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
        var revertedValues = netBitSet.ToDoubles();
        var equal = true;
        for (var i = 0; i < revertedValues.Length; i++)
        {
            if (!(revertedValues[i] - randomValues[i] < 0.000000001))
            {
                equal = false;
                break;
            }
        }

        // assert
        Assert.That(equal);
    }
}