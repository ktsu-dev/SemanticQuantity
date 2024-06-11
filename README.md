# Semantic Quantity

The `SemanticQuantity` class is designed to provide a framework for creating and manipulating quantities with semantic meaning, such as physical quantities (e.g., length, mass, time). Here's an overview of the class and its functionality:

### Overview

The `SemanticQuantity` class is an abstract record that serves as a base for creating specific quantity types. It supports various arithmetic operations and provides a generic way to create instances of derived quantity types.

### Code Explanation

```csharp
namespace ktsu.io.SemanticQuantity;

using System.Numerics;

public abstract record SemanticQuantity<TStorage>
	where TStorage : INumber<TStorage>
{
	public TStorage Quantity { get; protected set; } = TStorage.Zero;

	public static TQuantity Create<TQuantity>(TStorage quantity)
		where TQuantity : SemanticQuantity<TStorage>, new()
		=> new TQuantity() with { Quantity = quantity };
}

public abstract record SemanticQuantity<TSelf, TStorage>
	: SemanticQuantity<TStorage>
	, IAdditionOperators<SemanticQuantity<TSelf, TStorage>, TSelf, TSelf>
	, ISubtractionOperators<SemanticQuantity<TSelf, TStorage>, TSelf, TSelf>
	, IMultiplyOperators<SemanticQuantity<TSelf, TStorage>, TStorage, TSelf>
	, IDivisionOperators<SemanticQuantity<TSelf, TStorage>, TStorage, TSelf>
	, IDivisionOperators<SemanticQuantity<TSelf, TStorage>, SemanticQuantity<TSelf, TStorage>, TStorage>
	, IUnaryNegationOperators<SemanticQuantity<TSelf, TStorage>, TSelf>
	where TSelf : SemanticQuantity<TSelf, TStorage>, new()
	where TStorage : INumber<TStorage>
{
	public static TResult Multiply<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other.Quantity)!;
	}

	public static TResult Multiply<TResult>(SemanticQuantity<TSelf, TStorage> self, TStorage other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other)!;
	}

	public static TResult Divide<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other.Quantity)!;
	}

	public static TResult Divide<TResult>(SemanticQuantity<TSelf, TStorage> self, TStorage other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other)!;
	}

	public static TStorage DivideToStorage(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return self.Quantity / other.Quantity;
	}

	public static TResult Add<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity + other.Quantity)!;
	}

	public static TResult Subtract<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity - other.Quantity)!;
	}

	public static TResult Negate<TResult>(SemanticQuantity<TSelf, TStorage> self)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		return Create<TResult>(-self.Quantity)!;
	}

	public static TSelf operator +(SemanticQuantity<TSelf, TStorage> left, TSelf right) => Add<TSelf>(left, right);
	public static TSelf operator -(SemanticQuantity<TSelf, TStorage> left, TSelf right) => Subtract<TSelf>(left, right);
	public static TSelf operator -(SemanticQuantity<TSelf, TStorage> value) => Negate<TSelf>(value);
	public static TSelf operator *(SemanticQuantity<TSelf, TStorage> left, TStorage right) => Multiply<TSelf>(left, right);
	public static TSelf operator /(SemanticQuantity<TSelf, TStorage> left, TStorage right) => Divide<TSelf>(left, right);
	public static TStorage operator /(SemanticQuantity<TSelf, TStorage> left, SemanticQuantity<TSelf, TStorage> right) => DivideToStorage(left, right);

	public static TSelf Create(TStorage quantity) => new TSelf() with { Quantity = quantity };
}
```

### Key Features

- **Generic Quantity Storage**: Supports any numeric type (`TStorage`) that implements the `INumber` interface.
- **Arithmetic Operations**: Implements addition, subtraction, multiplication, and division operators.
- **Factory Methods**: Provides methods to create instances of `SemanticQuantity` and derived types.
- **Operator Overloads**: Overloads common arithmetic operators to enable intuitive mathematical operations.

### Usage Example

Here's how you might use the `SemanticQuantity` class:

```csharp
namespace ktsu.io.SemanticQuantity.Example;

using System.Numerics;

public record Length : SemanticQuantity<Length, BigInteger>;

public static class Program
{
	public static void Main()
	{
		Length length1 = Length.Create(5);
		Length length2 = Length.Create(10);

		Length result = length1 + length2;
		Console.WriteLine(result.Quantity); // Output: 15

		Length multiplied = length1 * 2;
		Console.WriteLine(multiplied.Quantity); // Output: 10

		Length divided = length2 / 2;
		Console.WriteLine(divided.Quantity); // Output: 5
	}
}
```

In this example, `Length` is a specific type of `SemanticQuantity` that uses `BigInteger` for storage. You can perform arithmetic operations like addition, multiplication, and division on `Length` instances.
