namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
    public static NetBitSet operator +(NetBitSet left, NetBitSet right)
    {
        // adding right to the end of left

        byte newWordLength = 0;

        // if wordLengths are compatible then
        // use left.WordLength as newWordLength
        if (left.WordLength == right.WordLength)
            newWordLength = left.WordLength;
        else if (right.WordLength % left.WordLength == 0)
            newWordLength = left.WordLength;

        var result = new NetBitSet(checked(left.Count + right.Count), newWordLength);

        for (var i = 0; i < left.Count; i++)
            result[i] = left[i];

        for (int i = left.Count, j = 0; i < result.Count; i++, j++)
            result[i] = right[j];

        return result;
    }


    #region IMPLICIT

    // Provides assigning of a specified value to the new NetBitSet instance 
    // by automatically calling of appropriate constructor

    public static implicit operator NetBitSet(string str)
    {
        return new NetBitSet(str);
    }

    public static implicit operator NetBitSet(char[] array)
    {
        return new NetBitSet(array);
    }


    public static implicit operator NetBitSet(bool value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(byte value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(int value)
    {
        return new NetBitSet(value);
    }


    public static implicit operator NetBitSet(bool[] array)
    {
        return new NetBitSet(array);
    }

    public static implicit operator NetBitSet(byte[] array)
    {
        return new NetBitSet(array);
    }

    public static implicit operator NetBitSet(int[] array)
    {
        return new NetBitSet(array);
    }

    #endregion


    #region Explicit

    // Provides NetBitSet type conversion operator that must be invoked with a cast

    public static explicit operator string(NetBitSet obj)
    {
        return obj.ToString();
    }

    public static explicit operator char[](NetBitSet obj)
    {
        return obj.ToCharArray();
    }


    public static explicit operator bool(NetBitSet obj)
    {
        return obj.ToBool();
    }

    public static explicit operator byte(NetBitSet obj)
    {
        return obj.ToByte();
    }

    public static explicit operator int(NetBitSet obj)
    {
        return obj.ToInt();
    }


    public static explicit operator bool[](NetBitSet obj)
    {
        return obj.ToBoolArray();
    }

    public static explicit operator byte[](NetBitSet obj)
    {
        return obj.ToByteArray();
    }

    public static explicit operator int[](NetBitSet obj)
    {
        return obj.ToIntArray();
    }

    #endregion


    #region EQUALITY

    public static bool operator ==(NetBitSet left, NetBitSet right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(NetBitSet left, NetBitSet right)
    {
        return !Equals(left, right);
    }

    #endregion


    #region BITWISE

    // for all bits in NetBitSet array

    // left shift
    public static NetBitSet operator <<(NetBitSet obj, int count)
    {
        // not so good solution, but... it works!

        var result = (NetBitSet)obj.Clone();
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < result.Count - 1; j++)
                result[j] = result[j + 1];

            // shift-in sign is 0
            result[result.Count - 1] = 0;
        }

        return result;
    }

    // right shift
    public static NetBitSet operator >> (NetBitSet obj, int count)
    {
        // not so good solution, but... it works!

        var result = (NetBitSet)obj.Clone();
        for (var i = 0; i < count; i++)
        {
            for (var j = result.Count - 1; j > 0; j--)
                result[j] = result[j - 1];

            // shift-in sign is 0
            result[0] = 0;
        }

        return result;
    }


    // AND
    public static NetBitSet operator &(NetBitSet left, NetBitSet right)
    {
        if (right.Count < left.Count)
            throw new ArgumentException("Value's lengths should be equal");

        var result = (NetBitSet)left.Clone();
        for (var i = 0; i < left.Count; i++)
            result._containers[i] = left._containers[i] & right._containers[i];

        return result;
    }

    // OR
    public static NetBitSet operator |(NetBitSet left, NetBitSet right)
    {
        if (right.Count < left.Count)
            throw new ArgumentException("Value's lengths should be equal");

        var result = (NetBitSet)left.Clone();
        for (var i = 0; i < left.Count; i++)
            result._containers[i] = left._containers[i] | right._containers[i];

        return result;
    }

    // XOR
    public static NetBitSet operator ^(NetBitSet left, NetBitSet right)
    {
        if (right.Count < left.Count)
            throw new ArgumentException("Value's lengths should be equal");

        var result = (NetBitSet)left.Clone();
        for (var i = 0; i < left.Count; i++)
            result._containers[i] = left._containers[i] ^ right._containers[i];

        return result;
    }

    // inverting
    public static NetBitSet operator ~(NetBitSet obj)
    {
        var result = (NetBitSet)obj.Clone();
        for (var i = 0; i < obj.Count; i++)
            result._containers[i] = !obj._containers[i];

        return result;
    }

    // self-inverting
    public static NetBitSet operator !(NetBitSet obj)
    {
        obj.InvertAll();
        return obj;
    }


    // comparing
    public static bool operator <(NetBitSet left, NetBitSet right)
    {
        if (left._containers.Count < right._containers.Count) return true;
        if (left._containers.Count > right._containers.Count) return false;

        for (var i = 0; i < left._containers.Count; i++)
        {
            if (left._containers[i] == right._containers[i]) continue; // if (0 == 0 || 1 == 1) -> check next pos

            if (left._containers[i] && !right._containers[i])
                return false; // if (1 and 0) then (left > right) -> return false
            if (!left._containers[i] && right._containers[i])
                return true; // if (0 and 1) then (left < right) -> return true
        }

        return false;
    }

    // comparing
    public static bool operator >(NetBitSet left, NetBitSet right)
    {
        if (left._containers.Count > right._containers.Count) return true;
        if (left._containers.Count < right._containers.Count) return false;

        for (var i = 0; i < left._containers.Count; i++)
        {
            if (left._containers[i] == right._containers[i]) continue; // if (0 == 0 || 1 == 1) -> check next pos

            if (left._containers[i] && !right._containers[i])
                return true; // if (1 and 0) then (left > right) -> return true
            if (!left._containers[i] && right._containers[i])
                return false; // if (0 and 1) then (left < right) -> return false
        }

        return false;
    }

    #endregion
}