using NUnit.Framework.Internal;

namespace Menaver.NetBitSet.Tests;

public abstract class TestsBase
{
    protected static Shared.NetBitSet EmptySut;
    protected static Shared.NetBitSet CustomSut;
    protected static Shared.NetBitSet NetBitSetSut;
    protected static Shared.NetBitSet StringSut;
    protected static Shared.NetBitSet StringBinarySut;
    protected static Shared.NetBitSet CharArraySut;
    protected static Shared.NetBitSet CharBinaryArraySut;
    protected static Shared.NetBitSet ObjectSut;
    protected static Shared.NetBitSet BoolSut;
    protected static Shared.NetBitSet ByteSut;
    protected static Shared.NetBitSet IntSut;
    protected static Shared.NetBitSet BoolArraySut;
    protected static Shared.NetBitSet ByteArraySut;
    protected static Shared.NetBitSet IntArraySut;


    /// <summary>
    ///     Standard arrange for all tests
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        EmptySut = new Shared.NetBitSet();

        CustomSut = new Shared.NetBitSet(33, 1, 1);

        NetBitSetSut = new Shared.NetBitSet(CustomSut);

        StringSut = new Shared.NetBitSet("Hello, World!");
        StringBinarySut = new Shared.NetBitSet("1100110110110011", 8);

        CharArraySut = new Shared.NetBitSet("Hi there!".ToCharArray());
        CharBinaryArraySut = new Shared.NetBitSet("100100110010", 1);

        ObjectSut = new Shared.NetBitSet(new DateTime(2016, 7, 25));

        BoolSut = new Shared.NetBitSet(true);
        ByteSut = new Shared.NetBitSet((byte)57);
        IntSut = new Shared.NetBitSet(223);

        BoolArraySut = new Shared.NetBitSet(new bool[4] { false, true, true, false });
        ByteArraySut = new Shared.NetBitSet(new byte[3] { 83, 92, 13 });
        IntArraySut = new Shared.NetBitSet(new int[3] { 873, 666, 12345 });
    }


    /// <summary>
    ///     Returns one of prepared NetBitSet instances by its name
    /// </summary>
    protected Shared.NetBitSet GetInstanceByName(string name)
    {
        switch (name)
        {
            case nameof(EmptySut): return EmptySut;
            case nameof(CustomSut): return CustomSut;
            case nameof(NetBitSetSut): return NetBitSetSut;
            case nameof(StringSut): return StringSut;
            case nameof(StringBinarySut): return StringBinarySut;
            case nameof(CharArraySut): return CharArraySut;
            case nameof(CharBinaryArraySut): return CharBinaryArraySut;
            case nameof(ObjectSut): return ObjectSut;
            case nameof(BoolSut): return BoolSut;
            case nameof(ByteSut): return ByteSut;
            case nameof(IntSut): return IntSut;
            case nameof(BoolArraySut): return BoolArraySut;
            case nameof(ByteArraySut): return ByteArraySut;
            case nameof(IntArraySut): return IntArraySut;
            default: throw new InvalidTestFixtureException();
        }
    }

    /// <summary>
    ///     Executes method of a required NetBitSet instance by its name
    /// </summary>
    protected void ExecuteMethodByName(Shared.NetBitSet obj, string methodName, object[] args)
    {
        // calling of a method, just by name...
        obj.GetType().GetMethod(methodName).Invoke(obj, args);
    }
}