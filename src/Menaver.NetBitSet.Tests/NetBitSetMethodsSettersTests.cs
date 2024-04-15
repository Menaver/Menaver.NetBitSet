namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodsSettersTests : TestsBase
{
    [TestCase(nameof(StringSut))]
    public void ShoudThrowExceptionInSetMethod(string sutName)
    {
        // arrange
        var sut = CustomSut;
        var newSut = GetInstanceByName(sutName);

        // act & assert
        Assert.That(() => sut.Set(newSut), Throws.Exception);
    }

    [TestCase(nameof(ByteArraySut), 24, 8, 3, 3)]
    public void ShouldSetNewByteArrayInstanceInsteadOfThis(string sutName, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = ByteSut;
        var newSut = GetInstanceByName(sutName);

        // act
        sut.Set(newSut);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }


    [TestCase("Good times!", 8, 88, 8, 11, 11)]
    public void ShouldSetNewStringInstanceInsteadOfThis(string str, byte newWordLength, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = StringSut;

        // act
        sut.Set(str, newWordLength);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(new[] { 'M', 'E', 'N' }, 8, 24, 8, 3, 3)]
    public void ShouldSetNewCharArrayInstanceInsteadOfThis(char[] array, byte newWordLength, int exCount,
        byte exWordLength, int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = CharArraySut;

        // act
        sut.Set(array, newWordLength);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(12345678910, 464, 0, 0, 58)]
    public void ShouldSetNewObjectInstanceInsteadOfThis(object obj, int exCount, byte exWordLength, int exBlockCount,
        double exBytesCount)
    {
        // arrange
        var sut = ObjectSut;

        // act
        sut.Set(obj);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }


    [TestCase(false, 1, 1, 1, 0.125)]
    public void ShouldSetNewByteArrayInstanceInsteadOfThis(bool value, int exCount, byte exWordLength, int exBlockCount,
        double exBytesCount)
    {
        // arrange
        var sut = BoolSut;

        // act
        sut.Set(value);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(67, 8, 8, 1, 1)]
    public void ShouldSetNewByteInstanceInsteadOfThis(byte value, int exCount, byte exWordLength, int exBlockCount,
        double exBytesCount)
    {
        // arrange
        var sut = ByteSut;

        // act
        sut.Set(value);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(567, 32, 32, 1, 4)]
    public void ShouldSetNewIntInstanceInsteadOfThis(int value, int exCount, byte exWordLength, int exBlockCount,
        double exBytesCount)
    {
        // arrange
        var sut = IntSut;

        // act
        sut.Set(value);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }


    [TestCase(new[] { false, true }, 2, 1, 2, 0.25)]
    public void ShouldSetNewBoolArrayInstanceInsteadOfThis(bool[] array, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = BoolArraySut;

        // act
        sut.Set(array);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(new byte[] { 123, 95 }, 16, 8, 2, 2)]
    public void ShouldSetNewByteArrayInstanceInsteadOfThis(byte[] array, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = ByteArraySut;

        // act
        sut.Set(array);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(new[] { 66, 233 }, 64, 32, 2, 8)]
    public void ShouldSetNewIntArrayInstanceInsteadOfThis(int[] array, int exCount, byte exWordLength, int exBlockCount,
        double exBytesCount)
    {
        // arrange
        var sut = IntArraySut;

        // act
        sut.Set(array);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }


    // should check all combinations (100+), but here are
    // most apparent combinations were released and analyzed
    [TestCase(nameof(EmptySut), nameof(EmptySut), true)]
    [TestCase(nameof(EmptySut), nameof(CustomSut), false)]
    [TestCase(nameof(CustomSut), nameof(NetBitSetSut), true)]
    [TestCase(nameof(CustomSut), nameof(StringSut), false)]
    [TestCase(nameof(NetBitSetSut), nameof(CustomSut), true)]
    [TestCase(nameof(NetBitSetSut), nameof(IntArraySut), false)]
    [TestCase(nameof(StringSut), nameof(CharArraySut), true)]
    [TestCase(nameof(StringSut), nameof(BoolSut), false)]
    [TestCase(nameof(CharArraySut), nameof(ByteArraySut), true)]
    [TestCase(nameof(CharArraySut), nameof(CustomSut), false)]
    [TestCase(nameof(ObjectSut), nameof(ByteArraySut), true)]
    [TestCase(nameof(ObjectSut), nameof(CustomSut), false)]
    [TestCase(nameof(BoolSut), nameof(CustomSut), true)]
    [TestCase(nameof(BoolSut), nameof(CharArraySut), false)]
    [TestCase(nameof(ByteSut), nameof(ObjectSut), true)]
    [TestCase(nameof(ByteSut), nameof(IntArraySut), false)]
    [TestCase(nameof(IntSut), nameof(IntArraySut), true)]
    [TestCase(nameof(IntSut), nameof(ByteArraySut), false)]
    [TestCase(nameof(BoolArraySut), nameof(CustomSut), true)]
    [TestCase(nameof(BoolArraySut), nameof(IntSut), false)]
    [TestCase(nameof(ByteArraySut), nameof(ObjectSut), true)]
    [TestCase(nameof(ByteArraySut), nameof(BoolArraySut), false)]
    [TestCase(nameof(IntArraySut), nameof(IntSut), true)]
    [TestCase(nameof(IntArraySut), nameof(ByteSut), false)]
    public void ShouldTrySetNew_B_InstanceInsteadOf_A_Instance(string sutAName, string sutBName, bool expected)
    {
        // arrange
        var sutA = GetInstanceByName(sutAName);
        var sutB = GetInstanceByName(sutBName);

        // act
        var result = sutA.TrySet(sutB);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase(nameof(StringSut))]
    public void ShoudNotThrowExceptionInForceSetMethod(string sutName)
    {
        // arrange
        var sut = CustomSut;
        var newSut = GetInstanceByName(sutName);

        // act & assert
        Assert.That(() => sut.ForceSet(newSut), Throws.Nothing);
    }

    [TestCase(nameof(ByteArraySut), 24, 8, 3, 3)]
    public void ShouldForceSetNewByteArrayInstanceInsteadOfThis(string sutName, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = ByteSut;
        var newSut = GetInstanceByName(sutName);

        // act
        sut.ForceSet(newSut);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }


    [TestCase("Good times!", 8, 88, 8, 11, 11)]
    public void ShouldForceSetNewStringInstanceInsteadOfThis(string str, byte newWordLength, int exCount,
        byte exWordLength, int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = StringSut;

        // act
        sut.ForceSet(str, newWordLength);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(new[] { 'M', 'E', 'N' }, 8, 24, 8, 3, 3)]
    public void ShouldForceSetNewCharArrayInstanceInsteadOfThis(char[] array, byte newWordLength, int exCount,
        byte exWordLength, int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = CharArraySut;

        // act
        sut.ForceSet(array, newWordLength);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(12345678910, 464, 0, 0, 58)]
    public void ShouldForceSetNewObjectInstanceInsteadOfThis(object obj, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = ObjectSut;

        // act
        sut.ForceSet(obj);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }


    [TestCase(false, 1, 1, 1, 0.125)]
    public void ShouldForceSetNewByteArrayInstanceInsteadOfThis(bool value, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = BoolSut;

        // act
        sut.ForceSet(value);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(67, 8, 8, 1, 1)]
    public void ShouldForceSetNewByteInstanceInsteadOfThis(byte value, int exCount, byte exWordLength, int exBlockCount,
        double exBytesCount)
    {
        // arrange
        var sut = ByteSut;

        // act
        sut.ForceSet(value);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(567, 32, 32, 1, 4)]
    public void ShouldForceSetNewIntInstanceInsteadOfThis(int value, int exCount, byte exWordLength, int exBlockCount,
        double exBytesCount)
    {
        // arrange
        var sut = IntSut;

        // act
        sut.ForceSet(value);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }


    [TestCase(new[] { false, true }, 2, 1, 2, 0.25)]
    public void ShouldForceSetNewBoolArrayInstanceInsteadOfThis(bool[] array, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = BoolArraySut;

        // act
        sut.ForceSet(array);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(new byte[] { 123, 95 }, 16, 8, 2, 2)]
    public void ShouldForceSetNewByteArrayInstanceInsteadOfThis(byte[] array, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = ByteArraySut;

        // act
        sut.ForceSet(array);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }

    [TestCase(new[] { 66, 233 }, 64, 32, 2, 8)]
    public void ShouldForceSetNewIntArrayInstanceInsteadOfThis(int[] array, int exCount, byte exWordLength,
        int exBlockCount, double exBytesCount)
    {
        // arrange
        var sut = IntArraySut;

        // act
        sut.ForceSet(array);
        var count = sut.Count;
        var wordLength = sut.WordLength;
        var blockCount = sut.BlocksCount;
        var bytesCount = sut.BytesCount;

        // assert
        Assert.That(count, Is.EqualTo(exCount));
        Assert.That(wordLength, Is.EqualTo(exWordLength));
        Assert.That(blockCount, Is.EqualTo(exBlockCount));
        Assert.That(bytesCount, Is.EqualTo(exBytesCount));
    }


    [TestCase(23, 1)]
    public void ShouldSetAllBitesToTrue(int expectedPosition, int expectedValue)
    {
        // arrange
        var sut = CustomSut;

        // act
        sut.SetAll();
        var result = sut[expectedPosition];

        // assert
        Assert.That(result, Is.EqualTo(expectedValue));
    }

    [TestCase(23, 0)]
    public void ShouldResetAllBitesToFalse(int expectedPosition, int expectedValue)
    {
        // arrange
        var sut = CustomSut;

        // act
        sut.ResetAll();
        var result = sut[expectedPosition];

        // assert
        Assert.That(result, Is.EqualTo(expectedValue));
    }
}