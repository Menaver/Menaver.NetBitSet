using System.Text;

namespace Menaver.NetBitSet.Shared.Internals;

internal static class WordLengths
{
    public static WordLength Bool => WordLength.One;
    public static WordLength Byte => WordLength.Eight;
    public static WordLength Short => (WordLength)(BitConverter.GetBytes((short)1).Length * 8);
    public static WordLength Int => (WordLength)(BitConverter.GetBytes((int)1).Length * 8);
    public static WordLength Long => (WordLength)(BitConverter.GetBytes((long)1).Length * 8);
    public static WordLength Double => (WordLength)(BitConverter.GetBytes((double)1).Length * 8);

    public static WordLength String(Encoding encoding)
    {
        {
            if (encoding.EncodingName == Encoding.ASCII.EncodingName)
            {
                return (WordLength)(BitConverter.GetBytes((char)1).Length * 8);
            }

            // other string encoding do not guarantee a fixed length 
            return WordLength.NotFixed;
        }
    }
}