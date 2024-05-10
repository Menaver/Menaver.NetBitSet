namespace Menaver.NetBitSet.Interfaces;

/// <summary>
///     Represents an abstraction of a bitwise-operable data structure.
/// </summary>
public interface INetBitSetBitwise
{
    void And(ulong position, bool bit);
    void And(ulong position, byte bit);
    void And(ulong position, int bit);
    void And(ulong position, double bit);
    void And(ulong position, Bit bit);
    void And(INetBitSet bitSet);

    void AndAll(bool bit);
    void AndAll(byte bit);
    void AndAll(int bit);
    void AndAll(double bit);
    void AndAll(Bit bit);

    void Or(ulong position, bool bit);
    void Or(ulong position, byte bit);
    void Or(ulong position, int bit);
    void Or(ulong position, double bit);
    void Or(ulong position, Bit bit);
    void Or(INetBitSet bitSet);

    void OrAll(bool bit);
    void OrAll(byte bit);
    void OrAll(int bit);
    void OrAll(double bit);
    void OrAll(Bit bit);

    void Xor(ulong position, bool bit);
    void Xor(ulong position, byte bit);
    void Xor(ulong position, int bit);
    void Xor(ulong position, double bit);
    void Xor(ulong position, Bit bit);
    void Xor(INetBitSet bitSet);

    void XorAll(bool bit);
    void XorAll(byte bit);
    void XorAll(int bit);
    void XorAll(double bit);
    void XorAll(Bit bit);

    void Invert(ulong position);
    void InvertAll();

    void SetAll();
    void ResetAll();

    void ArithmeticShiftRight(ulong count);
    void LogicalShiftRight(ulong count);
    void CircularShiftRight(ulong count);

    void ArithmeticShiftLeft(ulong count);
    void LogicalShiftLeft(ulong count);
    void CircularShiftLeft(ulong count);

    void ShiftRight(ulong count, bool shiftInBit);
    void ShiftRight(ulong count, byte shiftInBit);
    void ShiftRight(ulong count, int shiftInBit);
    void ShiftRight(ulong count, double shiftInBit);
    void ShiftRight(ulong count, Bit shiftInBit);

    void ShiftLeft(ulong count, bool shiftInBit);
    void ShiftLeft(ulong count, byte shiftInBit);
    void ShiftLeft(ulong count, int shiftInBit);
    void ShiftLeft(ulong count, double shiftInBit);
    void ShiftLeft(ulong count, Bit shiftInBit);
}