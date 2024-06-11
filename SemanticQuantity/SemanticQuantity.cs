[assembly: CLSCompliant(true)]
[assembly: System.Runtime.InteropServices.ComVisible(false)]
namespace ktsu.io.SemanticQuantity;

using System.Numerics;

public record SemanticQuantity<TStorage>
	where TStorage : INumber<TStorage>
{
	public TStorage Quantity { get; protected set; } = TStorage.Zero;

	protected SemanticQuantity() { }

	public static TQuantity Create<TQuantity>(TStorage quantity)
		where TQuantity : SemanticQuantity<TStorage>, new()
		=> new TQuantity() with { Quantity = quantity };
}

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
	protected SemanticQuantity() { }

	public static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other.Quantity)!;
	}

	public static TResult Multiply<TResult>(SemanticQuantity<TStorage> self, TStorage other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity * other)!;
	}

	public static TResult Divide<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other.Quantity)!;
	}

	public static TResult Divide<TResult>(SemanticQuantity<TStorage> self, TStorage other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity / other)!;
	}

	public static TStorage DivideToStorage(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return self.Quantity / other.Quantity;
	}

	public static TResult Add<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity + other.Quantity)!;
	}

	public static TResult Subtract<TResult>(SemanticQuantity<TStorage> self, SemanticQuantity<TStorage> other)
		where TResult : SemanticQuantity<TStorage>, new()
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(other);
		return Create<TResult>(self.Quantity - other.Quantity)!;
	}

	public static TResult Negate<TResult>(SemanticQuantity<TStorage> self)
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
