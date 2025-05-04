// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

[assembly: CLSCompliant(true)]
[assembly: System.Runtime.InteropServices.ComVisible(false)]
namespace ktsu.SemanticQuantity;

using System.Numerics;

/// <summary>
/// Represents a semantic quantity with a specific storage type.
/// </summary>
/// <typeparam name="TStorage">The type used for storing the quantity value.</typeparam>
public record SemanticQuantity<TStorage>
	where TStorage : INumber<TStorage>
{
	/// <summary>
	/// Gets the stored quantity value.
	/// </summary>
	public TStorage Quantity { get; protected set; } = TStorage.Zero;

	/// <summary>
	/// Initializes a new instance of the <see cref="SemanticQuantity{TStorage}"/> class.
	/// </summary>
	protected SemanticQuantity() { }

	/// <summary>
	/// Creates a new instance of a custom quantity type.
	/// </summary>
	/// <typeparam name="TQuantity">The type of the custom quantity.</typeparam>
	/// <param name="quantity">The quantity value.</param>
	/// <returns>A new instance of the custom quantity type.</returns>
	public static TQuantity Create<TQuantity>(TStorage quantity)
		where TQuantity : SemanticQuantity<TStorage>, new()
		=> new TQuantity() with { Quantity = quantity };
}

/// <summary>
/// Represents a semantic quantity with additional arithmetic operations.
/// </summary>
/// <typeparam name="TSelf">The derived type.</typeparam>
/// <typeparam name="TStorage">The type used for storing the quantity value.</typeparam>
public record SemanticQuantity<TSelf, TStorage>
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
	/// <summary>
	/// Initializes a new instance of the <see cref="SemanticQuantity{TSelf, TStorage}"/> class.
	/// </summary>
	protected SemanticQuantity() { }

	/// <summary>
	/// Multiplies two quantities.
	/// </summary>
	/// <typeparam name="TResult">The type of the resulting quantity.</typeparam>
	/// <param name="self">The first quantity.</param>
	/// <param name="other">The second quantity.</param>
	/// <returns>The product of the two quantities.</returns>
	public static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other.Quantity)!;
	}

	/// <summary>
	/// Multiplies a quantity by a scalar.
	/// </summary>
	/// <typeparam name="TResult">The type of the resulting quantity.</typeparam>
	/// <param name="self">The quantity.</param>
	/// <param name="other">The scalar value.</param>
	/// <returns>The product of the quantity and the scalar.</returns>
	public static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, TStorage other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other)!;
	}

	/// <summary>
	/// Divides one quantity by another.
	/// </summary>
	/// <typeparam name="TResult">The type of the resulting quantity.</typeparam>
	/// <param name="self">The dividend quantity.</param>
	/// <param name="other">The divisor quantity.</param>
	/// <returns>The quotient of the two quantities.</returns>
	public static TResult Divide<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other.Quantity)!;
	}

	/// <summary>
	/// Divides a quantity by a scalar.
	/// </summary>
	/// <typeparam name="TResult">The type of the resulting quantity.</typeparam>
	/// <param name="self">The quantity.</param>
	/// <param name="other">The scalar value.</param>
	/// <returns>The quotient of the quantity and the scalar.</returns>
	public static TResult Divide<TResult>(SemanticQuantity<TStorage> self, TStorage other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other)!;
	}

	/// <summary>
	/// Divides one quantity by another and returns the result as a storage type.
	/// </summary>
	/// <param name="self">The dividend quantity.</param>
	/// <param name="other">The divisor quantity.</param>
	/// <returns>The quotient as a storage type.</returns>
	public static TStorage DivideToStorage(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return self.Quantity / other.Quantity;
	}

	/// <summary>
	/// Adds two quantities.
	/// </summary>
	/// <typeparam name="TResult">The type of the resulting quantity.</typeparam>
	/// <param name="self">The first quantity.</param>
	/// <param name="other">The second quantity.</param>
	/// <returns>The sum of the two quantities.</returns>
	public static TResult Add<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity + other.Quantity)!;
	}

	/// <summary>
	/// Subtracts one quantity from another.
	/// </summary>
	/// <typeparam name="TResult">The type of the resulting quantity.</typeparam>
	/// <param name="self">The quantity to subtract from.</param>
	/// <param name="other">The quantity to subtract.</param>
	/// <returns>The difference of the two quantities.</returns>
	public static TResult Subtract<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity - other.Quantity)!;
	}

	/// <summary>
	/// Negates a quantity.
	/// </summary>
	/// <typeparam name="TResult">The type of the resulting quantity.</typeparam>
	/// <param name="self">The quantity to negate.</param>
	/// <returns>The negated quantity.</returns>
	public static TResult Negate<TResult>(SemanticQuantity<TStorage> self)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		return Create<TResult>(-self.Quantity)!;
	}

	/// <inheritdoc/>
	public static TSelf operator +(SemanticQuantity<TSelf, TStorage> left, TSelf right) => Add<TSelf>(left, right);

	/// <inheritdoc/>
	public static TSelf operator -(SemanticQuantity<TSelf, TStorage> left, TSelf right) => Subtract<TSelf>(left, right);

	/// <inheritdoc/>
	public static TSelf operator -(SemanticQuantity<TSelf, TStorage> value) => Negate<TSelf>(value);

	/// <inheritdoc/>
	public static TSelf operator *(SemanticQuantity<TSelf, TStorage> left, TStorage right) => Multiply<TSelf>(left, right);

	/// <inheritdoc/>
	public static TSelf operator /(SemanticQuantity<TSelf, TStorage> left, TStorage right) => Divide<TSelf>(left, right);

	/// <inheritdoc/>
	public static TStorage operator /(SemanticQuantity<TSelf, TStorage> left, SemanticQuantity<TSelf, TStorage> right) => DivideToStorage(left, right);

	/// <summary>
	/// Creates a new instance of the derived quantity type.
	/// </summary>
	/// <param name="quantity">The quantity value.</param>
	/// <returns>A new instance of the derived quantity type.</returns>
	public static TSelf Create(TStorage quantity) => new TSelf() with { Quantity = quantity };
}
