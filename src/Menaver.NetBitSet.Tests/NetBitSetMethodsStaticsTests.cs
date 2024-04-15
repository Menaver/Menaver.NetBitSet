namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetMethodsStaticsTests : TestsBase
{
    [TestCase("sgewgegewv")]
    public void ShouldThrowExceptionWhileConvertionBinaryStringToObject(string notBinaryString)
    {
        // act & assert
        Assert.That(() => Shared.NetBitSet.BinaryStringToObject(notBinaryString), Throws.Exception);
    }

    [TestCase(54321, 54)]
    public void ShouldReturnObjectSizeInBytes(object obj, int expected)
    {
        // act
        var result = Shared.NetBitSet.GetObjectSize(obj);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }
}