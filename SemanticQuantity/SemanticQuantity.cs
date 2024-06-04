namespace ktsu.io.SemanticQuantity;

using System.Numerics;

public abstract record SemanticQuantity<TStorage>(TStorage Quantity)
	where TStorage : INumber<TStorage>
{
}

public abstract record SemanticQuantity<TSelf, TStorage>(TStorage Quantity)
	: SemanticQuantity<TStorage>(Quantity)
	, IAdditionOperators<SemanticQuantity<TSelf, TStorage>, TSelf, TSelf>
	, ISubtractionOperators<SemanticQuantity<TSelf, TStorage>, TSelf, TSelf>
	, IMultiplyOperators<SemanticQuantity<TSelf, TStorage>, TStorage, TSelf>
	, IDivisionOperators<SemanticQuantity<TSelf, TStorage>, TStorage, TSelf>
	, IDivisionOperators<SemanticQuantity<TSelf, TStorage>, SemanticQuantity<TSelf, TStorage>, TStorage>
	, IUnaryNegationOperators<SemanticQuantity<TSelf, TStorage>, TSelf>
	where TSelf : SemanticQuantity<TSelf, TStorage>
	where TStorage : INumber<TStorage>
{
	protected static TQuantity Create<TQuantity>(TStorage quantity)
	{
		var outType = typeof(TQuantity);
		var inType = typeof(TStorage);
		return (TQuantity)(outType == inType
			? quantity
			: Activator.CreateInstance(outType, quantity)!);
	}

	protected static TResult Multiply<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other.Quantity);
	}

	protected static TResult Multiply<TResult>(SemanticQuantity<TSelf, TStorage> self, TStorage other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other);
	}

	protected static TResult Divide<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other.Quantity);
	}

	protected static TResult Divide<TResult>(SemanticQuantity<TSelf, TStorage> self, TStorage other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other);
	}

	protected static TResult Add<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity + other.Quantity);
	}

	protected static TResult Subtract<TResult>(SemanticQuantity<TSelf, TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity - other.Quantity);
	}

	protected static TResult Negate<TResult>(SemanticQuantity<TSelf, TStorage> self)
	{
		ArgumentNullException.ThrowIfNull(self);
		return Create<TResult>(-self.Quantity);
	}

	public static TSelf operator +(SemanticQuantity<TSelf, TStorage> left, TSelf right) => Add<TSelf>(left, right);
	public static TSelf operator -(SemanticQuantity<TSelf, TStorage> left, TSelf right) => Subtract<TSelf>(left, right);
	public static TSelf operator -(SemanticQuantity<TSelf, TStorage> value) => Negate<TSelf>(value);
	public static TSelf operator *(SemanticQuantity<TSelf, TStorage> left, TStorage right) => Multiply<TSelf>(left, right);
	public static TSelf operator /(SemanticQuantity<TSelf, TStorage> left, TStorage right) => Divide<TSelf>(left, right);
	public static TStorage operator /(SemanticQuantity<TSelf, TStorage> left, SemanticQuantity<TSelf, TStorage> right) => Divide<TStorage>(left, (TSelf)right);
}
