using System.Text;
using Menaver.NetBitSet.Shared;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetCtorFixedDataTests
{
    [TestCase((ulong)1, Bit.True)]
    [TestCase((ulong)1, Bit.False)]
    [TestCase(ulong.MinValue, Bit.True)]
    [TestCase((ulong)short.MaxValue, Bit.False)]
    public void Count_FixedLength_DefaultValue_SetupComplies(
        ulong count,
        Bit defaultValue)
    {
        // arrange
        var netBitSet = new Shared.NetBitSet(count, defaultValue);

        // act

        // assert
        Assert.That(netBitSet.Count == count);
        Assert.That(netBitSet.WordLength == WordLength.One);
    }

    [TestCase((ulong)1, Bit.True, WordLength.One)]
    [TestCase((ulong)1, Bit.False, WordLength.One)]
    [TestCase(ulong.MinValue, Bit.True, WordLength.NotFixed)]
    [TestCase((ulong)short.MaxValue, Bit.False, WordLength.SixtyFour)]
    public void Count_FixedLength_DefaultValue_WordLength_SetupComplies(
        ulong count,
        Bit defaultValue,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(count, defaultValue, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == count);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void Bool_SpecificValue_SetupComplies(
        bool value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 1);
        Assert.That(netBitSet.WordLength == WordLength.One);
    }

    [TestCase(true, WordLength.Sixteen)]
    [TestCase(false, WordLength.ThirtyTwo)]
    public void Bool_SpecificValue_WordLength_SetupComplies(
        bool value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 1);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(0)]
    [TestCase(sbyte.MinValue)]
    [TestCase(sbyte.MaxValue)]
    public void SByte_SpecificValue_SetupComplies(
        sbyte value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(netBitSet.WordLength == WordLength.Eight);
    }

    [TestCase(0, WordLength.Sixteen)]
    [TestCase(0, WordLength.ThirtyTwo)]
    public void SByte_SpecificValue_WordLength_SetupComplies(
        sbyte value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(0)]
    [TestCase(byte.MinValue)]
    [TestCase(byte.MaxValue)]
    public void Byte_SpecificValue_SetupComplies(
        byte value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(netBitSet.WordLength == WordLength.Eight);
    }

    [TestCase(0, WordLength.Sixteen)]
    [TestCase(0, WordLength.ThirtyTwo)]
    public void Byte_SpecificValue_WordLength_SetupComplies(
        byte value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(0)]
    [TestCase(short.MinValue)]
    [TestCase(short.MaxValue)]
    public void Short_SpecificValue_SetupComplies(
        short value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(netBitSet.WordLength == WordLength.Sixteen);
    }

    [TestCase(0, WordLength.Sixteen)]
    [TestCase(0, WordLength.ThirtyTwo)]
    public void Short_SpecificValue_WordLength_SetupComplies(
        short value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase((ushort)0)]
    [TestCase(ushort.MinValue)]
    [TestCase(ushort.MaxValue)]
    public void UShort_SpecificValue_SetupComplies(
        ushort value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(netBitSet.WordLength == WordLength.Sixteen);
    }

    [TestCase((ushort)0, WordLength.Sixteen)]
    [TestCase((ushort)0, WordLength.ThirtyTwo)]
    public void UShort_SpecificValue_WordLength_SetupComplies(
        ushort value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(0)]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void Int_SpecificValue_SetupComplies(
        int value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(netBitSet.WordLength == WordLength.ThirtyTwo);
    }

    [TestCase(0, WordLength.Sixteen)]
    [TestCase(0, WordLength.ThirtyTwo)]
    public void Int_SpecificValue_WordLength_SetupComplies(
        int value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase((uint)0)]
    [TestCase(uint.MinValue)]
    [TestCase(uint.MaxValue)]
    public void UInt_SpecificValue_SetupComplies(
        uint value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(netBitSet.WordLength == WordLength.ThirtyTwo);
    }

    [TestCase((uint)0, WordLength.Sixteen)]
    [TestCase((uint)0, WordLength.ThirtyTwo)]
    public void UInt_SpecificValue_WordLength_SetupComplies(
        uint value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(netBitSet.WordLength == wordLength);
    }


    [TestCase((long)0)]
    [TestCase(long.MinValue)]
    [TestCase(long.MaxValue)]
    public void Long_SpecificValue_SetupComplies(
        long value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase((long)0, WordLength.Sixteen)]
    [TestCase((long)0, WordLength.ThirtyTwo)]
    public void Long_SpecificValue_WordLength_SetupComplies(
        long value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase((ulong)0)]
    [TestCase(ulong.MinValue)]
    [TestCase(ulong.MaxValue)]
    public void ULong_SpecificValue_SetupComplies(
        ulong value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase((ulong)0, WordLength.Sixteen)]
    [TestCase((ulong)0, WordLength.ThirtyTwo)]
    public void ULong_SpecificValue_WordLength_SetupComplies(
        ulong value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == wordLength);
    }


    [TestCase((double)0)]
    [TestCase(double.MinValue)]
    [TestCase(double.MaxValue)]
    public void Double_SpecificValue_SetupComplies(
        double value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase((double)0, WordLength.Sixteen)]
    [TestCase((double)0, WordLength.ThirtyTwo)]
    public void Double_SpecificValue_WordLength_SetupComplies(
        double value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase("Hello, World!")]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
    [TestCase("⒠⒡⒠⒲⒡乇ｷ乇wｷቿቻቿሠቻ")]
    public void String_FixedNormalString_SetupComplies(
        string value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.WordLength == WordLength.NotFixed);
    }

    [TestCase("Hello, World!", "us-ascii", WordLength.Eight)]
    [TestCase("Hello, World!", "utf-8", WordLength.NotFixed)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "us-ascii", WordLength.Eight)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "utf-8", WordLength.NotFixed)]
    [TestCase("⒠⒡⒠⒲⒡乇ｷ乇wｷቿቻቿሠቻ", "utf-8", WordLength.NotFixed)]
    public void String_NormalString_Encoding_SetupComplies(
        string value,
        string encodingName,
        WordLength expectedWordLength)
    {
        // arrange 
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(value, encoding);

        // act

        // assert
        Assert.That(netBitSet.WordLength == expectedWordLength);
    }

    [TestCase("Hello, World!", "us-ascii", WordLength.Sixteen)]
    [TestCase("Hello, World!", "utf-8", WordLength.NotFixed)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "us-ascii", WordLength.Sixteen)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "utf-8", WordLength.NotFixed)]
    [TestCase("⒠⒡⒠⒲⒡乇ｷ乇wｷቿቻቿሠቻ", "utf-8", WordLength.NotFixed)]
    public void String_NormalString_Encoding_WordLength_SetupComplies(
        string value,
        string encodingName,
        WordLength wordLength)
    {
        // arrange 
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(value, encoding, wordLength);

        // act

        // assert
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase("01001001100101100000001011010010")]
    [TestCase("00111010110111100110100010110001")]
    [TestCase("11111111111101001001111010010110")]
    public void String_BinaryString_SetupComplies(
        string value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act

        // assert
        Assert.That(netBitSet.WordLength == WordLength.One);
    }

    [TestCase("01001001100101100000001011010010", WordLength.ThirtyTwo, 1234567890)]
    [TestCase("00111010110111100110100010110001", WordLength.ThirtyTwo, 987654321)]
    [TestCase("11111111111101001001111010010110", WordLength.ThirtyTwo, -745834)]
    public void String_BinaryString_WordLength_ExpectedNumber_SetupComplies(
        string value,
        WordLength wordLength,
        int number)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act

        // assert
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Object_DateTimeOffsetUtcNow_SetupComplies()
    {
        // arrange 
        var dateTime = DateTimeOffset.UtcNow;
        var netBitSet = new Shared.NetBitSet(dateTime);

        // act

        // assert
        Assert.That(netBitSet.WordLength == WordLength.NotFixed);
    }

    [TestCase("us-ascii", WordLength.Eight)]
    [TestCase("utf-8", WordLength.NotFixed)]
    public void Object_DateTimeOffsetUtcNow_Encoding_SetupComplies(
        string encodingName,
        WordLength expectedWordLength)
    {
        // arrange 
        var dateTime = DateTimeOffset.UtcNow;
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(dateTime, encoding);

        // act

        // assert
        Assert.That(netBitSet.WordLength == expectedWordLength);
    }

    [TestCase("us-ascii", WordLength.Sixteen)]
    [TestCase("utf-8", WordLength.NotFixed)]
    public void Object_DateTimeOffsetUtcNow_Encoding_WordLength_SetupComplies(
        string encodingName,
        WordLength wordLength)
    {
        // arrange 
        var dateTime = DateTimeOffset.UtcNow;
        var encoding = Encoding.GetEncoding(encodingName);
        var netBitSet = new Shared.NetBitSet(dateTime, encoding, wordLength);

        // act

        // assert
        Assert.That(netBitSet.WordLength == wordLength);
    }
}