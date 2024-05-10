using System.Text;

namespace Menaver.NetBitSet.Internals;

internal static class WordLengths
{
    public static WordLength Bool => WordLength.One;
    public static WordLength Byte => WordLength.Eight;
    public static WordLength Short => (WordLength)(BitConverter.GetBytes((short)1).Length * 8);
    public static WordLength Int => (WordLength)(BitConverter.GetBytes(1).Length * 8);
    public static WordLength Long => (WordLength)(BitConverter.GetBytes((long)1).Length * 8);
    public static WordLength Double => (WordLength)(BitConverter.GetBytes((double)1).Length * 8);

    public static WordLength String(string str, Encoding encoding)
    {
        if (str.Any() && str.All(ch => ch is '1' or '0'))
        {
            // binary string
            return WordLength.One;
        }

        if (encoding.EncodingName == Encoding.ASCII.EncodingName)
        {
            return (WordLength)(Encoding.ASCII.GetBytes(" ").Length * 8);
        }

        // other string encoding do not guarantee a fixed length 
        return WordLength.NotFixed;
    }
}