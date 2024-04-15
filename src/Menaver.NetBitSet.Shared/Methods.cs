using System;
using System.Collections;
using System.Collections.Generic;

namespace Menaver.NetBitSet.Shared
{
    public partial class NetBitSet
    {
        #region IMPLEMENTATIONS & OVERRIDES

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(NetBitSet)) return false;
            return Equals((NetBitSet)obj);
        }


        public override int GetHashCode()
        {
            return unchecked(((_container != null ? _container.GetHashCode() : 0) * 873) ^ _wordLength.GetHashCode());
        }


        public int this[int index]
        {
            // represents all bits (bools) as numbers (ints): 0 --> false, any other value --> true

            get { return _container[index] == false ? 0 : 1; }
            set { _container[index] = value == 0 ? false : true; }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (bool bit in _container)
                // converting of bools to ints
                yield return bit == false ? 0 : 1;
        }


        public void CopyTo(Array array, int index = 0)
        {
            _container.CopyTo(array, index);
        }


        public object Clone()
        {
            return new NetBitSet { _container = (BitArray)_container.Clone(), _wordLength = this._wordLength };
        }

        #endregion


        #region BITWISE

        public void And(int position, int value)
        {
            // converting bool to int
            bool bValue = value != 0;
            _container[position] = _container[position] & bValue;
        }

        public void AndAll(int value)
        {
            // converting bool to int
            bool bValue = value != 0;
            for (var i = 0; i < _container.Count; i++)
                _container[i] = _container[i] & bValue;
        }


        public void Or(int position, int value)
        {
            // converting bool to int
            bool bValue = value != 0;
            _container[position] = _container[position] | bValue;
        }

        public void OrAll(int value)
        {
            // converting bool to int
            bool bValue = value != 0;
            for (var i = 0; i < _container.Count; i++)
                _container[i] = _container[i] | bValue;
        }


        public void Xor(int position, int value)
        {
            // converting bool to int
            bool bValue = value != 0;
            _container[position] = _container[position] ^ bValue;
        }

        public void XorAll(int value)
        {
            // converting bool to int
            bool bValue = value != 0;
            for (var i = 0; i < _container.Count; i++)
                _container[i] = _container[i] ^ bValue;
        }


        public void Invert(int position)
        {
            _container[position] = !_container[position];
        }

        public void InvertAll()
        {
            for (var i = 0; i < _container.Count; i++)
                _container[i] = !_container[i];
        }


        public void ShiftRight(int count, int shiftInValue = 0)
        {
            for (var i = 0; i < count; i++)
            {
                for (var j = 0; j < Count - 1; j++)
                    this[j] = this[j + 1];

                this[Count - 1] = shiftInValue;
            }
        }

        public void ShiftLeft(int count, int shiftInValue = 0)
        {
            for (var i = 0; i < count; i++)
            {
                for (var j = Count - 1; j > 0; j--)
                    this[j] = this[j - 1];

                this[0] = shiftInValue;
            }
        }

        #endregion


        public void Resize(int newSize)
        {
            _container.Length = newSize;
        }
    }
}