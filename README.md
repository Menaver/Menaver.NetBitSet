# Overview

Inspired by [std::bitset](https://en.cppreference.com/w/cpp/utility/bitset) from C++, `NetBitSet` represents a .NET implementation of a fixed-size sequence of bits. 
`NetBitSet` gives you an ability to operate with data on a bit level, it can be manipulated by standard logic operators, cloned, converted to and from basic CTS numeric data types, strings and even abstract objects.

## Keynotes
- Platform: netstandard2.0;
- Deliverable: shared package (DLL);
- The implementation is covered with both Unit (800+) and Performance (25+) tests;
- This repository leverages Github Actions (GHA);

## Features
- Compact storing of each individual bit in RAM;
- Implementation of the following basic interfaces: `IEnumerable`, `ICloneable`;
- Large data support (technically, it's up to ~18446.74 petabytes, as long as your machine's RAM can handle it :D);
- Implicit and explicit casting operators that provide more convenient interaction with data;
- And many others.

## Supported bitwise operations
- And
- Or
- Xor
- Not (Invert)
- Arithmetic Shift
- Circular Shift
- Circular Shift
- Invert Endianess

## Supported data conversions

| Type                                   		| From | To | Implicit Cast | Explicit Cast |
|-----------------------------------------------|-----:| --:|--------------:|--------------:|
| 1-bit (`bool` / `bool[]`)							|  ✅  | ✅ |       ✅      |       ✅       |
| 8-bits (`(s)byte` / `(s)byte[]`)					|  ✅  | ✅ |       ✅      |       ✅       |
| 32-bits (`(u)int` / `(u)int[]`)					|  ✅  | ✅ |       ✅      |       ✅       |
| 64-bits (`(u)long` / `(u)long[]`)					|  ✅  | ✅ |       ✅      |       ✅       |
| 64-bits floating-point (`double` / `double[]`)	|  ✅  | ✅ |       ✅      |       ✅       |
| String (`string`)								|  ✅  | ✅ |       ✅      |       ❌       |
| Binary string (`string`)						|  ✅  | ✅ |       ✅      |       ❌       |
| `Object` of any type (serializable)				|  ✅  | ✅ |       ❌      |       ❌       |

## Performance

The Performance testing is driven by [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet).
Its run results can be found in repo's GHA [here](https://github.com/Menaver/menaver.netbitset/actions/workflows/run-perf-tests.yml).

# Examples

### Initialization

```cs
// from bool
NetBitSet netBitSet = false; // or new NetBitSet(false);

// from byte
NetBitSet netBitSet = (byte)42; // or new NetBitSet((byte)42);

// from int
NetBitSet netBitSet = 873; // or new NetBitSet(873);

// from double
NetBitSet netBitSet = 873.4; // or new NetBitSet(873.4);

// from bytes
NetBitSet netBitSet = new bool[] { true, false, false, true };

// from bytes
NetBitSet netBitSet = new byte[] { 34, 45, 124, 46 };

// from ints
NetBitSet netBitSet = new int[] { 34, 45, 124, 46 };

// from doubles
NetBitSet netBitSet = new double[] { 122.4, 433.2, 446.2 };

// from string
NetBitSet netBitSet = "Hello, world!"; // or new NetBitSet("Hello, world!");

// from string with encoding
NetBitSet netBitSet = new NetBitSet("Hello, world!", Encoding.ASCII);

// from binary string
NetBitSet netBitSet = "11100110011100000"; // or new NetBitSet("11100110011100000");

// from object
NetBitSet netBitSet = new NetBitSet(DateTimeOffset.UtcNow);
```

### Conversion

```cs
var @bool = (bool)netBitSet; // or netBitSet.ToBool()

var @byte = (byte)netBitSet; // or netBitSet.ToByte()

var @int = (int)netBitSet; // or netBitSet.ToInt()

var bools = (bool[])netBitSet; // or netBitSet.ToBools()

var bytes = (byte[])netBitSet; // or netBitSet.ToBytes()

var ints = (int[])netBitSet; // or netBitSet.ToInts()

var @string = netBitSet.ToString();

var @string = netBitSet.ToString(Encoding.ASCII);

var binaryString = netBitSet.ToBinaryString();

var dataTimeOffset = netBitSet.ToObject<DateTimeOffset>();
```

### Bitwise operations

```cs
// And
netBitSetA &= netBitSetB;

// Or
netBitSetA |= netBitSetB;

// Xor
netBitSetA ^= netBitSetB;

// Not
netBitSetA = ~netBitSetB;

// logical shift left
netBitSet <<= 3;

// logical shift right
netBitSet >>= 3;
```

### Basic use-case: visualize data, invert data bits, xor every bit by 0

```cs
// file data to bitset
var bytes = File.ReadAllBytes("picture.png");
NetBitSet bits = new NetBitSet(bytes);

// output binary data as string
var binaryString = bits.ToBinaryString();
Console.WriteLine(binaryString);

// invert data bits
bits.InvertAll();

// xor data bits
var count = bits.Count;
for (ulong i = 0; i < count; i++)
{
	bits[i].Xor(Bit.False);
}

// safe file
bytes = bits.ToBytes();
File.WriteAllBytes("picture.png", bytes);
```

### Basic use-case: bit-level data encryption using [linear-feedback shift register (LFSR)](https://en.wikipedia.org/wiki/Linear-feedback_shift_register)

```cs
var password = "password123";
var polynomial = new ulong[] { 11, 9, 8, 0 };

// password to LFSR
var passwordBits = new NetBitSet(password);
var passwordLfsr = new Menaver.NetBitSet.LFSR.LFSR(passwordBits, polynomial);

// file data to bitset
var dataBytes = File.ReadAllBytes("picture.png");
NetBitSet dataBits = new NetBitSet(dataBytes);

// encrypt data
var count = dataBits.Count;
for (ulong i = 0; i < count; i++)
{
	var outBit = passwordLfsr.Shift();
	dataBits[i] = dataBits[i].Xor(outBit);
}

// safe file
dataBytes = dataBits.ToBytes();
File.WriteAllBytes("picture.png", dataBytes);
```
