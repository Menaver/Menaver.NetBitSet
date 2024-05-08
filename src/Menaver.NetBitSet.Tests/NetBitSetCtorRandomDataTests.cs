using System.Text;
using Menaver.NetBitSet.Shared;
using Menaver.NetBitSet.Shared.Extensions;
using NUnit.Framework.Internal;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetCtorRandomDataTests
{
    private static readonly Randomizer Randomizer = Randomizer.CreateRandomizer();

    [Test]
    public void Count_RandomLength_RandomDefaultValue_SetupComplies()
    {
        // arrange
        var randomCount = Randomizer.NextULong((ulong)short.MaxValue);
        var randomDefaultValue = Randomizer.NextBool().ToBit();
        var netBitSet = new Shared.NetBitSet(randomCount, randomDefaultValue);

        // act

        // assert
        Assert.That(netBitSet.Count == randomCount);
        Assert.That(netBitSet.WordLength == WordLength.One);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Count_RandomLength_RandomDefaultValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomCount = Randomizer.NextULong((ulong)short.MaxValue);
        var randomDefaultValue = Randomizer.NextBool().ToBit();
        var netBitSet = new Shared.NetBitSet(randomCount, randomDefaultValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == randomCount);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Bool_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextBool();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 1);
        Assert.That(netBitSet.WordLength == WordLength.One);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void Bool_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange
        var randomValue = Randomizer.NextBool();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 1);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void SByte_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextSByte();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(netBitSet.WordLength == WordLength.Eight);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void SByte_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextSByte();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Byte_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextByte();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(netBitSet.WordLength == WordLength.Eight);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void Byte_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextByte();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Short_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextShort();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(netBitSet.WordLength == WordLength.Sixteen);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void Short_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextShort();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void UShort_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextUShort();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(netBitSet.WordLength == WordLength.Sixteen);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void UShort_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextUShort();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Int_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.Next();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(netBitSet.WordLength == WordLength.ThirtyTwo);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void Int_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.Next();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void UInt_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextUInt();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(netBitSet.WordLength == WordLength.ThirtyTwo);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void UInt_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextUInt();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Long_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextInt64();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void Long_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextInt64();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void ULong_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextULong();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void ULong_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextULong();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Double_RandomValue_SetupComplies()
    {
        // arrange 
        var randomValue = Randomizer.NextDouble();
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void Double_RandomValue_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange
        var randomValue = Randomizer.NextDouble();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(25)]
    [TestCase(2)]
    [TestCase(75)]
    public void String_RandomNormalString_SetupComplies(
        int stringLengthLimit)
    {
        // arrange 
        var randomValue = Randomizer.GetString(stringLengthLimit);
        var netBitSet = new Shared.NetBitSet(randomValue);

        // act

        // assert
        Assert.That(netBitSet.WordLength == WordLength.NotFixed);
    }

    [TestCase(25, "us-ascii", WordLength.Eight)]
    [TestCase(2, "utf-8", WordLength.NotFixed)]
    [TestCase(75, "us-ascii", WordLength.Eight)]
    [TestCase(16, "utf-8", WordLength.NotFixed)]
    [TestCase(7, "utf-8", WordLength.NotFixed)]
    public void String_RandomNormalString_Encoding_SetupComplies(
        int stringLengthLimit,
        string encodingName,
        WordLength expectedWordLength)
    {
        // arrange 
        var randomValue = Randomizer.GetString(stringLengthLimit);
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(randomValue, encoding);

        // act

        // assert
        Assert.That(netBitSet.WordLength == expectedWordLength);
    }

    [Test]
    public void Bools_RandomValues_SetupComplies()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        var netBitSet = new Shared.NetBitSet(randomValues);

        // act

        // assert
        Assert.That(netBitSet.Count == count);
        Assert.That(netBitSet.WordLength == WordLength.One);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Bools_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new bool[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextBool();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == count);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void SBytes_RandomValues_SetupComplies()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new sbyte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextSByte();
        }

        var netBitSet = new Shared.NetBitSet(randomValues);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.Eight));
        Assert.That(netBitSet.WordLength == WordLength.Eight);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void SBytes_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new sbyte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextSByte();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.Eight));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Bytes_RandomValues_SetupComplies()
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

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.Eight));
        Assert.That(netBitSet.WordLength == WordLength.Eight);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Bytes_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new byte[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextByte();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.Eight));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Shorts_RandomValues_SetupComplies()
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

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.Sixteen));
        Assert.That(netBitSet.WordLength == WordLength.Sixteen);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Shorts_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new short[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextShort();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.Sixteen));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void UShorts_RandomValues_SetupComplies()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new ushort[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUShort();
        }

        var netBitSet = new Shared.NetBitSet(randomValues);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.Sixteen));
        Assert.That(netBitSet.WordLength == WordLength.Sixteen);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void UShorts_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new ushort[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUShort();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.Sixteen));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Ints_RandomValues_SetupComplies()
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

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.ThirtyTwo));
        Assert.That(netBitSet.WordLength == WordLength.ThirtyTwo);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Ints_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new int[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.Next();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.ThirtyTwo));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void UInts_RandomValues_SetupComplies()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new uint[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUInt();
        }

        var netBitSet = new Shared.NetBitSet(randomValues);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.ThirtyTwo));
        Assert.That(netBitSet.WordLength == WordLength.ThirtyTwo);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void UInts_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new uint[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextUInt();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.ThirtyTwo));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Longs_RandomValues_SetupComplies()
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

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.SixtyFour));
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Longs_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new long[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextLong();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.SixtyFour));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void ULongs_RandomValues_SetupComplies()
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new ulong[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextULong();
        }

        var netBitSet = new Shared.NetBitSet(randomValues);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.SixtyFour));
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void ULongs_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new ulong[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextULong();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.SixtyFour));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Doubles_RandomValues_SetupComplies()
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

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.SixtyFour));
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Doubles_RandomValues_WordLength_SetupComplies(
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new double[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.NextDouble();
        }

        var netBitSet = new Shared.NetBitSet(randomValues, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == (ulong)(count * (byte)WordLength.SixtyFour));
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(25)]
    [TestCase(2)]
    [TestCase(75)]
    public void Strings_RandomValues_SetupComplies(
        int stringLengthLimit)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new string[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.GetString(stringLengthLimit);
        }

        var netBitSet = new Shared.NetBitSet(randomValues);

        // act

        // assert
        Assert.That(netBitSet.WordLength == WordLength.NotFixed);
    }

    [TestCase(25, "us-ascii", WordLength.Eight)]
    [TestCase(2, "utf-8", WordLength.NotFixed)]
    [TestCase(75, "us-ascii", WordLength.Eight)]
    [TestCase(16, "utf-8", WordLength.NotFixed)]
    [TestCase(7, "utf-8", WordLength.NotFixed)]
    public void Strings_RandomNormalString_Encoding_SetupComplies(
        int stringLengthLimit,
        string encodingName,
        WordLength expectedWordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new string[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.GetString(stringLengthLimit);
        }

        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(randomValues, encoding);

        // act

        // assert
        Assert.That(netBitSet.WordLength == expectedWordLength);
    }

    [TestCase(25, "us-ascii", WordLength.Eight)]
    [TestCase(2, "utf-8", WordLength.NotFixed)]
    [TestCase(75, "us-ascii", WordLength.Eight)]
    [TestCase(16, "utf-8", WordLength.NotFixed)]
    [TestCase(7, "utf-8", WordLength.NotFixed)]
    public void Strings_RandomNormalString_Encoding_WordLength_SetupComplies(
        int stringLengthLimit,
        string encodingName,
        WordLength wordLength)
    {
        // arrange 
        var count = Randomizer.NextByte();
        var randomValues = new string[count];
        for (var i = 0; i < count; i++)
        {
            randomValues[i] = Randomizer.GetString(stringLengthLimit);
        }

        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(randomValues, encoding, wordLength);

        // act

        // assert
        Assert.That(netBitSet.WordLength == wordLength);
    }
}