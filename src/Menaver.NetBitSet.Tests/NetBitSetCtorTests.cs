using System.Text;
using Menaver.NetBitSet.Shared;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetCtorTests
{
    [TestCase((ulong)1, Bit.True)]
    [TestCase((ulong)1, Bit.False)]
    [TestCase(ulong.MinValue, Bit.True)]
    [TestCase((ulong)short.MaxValue, Bit.False)]
    public void Count_DefaultValue_SetupComplies(
        ulong count,
        Bit defaultValue)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(count, defaultValue);

        // act
        var compliesWithDefaultValue = netBitSet.All(bit => bit == defaultValue);

        // assert
        Assert.That(netBitSet.Count == count);
        Assert.That(compliesWithDefaultValue);
        Assert.That(netBitSet.WordLength == WordLength.One);
    }

    [TestCase((ulong)1, Bit.True, WordLength.One)]
    [TestCase((ulong)1, Bit.False, WordLength.One)]
    [TestCase((ulong)8, Bit.True, WordLength.Eight)]
    [TestCase(ulong.MinValue, Bit.True, WordLength.NotFixed)]
    [TestCase((ulong)short.MaxValue, Bit.False, WordLength.SixtyFour)]
    public void Count_DefaultValue_WordLength_SetupComplies(
        ulong count,
        Bit defaultValue,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(count, defaultValue, wordLength);

        // act
        var compliesWithDefaultValue = netBitSet.All(bit => bit == defaultValue);

        // assert
        Assert.That(netBitSet.Count == count);
        Assert.That(compliesWithDefaultValue);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void Bool_Value_SetupComplies(
        bool value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToBools().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 1);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.One);
    }

    [TestCase(true, WordLength.Sixteen)]
    [TestCase(false, WordLength.ThirtyTwo)]
    public void Bool_Value_WordLength_SetupComplies(
        bool value,
        WordLength wordLength)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value, wordLength);

        // act
        var revertedValue = netBitSet.ToBools().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 1);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [TestCase(45)]
    [TestCase(-79)]
    [TestCase(0)]
    [TestCase(sbyte.MinValue)]
    [TestCase(sbyte.MaxValue)]
    public void SByte_Value_SetupComplies(
        sbyte value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToSBytes().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.Eight);
    }

    [TestCase(3, WordLength.Sixteen)]
    [TestCase(55, WordLength.ThirtyTwo)]
    public void SByte_Value_WordLength_SetupComplies(
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

    [TestCase(45)]
    [TestCase(111)]
    [TestCase(0)]
    [TestCase(byte.MinValue)]
    [TestCase(byte.MaxValue)]
    public void Byte_Value_SetupComplies(
        byte value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToBytes().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 8);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.Eight);
    }

    [TestCase(38, WordLength.Sixteen)]
    [TestCase(34, WordLength.ThirtyTwo)]
    public void Byte_Value_WordLength_SetupComplies(
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

    [TestCase(32)]
    [TestCase(-112)]
    [TestCase(0)]
    [TestCase(short.MinValue)]
    [TestCase(short.MaxValue)]
    public void Short_Value_SetupComplies(
        short value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToShorts().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.Sixteen);
    }

    [TestCase(38, WordLength.Sixteen)]
    [TestCase(34, WordLength.ThirtyTwo)]
    public void Short_Value_WordLength_SetupComplies(
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

    [TestCase((ushort)3233)]
    [TestCase((ushort)45627)]
    [TestCase((ushort)0)]
    [TestCase(ushort.MinValue)]
    [TestCase(ushort.MaxValue)]
    public void UShort_Value_SetupComplies(
        ushort value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToUShorts().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 16);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.Sixteen);
    }

    [TestCase((ushort)3813, WordLength.Sixteen)]
    [TestCase((ushort)343, WordLength.ThirtyTwo)]
    public void UShort_Value_WordLength_SetupComplies(
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

    [TestCase(3233111)]
    [TestCase(-4562723)]
    [TestCase(0)]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void Int_Value_SetupComplies(
        int value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToInts().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.ThirtyTwo);
    }

    [TestCase(3813, WordLength.Sixteen)]
    [TestCase(343, WordLength.ThirtyTwo)]
    public void Int_Value_WordLength_SetupComplies(
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

    [TestCase((uint)323311)]
    [TestCase((uint)456273)]
    [TestCase((uint)0)]
    [TestCase(uint.MinValue)]
    [TestCase(uint.MaxValue)]
    public void UInt_Value_SetupComplies(
        uint value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToUInts().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 32);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.ThirtyTwo);
    }

    [TestCase((uint)3813, WordLength.Sixteen)]
    [TestCase((uint)343, WordLength.ThirtyTwo)]
    public void UInt_Value_WordLength_SetupComplies(
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

    [TestCase((long)3233110)]
    [TestCase((long)-45627312)]
    [TestCase((long)0)]
    [TestCase(long.MinValue)]
    [TestCase(long.MaxValue)]
    public void Long_Value_SetupComplies(
        long value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToLongs().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase((long)38131, WordLength.Sixteen)]
    [TestCase((long)-3434548, WordLength.ThirtyTwo)]
    public void Long_Value_WordLength_SetupComplies(
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

    [TestCase((ulong)323311011)]
    [TestCase((ulong)456273121)]
    [TestCase((ulong)0)]
    [TestCase(ulong.MinValue)]
    [TestCase(ulong.MaxValue)]
    public void ULong_Value_SetupComplies(
        ulong value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToULongs().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(revertedValue == value);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase((ulong)3813133, WordLength.Sixteen)]
    [TestCase((ulong)34345481, WordLength.ThirtyTwo)]
    public void ULong_Value_WordLength_SetupComplies(
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

    [TestCase((double)323311011)]
    [TestCase((double)-456273121)]
    [TestCase(-0.00000003)]
    [TestCase(-45.34243)]
    [TestCase((double)0)]
    [TestCase(double.MinValue)]
    [TestCase(double.MaxValue)]
    public void Double_Value_SetupComplies(
        double value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToDoubles().FirstOrDefault();

        // assert
        Assert.That(netBitSet.Count == 64);
        Assert.That(revertedValue - value < 0.000000001);
        Assert.That(netBitSet.WordLength == WordLength.SixtyFour);
    }

    [TestCase((double)3813133, WordLength.Sixteen)]
    [TestCase((double)34345481, WordLength.ThirtyTwo)]
    public void Double_Value_WordLength_SetupComplies(
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
    public void String_NormalString_SetupComplies(
        string value)
    {
        // arrange 
        var netBitSet = new Shared.NetBitSet(value);

        // act
        var revertedValue = netBitSet.ToString();

        // assert
        Assert.That(revertedValue.Equals(value));
        Assert.That(netBitSet.WordLength == WordLength.NotFixed);
    }

    [TestCase("Hello, World!", "us-ascii", WordLength.Sixteen)]
    [TestCase("Hello, World!", "utf-8", WordLength.NotFixed)]
    [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit", "us-ascii", WordLength.Sixteen)]
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
        var revertedValue = netBitSet.ToString();

        // assert
        Assert.That(revertedValue.Equals(value));
        Assert.That(netBitSet.WordLength == expectedWordLength);
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
        var revertedValue = netBitSet.ToBinaryString();

        // assert
        Assert.That(revertedValue.Equals(value));
        Assert.That(netBitSet.WordLength == WordLength.NotFixed);
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
        var revertedValue = netBitSet.ToBinaryString();
        var extractedNumber = netBitSet.ToInts().FirstOrDefault();

        // assert
        Assert.That(revertedValue.Equals(value));
        Assert.That(extractedNumber == number);
        Assert.That(netBitSet.WordLength == wordLength);
    }

    [Test]
    public void Object_DateTimeOffsetUtcNow_SetupComplies()
    {
        // arrange 
        var dateTime = DateTimeOffset.UtcNow;
        var netBitSet = new Shared.NetBitSet(dateTime);

        // act
        var revertedObj = netBitSet.ToObject<DateTimeOffset>();

        // assert
        Assert.That(netBitSet.WordLength == WordLength.NotFixed);
        Assert.That(dateTime == revertedObj);
    }

    [TestCase("us-ascii", WordLength.Sixteen)]
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
        var revertedObj = netBitSet.ToObject<DateTimeOffset>(encoding);

        // assert
        Assert.That(netBitSet.WordLength == expectedWordLength);
        Assert.That(dateTime == revertedObj);
    }
}