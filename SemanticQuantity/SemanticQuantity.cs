namespace ktsu.io.SemanticQuantity;

using System.Numerics;

public abstract record SemanticQuantity<TStorage>(TStorage Quantity)
	where TStorage : INumber<TStorage>
{
}

public abstract record SemanticQuantity<TSelf, TStorage>(TStorage Quantity)
	: SemanticQuantity<TStorage>(Quantity)
	, IAdditionOperators<TSelf, TSelf, TSelf>
	, ISubtractionOperators<TSelf, TSelf, TSelf>
	, IUnaryNegationOperators<TSelf, TSelf>
	where TSelf : SemanticQuantity<TSelf, TStorage>
	where TStorage : INumber<TStorage>
{
	public static TQuantity Create<TQuantity>(TStorage quantity)
	{
		var outType = typeof(TQuantity);
		var inType = typeof(TStorage);
		return (TQuantity)(outType == inType
			? quantity
			: Activator.CreateInstance(outType, quantity)!);
	}

	protected static TResult Multiply<TResult>(TSelf self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other.Quantity);
	}

	protected static TResult Multiply<TResult>(TSelf self, TStorage other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other);
	}

	protected static TResult Divide<TResult>(TSelf self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other.Quantity);
	}

	protected static TResult Divide<TResult>(TSelf self, TStorage other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other);
	}

	protected static TResult Add<TResult>(TSelf self, TSelf other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity + other.Quantity);
	}

	protected static TResult Subtract<TResult>(TSelf self, TSelf other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity - other.Quantity);
	}

	protected static TResult Negate<TResult>(TSelf self)
	{
		ArgumentNullException.ThrowIfNull(self);
		return Create<TResult>(-self.Quantity);
	}

	static TSelf IAdditionOperators<TSelf, TSelf, TSelf>.operator +(TSelf left, TSelf right) => Add<TSelf>(left, right);
	static TSelf ISubtractionOperators<TSelf, TSelf, TSelf>.operator -(TSelf left, TSelf right) => Subtract<TSelf>(left, right);
	static TSelf IUnaryNegationOperators<TSelf, TSelf>.operator -(TSelf value) => Negate<TSelf>(value);
}
