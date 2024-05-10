namespace Menaver.NetBitSet.Tests;

[TestFixture]
public class NetBitSetLFSRTests
{
    [TestCase("001", new ulong[] { 2, 0 }, 8, "10111001")]
    [TestCase("001", new ulong[] { 1, 0 }, 8, "11101001")]
    [TestCase("1111", new ulong[] { 3, 0 }, 15, "000100110101111")]
    [TestCase("1010110011100001", new ulong[] { 8, 4, 2, 1 }, 6, "100001")]
    [TestCase("101010101010", new ulong[] { 6, 4, 1, 0 }, 12, "101010101010")]
    public void LFSR_Shift_OutputDataFits(
        string binaryString,
        ulong[] polynomial,
        int shiftCount,
        string expectedBinaryString)
    {
        // arrange
        var netBitSet = new NetBitSet(binaryString);
        var lfsr = new LFSR.LFSR(netBitSet, polynomial);

        // act
        var output = lfsr.Shift((ulong)shiftCount);
        var outputBinaryString = new NetBitSet(output).ToBinaryString();

        // asset
        Assert.That(outputBinaryString == expectedBinaryString);
    }
}