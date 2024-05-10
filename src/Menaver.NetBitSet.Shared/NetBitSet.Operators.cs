namespace Menaver.NetBitSet.Shared;

public partial class NetBitSet
{
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

    public static NetBitSet operator <<(NetBitSet obj, int count)
    {
        var result = (NetBitSet)obj.Clone();

        result.LogicalShiftLeft((ulong)count);

        return result;
    }

    public static NetBitSet operator >> (NetBitSet obj, int count)
    {
        var result = (NetBitSet)obj.Clone();

        result.LogicalShiftRight((ulong)count);

        return result;
    }

    public static NetBitSet operator &(NetBitSet left, NetBitSet right)
    {
        var result = (NetBitSet)left.Clone();

        result.And(right);

        return result;
    }

    public static NetBitSet operator |(NetBitSet left, NetBitSet right)
    {
        var result = (NetBitSet)left.Clone();

        result.Or(right);

        return result;
    }

    public static NetBitSet operator ^(NetBitSet left, NetBitSet right)
    {
        var result = (NetBitSet)left.Clone();

        result.Xor(right);

        return result;
    }

    public static NetBitSet operator ~(NetBitSet obj)
    {
        var result = (NetBitSet)obj.Clone();

        result.InvertAll();

        return result;
    }

    #endregion
}