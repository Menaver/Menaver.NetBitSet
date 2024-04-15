namespace Menaver.NetBitSet.Shared
{
    public partial class NetBitSet
    {
        // compares this NetBitSet object with other
        // by analysis of _container and _wordLength
        private bool Equals(NetBitSet other)
        {
            if (_container.Count != other._container.Count)
                return false;

            for (var i = 0; i < _container.Count; i++)
                if (_container[i] != other._container[i])
                    return false;

            if (_container.IsReadOnly != other._container.IsReadOnly)
                return false;

            if (_container.IsSynchronized != other._container.IsSynchronized)
                return false;

            if (_wordLength != other._wordLength)
                return false;

            return true;
        }


        // generate error message in case of mismatch 
        // of word length and required type to convert
        private static string GenerateErrorMessage(byte wordLength)
        {
            string errorMessage = $"Word length ({wordLength}) do not match to this kind of type. Data type is ";

            switch (wordLength)
            {
                case 1:
                    errorMessage += "bool (1-bit values)";
                    break;
                case 8:
                    errorMessage += "byte (8-bit values)";
                    break;
                case 32:
                    errorMessage += "int (32-bit values)";
                    break;
                default:
                    errorMessage += "unspecified";
                    break;
            }

            return errorMessage;
        }


        // calculate new size to match of wordLength to required type to convert
        private static int GetNewArraySize(int currentBitCount, int wordLength)
        {
            int temp = currentBitCount % wordLength;

            if (temp == 0)
                // if current bit count in array is in accordance with wordLength
                return currentBitCount;
            else
                // if it is not then expand to accordance
                return currentBitCount + (wordLength - temp);
        }
    }
}