namespace ktsu.io.SemanticQuantity;

using System.Numerics;

public record SemanticQuantity<TStorage>(TStorage Quantity)
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

	protected static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other.Quantity);
	}

	protected static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, TStorage other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other);
	}

	protected static TResult Divide<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other.Quantity);
	}

	protected static TResult Divide<TResult>(SemanticQuantity<TStorage> self, TStorage other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other);
	}

	protected static TResult Add<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity + other.Quantity);
	}

	protected static TResult Subtract<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity - other.Quantity);
	}
}
