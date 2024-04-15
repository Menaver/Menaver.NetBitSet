namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodsTests : TestsBase
{
    [Test]
    public void TwoInstancesShouldBeEqual()
    {
        // arrange
        var sutA = CustomSut;
        var sutB = NetBitSetSut;

        // act
        var result = sutA.Equals(sutB);

        // assert
        Assert.That(result, Is.True);
    }

    [TestCase(int.MinValue, int.MaxValue)]
    public void ShouldGetUniqueHashCode(int minExpected, int maxExpected)
    {
        // arrange
        var sut = CustomSut;

        // act
        var result = sut.GetHashCode();

        // assert
        Assert.That(result, Is.InRange(minExpected, maxExpected));
    }

    [TestCase(13, 1)]
    public void ShouldReturnExpectedValueInRequiredPositionByIndexer(int position, int expected)
    {
        // arrange
        var sut = CustomSut;

        // act
        var result = sut[position];

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1)]
    public void ShouldGetExpectedValueByEnumerator(int expected)
    {
        // arrange
        var sut = CustomSut;

        // act
        var enumerator = sut.GetEnumerator();
        enumerator.MoveNext();
        var result = enumerator.Current;

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Hello, World!")]
    public void ShouldConvertInstanceToString(string expected)
    {
        // arrange
        var sut = StringSut;

        // act
        var result = sut.ToString();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, true)]
    public void ShouldCopyInstanceToBoolArray(int position, bool expected)
    {
        // arrange
        var sut = BoolSut;

        // act
        var result = new[] { false };
        sut.CopyTo(result);

        // assert
        Assert.That(result[position], Is.EqualTo(expected));
    }

    [Test]
    public void ShouldCloneInstanceAndBothInstancesShouldBeEqual()
    {
        // arrange
        var sutA = CustomSut;
        Shared.NetBitSet sutB = null;

        // act
        sutB = (Shared.NetBitSet)sutA.Clone();
        var result = sutA.Equals(sutB);

        // assert
        Assert.That(result, Is.True);
    }


    [TestCase(nameof(BoolSut.And), 0, 0, 0)]
    [TestCase(nameof(BoolSut.Or), 0, 0, 1)]
    [TestCase(nameof(BoolSut.Xor), 0, 1, 0)]
    public void ShouldExecuteBitwiseOperation(string methodName, int position, int value, int expected)
    {
        // arrange
        var sut = BoolSut;

        // act
        ExecuteMethodByName(sut, methodName, new object[] { position, value });
        var result = sut[position];

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase(nameof(BoolArraySut.AndAll), 3, 0, 0)]
    [TestCase(nameof(BoolArraySut.OrAll), 2, 0, 1)]
    [TestCase(nameof(BoolArraySut.XorAll), 1, 0, 1)]
    public void ShouldExecuteBitwiseAllOperations(string methodName, int position, int value, int expected)
    {
        // arrange
        var sut = BoolArraySut;

        // act
        ExecuteMethodByName(sut, methodName, new object[] { value });
        var result = sut[position];

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase(0, 0)]
    public void ShouldInvertRequiredBit(int position, int expected)
    {
        // arrange
        var sut = BoolSut;

        // act
        sut.Invert(position);
        var result = sut[position];

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(3, 1)]
    public void ShouldInvertAllBites(int position, int expected)
    {
        // arrange
        var sut = BoolArraySut;

        // act
        sut.InvertAll();
        var result = sut[position];

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [TestCase(55, 55, 47, 0)]
    public void ShouldResizeInstance(int value, int expectedCount, int position, int expectedValue)
    {
        // arrange
        var sut = CustomSut;

        // act
        sut.Resize(value);
        var count = sut.Count;
        var result = sut[position];

        // assert
        Assert.That(count, Is.EqualTo(expectedCount));
        Assert.That(result, Is.EqualTo(expectedValue));
    }
}