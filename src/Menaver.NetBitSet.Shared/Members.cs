using System.Collections;

namespace Menaver.NetBitSet.Shared
{
    public partial class NetBitSet
    {
        #region FIELDS

        private BitArray _container;
        private byte _wordLength;

        #endregion


        #region PROPERTIES

        public byte WordLength => _wordLength;

        public int Count => _container.Length;

        public int BlocksCount
        {
            get
            {
                if (_wordLength == 0)
                    return 0;

                return _container.Length / _wordLength;
            }
        }

        public float BytesCount => (float)_container.Count / 8;


        public object SyncRoot => _container.SyncRoot;

        public bool IsSynchronized => _container.IsSynchronized;

        #endregion
    }
}