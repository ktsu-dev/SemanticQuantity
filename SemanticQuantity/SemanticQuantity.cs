namespace ktsu.io.SemanticQuantity;

using System.Numerics;

public record SemanticQuantity<TStorage>(TStorage BaseQuantity)
	where TStorage : INumber<TStorage>
{
	public static TQuantity Create<TQuantity>(TStorage baseQuantity)
	{
		var outType = typeof(TQuantity);
		var inType = typeof(TStorage);
		return (TQuantity)(outType == inType
			? baseQuantity
			: Activator.CreateInstance(outType, baseQuantity)!);
	}

	protected static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.BaseQuantity * other.BaseQuantity);
	}

	protected static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, TStorage other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.BaseQuantity * other);
	}

	protected static TResult Divide<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.BaseQuantity / other.BaseQuantity);
	}

	protected static TResult Divide<TResult>(SemanticQuantity<TStorage> self, TStorage other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.BaseQuantity / other);
	}

	protected static TResult Add<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.BaseQuantity + other.BaseQuantity);
	}

	protected static TResult Subtract<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.BaseQuantity - other.BaseQuantity);
	}
}
