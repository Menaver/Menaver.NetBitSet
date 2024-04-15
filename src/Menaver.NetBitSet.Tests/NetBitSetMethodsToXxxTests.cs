using Menaver.NetBitSet.Shared.Interfaces;

namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodsToXxxTests : TestsBase
{
    [TestCase(nameof(StringSut),
        "01001000 01100101 01101100 01101100 01101111 00101100 00100000 01010111 01101111 01110010 01101100 01100100 00100001")]
    public void ShoudConvertToBinaryString(string sutName, string expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToBinaryString(" ", Endian.Big);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(nameof(CharArraySut), new[] { 'H', 'i', ' ', 't', 'h', 'e', 'r', 'e', '!' })]
    public void ShoudConvertToCharArray(string sutName, char[] expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToCharArray(Endian.Big);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(nameof(CharBinaryArraySut), new[] { '1', '0', '0', '1', '0', '0', '1', '1', '0', '0', '1', '0' })]
    public void ShoudConvertToBinaryCharArray(string sutName, char[] expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToBinaryCharArray();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(nameof(ObjectSut))]
    public void ShoudConvertToObject(string sutName)
    {
        // arrange
        var sut = GetInstanceByName(sutName);
        object expected = new DateTime(2016, 7, 25);

        // act
        var result = sut.ToObject();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase(nameof(BoolSut), true)]
    public void ShoudConvertToBool(string sutName, bool expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToBool();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(nameof(ByteSut), 57)]
    public void ShoudConvertToByte(string sutName, byte expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToByte();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(nameof(IntSut), 223)]
    public void ShoudConvertToInt(string sutName, int expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToInt();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase(nameof(BoolArraySut), new[] { false, true, true, false })]
    public void ShoudConvertToBoolArray(string sutName, bool[] expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToBoolArray();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(nameof(ByteArraySut), new byte[] { 83, 92, 13 })]
    public void ShoudConvertToByteArray(string sutName, byte[] expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToByteArray();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(nameof(IntArraySut), new[] { 873, 666, 12345 })]
    public void ShoudConvertToIntArray(string sutName, int[] expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToIntArray();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase(nameof(StringBinarySut), 179)]
    public void ShoudConvertToNumericAsByte(string sutName, byte expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToNumericAsByte();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(nameof(CharBinaryArraySut), 2354)]
    public void ShoudConvertToNumericAsInt(string sutName, int expected)
    {
        // arrange
        var sut = GetInstanceByName(sutName);

        // act
        var result = sut.ToNumericAsInt();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }
}