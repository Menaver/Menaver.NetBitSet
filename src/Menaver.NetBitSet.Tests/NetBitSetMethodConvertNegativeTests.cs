using Menaver.NetBitSet.Shared;
using NUnit.Framework.Internal;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodConvertNegativeTests
{
    private static readonly Randomizer Randomizer = Randomizer.CreateRandomizer();

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void SByte_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextSByte();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToSBytes();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Byte_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextByte();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToBytes();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void Short_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextShort();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToShorts();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.ThirtyTwo)]
    [TestCase(WordLength.SixtyFour)]
    public void UShort_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextUShort();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToUShorts();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.SixtyFour)]
    public void Int_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.Next();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToInts();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.SixtyFour)]
    public void UInt_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextUInt();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToUInts();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void Long_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextLong();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToLongs();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void ULong_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextULong();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToULongs();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }

    [TestCase(WordLength.NotFixed)]
    [TestCase(WordLength.One)]
    [TestCase(WordLength.Eight)]
    [TestCase(WordLength.Sixteen)]
    [TestCase(WordLength.ThirtyTwo)]
    public void Double_RandomValue_NotMarchingWordLength_ThrowsInvalidOperationException(
        WordLength wordLength)
    {
        // arrange 
        var randomValue = Randomizer.NextDouble();
        var netBitSet = new Shared.NetBitSet(randomValue, wordLength);

        // act
        void Action() => netBitSet.ToDoubles();

        // assert
        Assert.Throws<InvalidOperationException>(Action);
    }
}