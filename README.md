# NetBitSet – Bit-level working provider for .NET

#### Tool set, providing processing of any type of data on bit level

###### Options
- Transformation of any type of data to a bit stream
- Converting of bit array to a structed data
- Implementation of access to each individual bit by indexer
- Combining different lengths of data (up to 256 MB)
- Representation of binary data as an 8/32-bit numerical value
- Getting the size in bytes occupied by a particular object in memory
- Converting data into binary string + reverse operation
- Internal support for all bit operations
- Bitwise comparison of various types of data, and more...

###### Features
- Compact storage of each bit
- Implementation of 3-standard interfaces: ICollection, IComparable and ICloneable
- The sealed partial-class, divided into a single project into separate modules, each of which is responsible for a specific set of tasks
- Abundance class constructor overloads, enabling you to create an instance of a wide range of data types
- Implicit and explicit operators that provide a more convenient connection and extraction of copies value
- Internal data representation as a combination of blocks of different lengths, and more...

###### Convertion table
| Type                                   | To | From | Implicit | Explicit |
|----------------------------------------|---:| ----:|---------:|---------:|
| Parametrizable array of bits           |+   |-     |-         |-         |
| NetBitSet                              |+   |+     |-         |-         |
| String [binary] (string)               |+   |+     |+         |+         |
| Strictly binary string (string)        |-   |+     |-         |-         |
| Array of [binary] chars (char[])       |+   |+     |+         |+         |
| Array of strictly binary chars (char[])|+   |-     |-         |-         |
| Object and its derived classes (object)|+   |+     |-         |-         |
| 1-bit values (bool / bool[])           |+   |+     |+         |+         |
| 8-bits values (byte / byte[])          |+   |+     |+         |+         |
| 32-bits values (int / int[])           |+   |+     |+         |+         |
| 8-bits numeric representation (byte)   |-   |+     |-         |-         |
| 32-bits numeric representation (int)   |-   |+     |-         |-         |

###### Details
* Type: DLL 
* Language: C# 
* Platform: .NET Framework 4.6.1 
* License: freeware 

  ### [Download](https://github.com/Menaver/NetBitSet/releases)
