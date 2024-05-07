//namespace Menaver.NetBitSet.Tests;

//[TestFixture]
//public class NetBitSetOperatorsTests : TestsBase
//{
//    [TestCase(nameof(StringSut), nameof(IntSut), 136, 8)]
//    public void ShouldExecute_Add_WithTwoNetBitSetInstances(string sutAName, string sutBName, int expectedCount,
//        int expectedWordLength)
//    {
//        // arrange
//        var sutA = GetInstanceByName(sutAName);
//        var sutB = GetInstanceByName(sutBName);

//        // act
//        var result = sutA + sutB;
//        sutA += sutB;

//        // asserts
//        Assert.That(result.Count, Is.EqualTo(expectedCount));
//        Assert.That(result.WordLength, Is.EqualTo(expectedWordLength));
//        Assert.That(sutA.Count, Is.EqualTo(expectedCount));
//        Assert.That(sutA.WordLength, Is.EqualTo(expectedWordLength));
//    }


//    [TestCase(nameof(CustomSut), nameof(NetBitSetSut), true)]
//    [TestCase(nameof(CustomSut), nameof(ByteArraySut), false)]
//    public void ShouldExecute_Equal_WithTwoNetBitSetInstances(string sutAName, string sutBName, bool expected)
//    {
//        // arrange
//        var sutA = GetInstanceByName(sutAName);
//        var sutB = GetInstanceByName(sutBName);

//        // act
//        var result = sutA == sutB;

//        // asserts
//        Assert.That(result, Is.EqualTo(expected));
//    }

//    [TestCase(nameof(CustomSut), nameof(NetBitSetSut), false)]
//    [TestCase(nameof(CustomSut), nameof(ByteArraySut), true)]
//    public void ShouldExecute_NotEqual_WithTwoNetBitSetInstances(string sutAName, string sutBName, bool expected)
//    {
//        // arrange
//        var sutA = GetInstanceByName(sutAName);
//        var sutB = GetInstanceByName(sutBName);

//        // act
//        var result = sutA != sutB;

//        // asserts
//        Assert.That(result, Is.EqualTo(expected));
//    }


//    [TestCase(nameof(StringSut), 3, 4, 0)]
//    public void ShouldExecute_LeftShift_WithSpecificPosition(string sutName, int position, int expectedPosition,
//        int expectedValue)
//    {
//        // arrange
//        var sut = GetInstanceByName(sutName);

//        // act
//        var result = sut << position;
//        sut <<= position;

//        // asserts
//        Assert.That(result[expectedPosition], Is.EqualTo(expectedValue));
//        Assert.That(sut[expectedPosition], Is.EqualTo(expectedValue));
//    }

//    [TestCase(nameof(StringSut), 3, 10, 0)]
//    public void ShouldExecute_RightShift_WithSpecificPosition(string sutName, int position, int expectedPosition,
//        int expectedValue)
//    {
//        // arrange
//        var sut = GetInstanceByName(sutName);

//        // act
//        var result = sut >> position;
//        sut >>= position;

//        // asserts
//        Assert.That(result[expectedPosition], Is.EqualTo(expectedValue));
//        Assert.That(sut[expectedPosition], Is.EqualTo(expectedValue));
//    }


//    [TestCase(nameof(CustomSut), nameof(StringSut), 7, 0)]
//    public void ShouldExecute_And_WithTwoNetBitSetInstances(string sutAName, string sutBName, int expectedPosition,
//        int expectedValue)
//    {
//        // arrange
//        var sutA = GetInstanceByName(sutAName);
//        var sutB = GetInstanceByName(sutBName);

//        // act
//        var result = sutA & sutB;
//        sutA &= sutB;

//        // asserts
//        Assert.That(result[expectedPosition], Is.EqualTo(expectedValue));
//        Assert.That(sutA[expectedPosition], Is.EqualTo(expectedValue));
//    }

//    [TestCase(nameof(CustomSut), nameof(StringSut), 7, 1)]
//    public void ShouldExecute_Or_WithTwoNetBitSetInstances(string sutAName, string sutBName, int expectedPosition,
//        int expectedValue)
//    {
//        // arrange
//        var sutA = GetInstanceByName(sutAName);
//        var sutB = GetInstanceByName(sutBName);

//        // act
//        var result = sutA | sutB;
//        sutA |= sutB;

//        // asserts
//        Assert.That(result[expectedPosition], Is.EqualTo(expectedValue));
//        Assert.That(sutA[expectedPosition], Is.EqualTo(expectedValue));
//    }

//    [TestCase(nameof(CustomSut), nameof(StringSut), 7, 1)]
//    public void ShouldExecute_Xor_WithTwoNetBitSetInstances(string sutAName, string sutBName, int expectedPosition,
//        int expectedValue)
//    {
//        // arrange
//        var sutA = GetInstanceByName(sutAName);
//        var sutB = GetInstanceByName(sutBName);

//        // act
//        var result = sutA ^ sutB;
//        sutA ^= sutB;

//        // asserts
//        Assert.That(result[expectedPosition], Is.EqualTo(expectedValue));
//        Assert.That(sutA[expectedPosition], Is.EqualTo(expectedValue));
//    }

//    [TestCase(nameof(CustomSut), 7, 0)]
//    public void ShouldExecute_Not(string sutName, int expectedPosition, int expectedValue)
//    {
//        // arrange
//        var sut = GetInstanceByName(sutName);

//        // act
//        var result = ~sut;

//        // asserts
//        Assert.That(result[expectedPosition], Is.EqualTo(expectedValue));
//    }

//    [TestCase(nameof(StringBinarySut), 5, 0)]
//    [TestCase(nameof(StringBinarySut), 6, 1)]
//    [TestCase(nameof(StringBinarySut), 7, 0)]
//    public void ShouldExecute_Invert(string sutName, int expectedPosition, int expectedValue)
//    {
//        // arrange
//        var sut = GetInstanceByName(sutName);

//        // act
//        var result = !sut;

//        // asserts
//        Assert.That(result[expectedPosition], Is.EqualTo(expectedValue));
//    }

//    [TestCase(nameof(CharBinaryArraySut), nameof(StringBinarySut), true)]
//    [TestCase(nameof(StringBinarySut), nameof(CharBinaryArraySut), false)]
//    [TestCase(nameof(ByteSut), nameof(IntSut), true)]
//    public void ShouldExecute_Less_WithTwoNetBitSetInstances(string sutAName, string sutBName, bool expectedValue)
//    {
//        // arrange
//        var sutA = GetInstanceByName(sutAName);
//        var sutB = GetInstanceByName(sutBName);

//        // act
//        var result = sutA < sutB;

//        // asserts
//        Assert.That(result, Is.EqualTo(expectedValue));
//    }

//    [TestCase(nameof(CharBinaryArraySut), nameof(StringBinarySut), false)]
//    [TestCase(nameof(StringBinarySut), nameof(CharBinaryArraySut), true)]
//    [TestCase(nameof(ByteSut), nameof(IntSut), false)]
//    public void ShouldExecute_Bigger_WithTwoNetBitSetInstances(string sutNameA, string sutNameB, bool expectedValue)
//    {
//        // arrange
//        var sutA = GetInstanceByName(sutNameA);
//        var sutB = GetInstanceByName(sutNameB);

//        // act
//        var result = sutA > sutB;

//        // asserts
//        Assert.That(result, Is.EqualTo(expectedValue));
//    }
//}