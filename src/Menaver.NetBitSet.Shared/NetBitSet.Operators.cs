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

    public static bool operator ==(NetBitSet left, NetBitSet right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(NetBitSet left, NetBitSet right)
    {
        return !Equals(left, right);
    }

    #region IMPLICIT

    public static implicit operator NetBitSet(bool value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(sbyte value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(byte value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(short value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(ushort value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(int value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(uint value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(long value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(ulong value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(double value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(string value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(bool[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(sbyte[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(byte[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(short[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(ushort[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(int[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(uint[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(long[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(ulong[] value)
    {
        return new NetBitSet(value);
    }

    public static implicit operator NetBitSet(double[] value)
    {
        return new NetBitSet(value);
    }

    #endregion

    #region EXPLICIT

    public static explicit operator bool(NetBitSet obj)
    {
        return obj.ToBools().FirstOrDefault();
    }

    public static explicit operator sbyte(NetBitSet obj)
    {
        return obj.ToSBytes().FirstOrDefault();
    }

    public static explicit operator byte(NetBitSet obj)
    {
        return obj.ToBytes().FirstOrDefault();
    }

    public static explicit operator short(NetBitSet obj)
    {
        return obj.ToShorts().FirstOrDefault();
    }

    public static explicit operator ushort(NetBitSet obj)
    {
        return obj.ToUShorts().FirstOrDefault();
    }

    public static explicit operator int(NetBitSet obj)
    {
        return obj.ToInts().FirstOrDefault();
    }

    public static explicit operator uint(NetBitSet obj)
    {
        return obj.ToUInts().FirstOrDefault();
    }

    public static explicit operator long(NetBitSet obj)
    {
        return obj.ToLongs().FirstOrDefault();
    }

    public static explicit operator ulong(NetBitSet obj)
    {
        return obj.ToULongs().FirstOrDefault();
    }

    public static explicit operator double(NetBitSet obj)
    {
        return obj.ToDoubles().FirstOrDefault();
    }

    public static explicit operator string(NetBitSet obj)
    {
        return obj.ToString();
    }

    public static explicit operator bool[](NetBitSet obj)
    {
        return obj.ToBools();
    }

    public static explicit operator sbyte[](NetBitSet obj)
    {
        return obj.ToSBytes();
    }

    public static explicit operator byte[](NetBitSet obj)
    {
        return obj.ToBytes();
    }

    public static explicit operator short[](NetBitSet obj)
    {
        return obj.ToShorts();
    }

    public static explicit operator ushort[](NetBitSet obj)
    {
        return obj.ToUShorts();
    }

    public static explicit operator int[](NetBitSet obj)
    {
        return obj.ToInts();
    }

    public static explicit operator uint[](NetBitSet obj)
    {
        return obj.ToUInts();
    }

    public static explicit operator long[](NetBitSet obj)
    {
        return obj.ToLongs();
    }

    public static explicit operator ulong[](NetBitSet obj)
    {
        return obj.ToULongs();
    }

    public static explicit operator double[](NetBitSet obj)
    {
        return obj.ToDoubles();
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