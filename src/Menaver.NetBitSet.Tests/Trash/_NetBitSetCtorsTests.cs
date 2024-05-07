//namespace Menaver.NetBitSet.Tests;

//[TestFixture]
//public class NetBitSetCtorsTests : TestsBase
//{
//    // all instances are created in TestBase.SetUp()
//    [TestCase(nameof(CustomSut), 33, 1, 33, 4.125)]
//    [TestCase(nameof(NetBitSetSut), 33, 1, 33, 4.125)]
//    [TestCase(nameof(StringSut), 104, 8, 13, 13)]
//    [TestCase(nameof(StringBinarySut), 16, 8, 2, 2)]
//    [TestCase(nameof(CharArraySut), 72, 8, 9, 9)]
//    [TestCase(nameof(CharBinaryArraySut), 12, 1, 12, 1.5)]
//    [TestCase(nameof(ObjectSut), 624, 8, 78, 78)]
//    [TestCase(nameof(BoolSut), 1, 1, 1, 0.125)]
//    [TestCase(nameof(ByteSut), 8, 8, 1, 1)]
//    [TestCase(nameof(IntSut), 32, 32, 1, 4)]
//    [TestCase(nameof(BoolArraySut), 4, 1, 4, 0.5)]
//    [TestCase(nameof(ByteArraySut), 24, 8, 3, 3)]
//    [TestCase(nameof(IntArraySut), 96, 32, 3, 12)]
//    public void AllPropertiesShoulBeEqualToExpectedValues(string sutName, int expectedCount, byte expectedWordLength,
//        int expectedBlockCount, double expectedBytesCount)
//    {
//        // arrange: assign instance by name
//        var sut = GetInstanceByName(sutName);

//        // act: get its props
//        var count = sut.Count;
//        var wordLength = sut.WordLength;
//        var blockCount = sut.WordCount;
//        var bytesCount = sut.ByteCount;

//        // assert: compare props values with expected
//        Assert.That(count, Is.EqualTo(expectedCount));
//        Assert.That(wordLength, Is.EqualTo(expectedWordLength));
//        Assert.That(blockCount, Is.EqualTo(expectedBlockCount));
//        Assert.That(bytesCount, Is.EqualTo(expectedBytesCount));
//    }
//}