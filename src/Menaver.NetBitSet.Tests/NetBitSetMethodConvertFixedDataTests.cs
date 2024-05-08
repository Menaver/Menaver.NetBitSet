using System.Text;
using Menaver.NetBitSet.Shared;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodConvertFixedDataTests
{
    [TestCase((ulong)1, Bit.True)]
    [TestCase((ulong)1, Bit.False)]
    public void Count_FixedLength_DefaultValue_RevertedValueEquals(
        ulong count,
        Bit defaultValue)
    {
        // arrange
        var netBitSet = new Shared.NetBitSet(count, defaultValue);

        // act
        var setupComplies = netBitSet.All(x => x == defaultValue);

        // assert
        Assert.That(setupComplies);
    }

    [TestCase((ulong)1, Bit.True, WordLength.One)]
    [TestCase((ulong)1, Bit.False, WordLength.One)]
    [TestCase(ulong.MinValue, Bit.True, WordLength.NotFixed)]
    [TestCase((ulong)short.MaxValue, Bit.False, WordLength.SixtyFour)]
    public void Count_FixedLength_DefaultValue_WordLength_RevertedValueEquals(
        ulong count,
        Bit defaultValue,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(count, defaultValue, wordLength);

        // act
        var setupComplies = netBitSet.All(x => x == defaultValue);

        // assert
        Assert.That(setupComplies);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void Bool_SpecificValue_RevertedValueEquals(
        bool value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToBools().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase(true, WordLength.Sixteen)]
    [TestCase(false, WordLength.ThirtyTwo)]
    public void Bool_SpecificValue_WordLength_RevertedValueEquals(
        bool value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act
        var revertedValue = netBitSet.ToBools().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase(0)]
    [TestCase(sbyte.MinValue)]
    [TestCase(sbyte.MaxValue)]
    public void SByte_SpecificValue_RevertedValueEquals(
        sbyte value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase(0)]
    [TestCase(byte.MinValue)]
    [TestCase(byte.MaxValue)]
    public void Byte_SpecificValue_RevertedValueEquals(
        byte value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase(0)]
    [TestCase(short.MinValue)]
    [TestCase(short.MaxValue)]
    public void Short_SpecificValue_RevertedValueEquals(
        short value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToShorts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase((ushort)0)]
    [TestCase(ushort.MinValue)]
    [TestCase(ushort.MaxValue)]
    public void UShort_SpecificValue_RevertedValueEquals(
        ushort value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToUShorts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase(0)]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void Int_SpecificValue_RevertedValueEquals(
        int value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToInts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase((uint)0)]
    [TestCase(uint.MinValue)]
    [TestCase(uint.MaxValue)]
    public void UInt_SpecificValue_RevertedValueEquals(
        uint value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToUInts().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase((long)0)]
    [TestCase(long.MinValue)]
    [TestCase(long.MaxValue)]
    public void Long_SpecificValue_RevertedValueEquals(
        long value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToLongs().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase((ulong)0)]
    [TestCase(ulong.MinValue)]
    [TestCase(ulong.MaxValue)]
    public void ULong_SpecificValue_RevertedValueEquals(
        ulong value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToULongs().FirstOrDefault();

        // assert
        Assert.That(revertedValue == value);
    }


    [TestCase((double)0)]
    [TestCase(double.MinValue)]
    [TestCase(double.MaxValue)]
    public void Double_SpecificValue_RevertedValueEquals(
        double value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToDoubles().FirstOrDefault();

        // assert
        Assert.That(revertedValue - value < 0.00000001);
    }

    [TestCase("Hello, World!")]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
    [TestCase("⒠⒡⒠⒲⒡乇ｷ乇wｷቿቻቿሠቻ")]
    public void String_FixedNormalString_RevertedValueEquals(
        string value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToString();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase("Hello, World!", "us-ascii", WordLength.Sixteen)]
    [TestCase("Hello, World!", "utf-8", WordLength.NotFixed)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "us-ascii", WordLength.Sixteen)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "utf-8", WordLength.NotFixed)]
    [TestCase("⒠⒡⒠⒲⒡乇ｷ乇wｷቿቻቿሠቻ", "utf-8", WordLength.NotFixed)]
    public void String_NormalString_Encoding_RevertedValueEquals(
        string value,
        string encodingName,
        WordLength expectedWordLength)
    {
        // arrange 
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(value, encoding);

        // act
        var revertedValue = netBitSet.ToString(encoding);

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase("Hello, World!", "us-ascii", WordLength.Sixteen)]
    [TestCase("Hello, World!", "utf-8", WordLength.NotFixed)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "us-ascii", WordLength.Sixteen)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "utf-8", WordLength.NotFixed)]
    [TestCase("⒠⒡⒠⒲⒡乇ｷ乇wｷቿቻቿሠቻ", "utf-8", WordLength.NotFixed)]
    public void String_NormalString_Encoding_WordLength_RevertedValueEquals(
        string value,
        string encodingName,
        WordLength wordLength)
    {
        // arrange 
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(value, encoding, wordLength);

        // act
        var revertedValue = netBitSet.ToString(encoding);

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase("01001001100101100000001011010010")]
    [TestCase("00111010110111100110100010110001")]
    [TestCase("11111111111101001001111010010110")]
    public void String_BinaryString_RevertedValueEquals(
        string value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToBinaryString();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase("01001001100101100000001011010010", WordLength.ThirtyTwo)]
    [TestCase("11111111111101001001111010010110", WordLength.Eight)]
    public void String_BinaryString_WordLength_RevertedValueEquals(
        string value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act
        var revertedValue = netBitSet.ToBinaryString();

        // assert
        Assert.That(revertedValue == value);
    }

    [TestCase("01001001100101100000001011010010", WordLength.ThirtyTwo, 1234567890)]
    [TestCase("00111010110111100110100010110001", WordLength.ThirtyTwo, 987654321)]
    [TestCase("11111111111101001001111010010110", WordLength.ThirtyTwo, -745834)]
    public void String_BinaryString_WordLength_ExpectedNumber_ExtractedNumberEquals(
        string value,
        WordLength wordLength,
        int expectedNumber)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act
        var extractedNumber = netBitSet.ToInts().FirstOrDefault();

        // assert
        Assert.That(extractedNumber == expectedNumber);
    }

    [Test]
    public void Object_DateTimeOffsetUtcNow_RevertedValueEquals()
    {
        // arrange 
        var dateTime = DateTimeOffset.UtcNow;
        var netBitSet = new Shared.NetBitSet(dateTime);

        // act
        var revertedValue = netBitSet.ToObject<DateTimeOffset>();

        // assert
        Assert.That(revertedValue == dateTime);
    }

    [TestCase("us-ascii")]
    [TestCase("utf-8")]
    public void Object_DateTimeOffsetUtcNow_Encoding_RevertedValueEquals(
        string encodingName)
    {
        // arrange 
        var dateTime = DateTimeOffset.UtcNow;
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(dateTime, encoding);

        // act
        var revertedValue = netBitSet.ToObject<DateTimeOffset>();

        // assert
        Assert.That(revertedValue == dateTime);
    }

    [TestCase("us-ascii", WordLength.Sixteen)]
    [TestCase("utf-8", WordLength.NotFixed)]
    public void Object_DateTimeOffsetUtcNow_Encoding_WordLength_RevertedValueEquals(
        string encodingName,
        WordLength wordLength)
    {
        // arrange 
        var dateTime = DateTimeOffset.UtcNow;
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(dateTime, encoding, wordLength);

        // act
        var revertedValue = netBitSet.ToObject<DateTimeOffset>();

        // assert
        Assert.That(revertedValue == dateTime);
    }
}