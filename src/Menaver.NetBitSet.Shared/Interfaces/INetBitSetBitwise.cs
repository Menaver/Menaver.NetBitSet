using Menaver.NetBitSet.Shared.Extras;

namespace Menaver.NetBitSet.Shared.Interfaces;

/// <summary>
///     Represents an abstraction of a bitwise-operable data structure.
/// </summary>
public interface INetBitSetBitwise
{
    void And(int position, bool bit);
    void And(int position, byte bit);
    void And(int position, int bit);
    void And(int position, double bit);
    void And(int position, Bit bit);
    void And(INetBitSet bitSet);

    void AndAll(bool bit);
    void AndAll(byte bit);
    void AndAll(int bit);
    void AndAll(double bit);
    void AndAll(Bit bit);

    void Or(int position, bool bit);
    void Or(int position, byte bit);
    void Or(int position, int bit);
    void Or(int position, double bit);
    void Or(int position, Bit bit);
    void Or(INetBitSet bitSet);

    void OrAll(bool bit);
    void OrAll(byte bit);
    void OrAll(int bit);
    void OrAll(double bit);
    void OrAll(Bit bitSet);

    void Xor(int position, bool bit);
    void Xor(int position, byte bit);
    void Xor(int position, int bit);
    void Xor(int position, double bit);
    void Xor(int position, Bit bit);
    void Xor(INetBitSet bitSet);

    void XorAll(bool bit);
    void XorAll(byte bit);
    void XorAll(int bit);
    void XorAll(double bit);
    void XorAll(Bit bit);

    void Invert(long position);
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