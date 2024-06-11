# ktsu.io.SemanticQuantity

![NuGet Version](https://img.shields.io/nuget/v/ktsu.io.SemanticQuantity?logo=nuget&label=stable)
![NuGet Version](https://img.shields.io/nuget/vpre/ktsu.io.SemanticQuantity?logo=nuget&label=dev)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/ktsu-io/SemanticQuantity?label=commits)
![GitHub branch status](https://img.shields.io/github/checks-status/ktsu-io/SemanticQuantity/main)
![Sonar Coverage](https://img.shields.io/sonar/coverage/ktsu-io_SemanticQuantity?server=https%3A%2F%2Fsonarcloud.io)

The `SemanticQuantity` library provides a flexible and type-safe way to represent quantities with specific semantic meanings. It supports a wide range of numeric types and provides a robust set of functionalities for arithmetic operations and comparisons.

## Features

- Type-safe quantity representation
- Support for various numeric types (`BigInteger`, `float`, `double`, `int`, etc.)
- Arithmetic operations (addition, subtraction, multiplication, division)
- Operator overloading for intuitive usage
- Extensible design for creating custom quantity types

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
  - [Creating a SemanticQuantity](#creating-a-semanticquantity)
      - [Supported Numeric Types](#supported-numeric-types)
      - [Examples](#examples)
  - [Arithmetic Operations](#arithmetic-operations)
  - [Comparison Operations](#comparison-operations)
  - [Custom Quantity Types](#custom-quantity-types)
- [API Reference](#api-reference)
- [Contributing](#contributing)
- [License](#license)

## Installation

To install the `SemanticQuantity` library, you can use the .NET CLI:

```sh
dotnet add package ktsu.io.SemanticQuantity
```

Or, add the package reference directly in your project file:

```xml
<PackageReference Include="ktsu.io.SemanticQuantity" Version="1.0.0" />
```

## Usage

### Creating a SemanticQuantity

You can create a `SemanticQuantity` from various numeric types using the `Create` method.

#### Supported Numeric Types

The `SemanticQuantity` class supports a wide range of numeric types, leveraging the `INumber` interface for conversions. The following types are supported:

- **Integer Types**:
  - `int`
  - `long`
  - `short`
  - `sbyte`
  - `uint`
  - `ulong`
  - `ushort`
  - `byte`
  - `BigInteger`

- **Floating-Point Types**:
  - `double`
  - `float`
  - `Half`
  - `decimal`

#### Examples

You can create custom quantity types and convert various numeric types to `SemanticQuantity` using the `Create` method:

```csharp
using ktsu.io.SemanticQuantity;
using System.Numerics;

// Define custom quantity types
public record LengthBigInt : SemanticQuantity<LengthBigInt, BigInteger>;
public record LengthFloat : SemanticQuantity<LengthFloat, float>;
public record LengthDouble : SemanticQuantity<LengthDouble, double>;
public record LengthInt : SemanticQuantity<LengthInt, int>;

// Create instances of custom quantity types
var lengthBigInt = LengthBigInt.Create(new BigInteger(12345));
var lengthFloat = LengthFloat.Create(123.45f);
var lengthDouble = LengthDouble.Create(123.45);
var lengthInt = LengthInt.Create(12345);
```

### Arithmetic Operations

You can perform various arithmetic operations on `SemanticQuantity` instances:

```csharp
var length1 = LengthInt.Create(10);
var length2 = LengthInt.Create(20);

var resultAdd = length1 + length2;    // Addition
var resultSub = length1 - length2;    // Subtraction
var resultMul = length1 * 2;          // Multiplication
var resultDiv = length1 / 2;          // Division
var resultNeg = -length1;             // Negation
```

### Comparison Operations

You can compare `SemanticQuantity` instances using operator overloading:

```csharp
bool isEqual = length1 == length2;
bool isGreater = length1 > length2;
bool isLessOrEqual = length1 <= length2;
```

### Custom Quantity Types

You can define custom quantity types by inheriting from `SemanticQuantity<TSelf, TStorage>`:

```csharp
using System.Numerics;

public record Weight : SemanticQuantity<Weight, BigInteger>;
public record Distance : SemanticQuantity<Distance, double>;

var weight = Weight.Create(new BigInteger(100));
var distance = Distance.Create(123.45);
```

## API Reference

### Properties

- `TStorage Quantity` - Gets the stored quantity value.

### Methods

- `static TQuantity Create<TQuantity>(TStorage quantity) where TQuantity : SemanticQuantity<TStorage>, new()` - Creates a new instance of a custom quantity type.
- `static TResult Multiply<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other) where TResult : SemanticQuantity<TStorage>, new()` - Multiplies two quantities.
- `static TResult Multiply<TResult>(SemanticQuantity<TSelf, TStorage> self, TStorage other) where TResult : SemanticQuantity<TStorage>, new()` - Multiplies a quantity by a scalar.
- `static TResult Divide<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other) where TResult : SemanticQuantity<TStorage>, new()` - Divides one quantity by another.
- `static TResult Divide<TResult>(SemanticQuantity<TSelf, TStorage> self, TStorage other) where TResult : SemanticQuantity<TStorage>, new()` - Divides a quantity by a scalar.
- `static TStorage DivideToStorage(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)` - Divides one quantity by another and returns the result as a storage type.
- `static TResult Add<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other) where TResult : SemanticQuantity<TStorage>, new()` - Adds two quantities.
- `static TResult Subtract<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other) where TResult : SemanticQuantity<TStorage>, new()` - Subtracts one quantity from another.
- `static TResult Negate<TResult>(SemanticQuantity<TSelf, TStorage> self) where TResult : SemanticQuantity<TStorage>, new()` - Negates a quantity.

### Operators

- `static TSelf operator +(SemanticQuantity<TSelf, TStorage> left, TSelf right)` - Adds two quantities.
- `static TSelf operator -(SemanticQuantity<TSelf, TStorage> left, TSelf right)` - Subtracts one quantity from another.
- `static TSelf operator -(SemanticQuantity<TSelf, TStorage> value)` - Negates a quantity.
- `static TSelf operator *(SemanticQuantity<TSelf, TStorage> left, TStorage right)` - Multiplies a quantity by a scalar.
- `static TSelf operator /(SemanticQuantity<TSelf, TStorage> left, TStorage right)` - Divides a quantity by a scalar.
- `static TStorage operator /(SemanticQuantity<TSelf, TStorage> left, SemanticQuantity<TSelf, TStorage> right)` - Divides one quantity by another and returns the result as a storage type.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
