# ktsu.SemanticQuantity  

![NuGet Version](https://img.shields.io/nuget/v/ktsu.SemanticQuantity?logo=nuget&label=stable)  
![NuGet Version](https://img.shields.io/nuget/vpre/ktsu.SemanticQuantity?logo=nuget&label=dev)  
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/ktsu-io/SemanticQuantity?label=commits)  
![GitHub branch status](https://img.shields.io/github/checks-status/ktsu-io/SemanticQuantity/main)  
![Sonar Coverage](https://img.shields.io/sonar/coverage/ktsu-io_SemanticQuantity?server=https%3A%2F%2Fsonarcloud.io)  

## Overview  

The `ktsu.SemanticQuantity` library provides a base class for creating semantic quantities with a specific storage type. This allows for defining quantities with meaningful semantics, such as length, mass, time, etc., and performing arithmetic operations on them while preserving their semantics.  

## Features  

- Define semantic quantities with meaningful semantics.  

- Perform arithmetic operations on semantic quantities.  

- Support for a wide range of numeric types for storage.  

- Integration with .NET numeric interfaces.  

## Table of Contents  

- [Installation](#installation)  

- [Usage](#usage)  

- [Creating a Semantic Quantity](#creating-a-semantic-quantity)  

- [Arithmetic Operations](#arithmetic-operations)  

- [Comparison Operations](#comparison-operations)  

- [Supported Numeric Types](#supported-numeric-types)  

- [API Reference](#api-reference)  

- [Contributing](#contributing)  

- [License](#license)  

## Installation  

To install the `ktsu.SemanticQuantity` library, you can use the .NET CLI:  

```sh  
dotnet add package ktsu.SemanticQuantity  

```  

Or, add the package reference directly in your project file:  

```xml  
<PackageReference Include="ktsu.SemanticQuantity" Version="1.0.0" />  

```  

## Usage  

### Creating a Semantic Quantity  

You can create a semantic quantity from various numeric types using the `Create` method:  

```csharp  
using ktsu.SemanticQuantity;  
using System.Numerics;  

// Define a specific semantic quantity type  
public record Length : SemanticQuantity<Length, double>;  

var length = Length.Create(123.45);  
Console.WriteLine(length.Quantity); // Output: 123.45  

```  

### Arithmetic Operations  

You can perform various arithmetic operations on semantic quantities:  

```csharp  
var length1 = Length.Create(100.0);  
var length2 = Length.Create(200.0);  

var sum = length1 + length2;  

var difference = length1 - length2;  

var product = length1 * 2.0;  

var quotient = length2 / 2.0;  
var ratio = length2 / length1;  

```  

### Supported Numeric Types  

The `SemanticQuantity`class supports a wide range of numeric types for storage through the`INumber` interface. The following types are supported:  

- `int`  

- `long`  

- `short`  

- `sbyte`  

- `uint`  

- `ulong`  

- `ushort`  

- `byte`  

- `BigInteger`  

- `double`  

- `float`  

- `Half`  

- `decimal`  

## API Reference  

### `SemanticQuantity<TStorage>`  

- `TStorage Quantity { get; protected set; }`: Gets the stored quantity value.  

#### Methods  

- `static TQuantity Create<TQuantity>(TStorage quantity)`: Creates a new instance of the specified `SemanticQuantity<TQuantity>` type with the given quantity.  

### `SemanticQuantity<TSelf, TStorage>`  

- Inherits from `SemanticQuantity<TStorage>` and implements various arithmetic operators.  

#### Methods  

- `static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)`: Multiplies two semantic quantities and returns the result as a new instance of the specified type.  

- `static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, TStorage other)`: Multiplies a semantic quantity by a scalar value and returns the result as a new instance of the specified type.  

- `static TResult Divide<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)`: Divides one semantic quantity by another and returns the result as a new instance of the specified type.  

- `static TResult Divide<TResult>(SemanticQuantity<TStorage> self, TStorage other)`: Divides a semantic quantity by a scalar value and returns the result as a new instance of the specified type.  

- `static TStorage DivideToStorage(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)`: Divides one semantic quantity by another and returns the result as a scalar value.  

- `static TResult Add<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)`: Adds two semantic quantities and returns the result as a new instance of the specified type.  

- `static TResult Subtract<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)`: Subtracts one semantic quantity from another and returns the result as a new instance of the specified type.  

- `static TResult Negate<TResult>(SemanticQuantity<TStorage> self)`: Negates a semantic quantity and returns the result as a new instance of the specified type.  

### Operators  

- `static TSelf operator +(SemanticQuantity<TSelf, TStorage> left, TSelf right)`: Adds two semantic quantities.  

- `static TSelf operator -(SemanticQuantity<TSelf, TStorage> left, TSelf right)`: Subtracts one semantic quantity from another.  

- `static TSelf operator -(SemanticQuantity<TSelf, TStorage> value)`: Negates a semantic quantity.  

- `static TSelf operator *(SemanticQuantity<TSelf, TStorage> left, TStorage right)`: Multiplies a semantic quantity by a scalar value.  

- `static TSelf operator /(SemanticQuantity<TSelf, TStorage> left, TStorage right)`: Divides a semantic quantity by a scalar value.  

- `static TStorage operator /(SemanticQuantity<TSelf, TStorage> left, SemanticQuantity<TSelf, TStorage> right)`: Divides one semantic quantity by another.  

## Contributing  

Contributions are welcome! Please feel free to submit a pull request or open an issue.  

## License  

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.  
