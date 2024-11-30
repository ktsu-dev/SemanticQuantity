namespace Test;

using System.Numerics;
using ktsu.SemanticQuantity;

[TestClass]
public class Tests
{
	public record LinearDistance<TStorage>
		: SemanticQuantity<LinearDistance<TStorage>, TStorage>
		, IMultiplyOperators<LinearDistance<TStorage>, LinearDistance<TStorage>, Area<TStorage>>
		where TStorage : INumber<TStorage>
	{
		public static Area<TStorage> operator *(LinearDistance<TStorage> left, LinearDistance<TStorage> right) => Multiply<Area<TStorage>>(left, right);
	}

	public record Area<TStorage>
		: SemanticQuantity<Area<TStorage>, TStorage>
		, IMultiplyOperators<Area<TStorage>, LinearDistance<TStorage>, Volume<TStorage>>
		, IDivisionOperators<Area<TStorage>, LinearDistance<TStorage>, LinearDistance<TStorage>>
		where TStorage : INumber<TStorage>
	{
		public static Volume<TStorage> operator *(Area<TStorage> left, LinearDistance<TStorage> right) => Multiply<Volume<TStorage>>(left, right);
		public static LinearDistance<TStorage> operator /(Area<TStorage> left, LinearDistance<TStorage> right) => Divide<LinearDistance<TStorage>>(left, right);
	}

	public record Volume<TStorage>
		: SemanticQuantity<Volume<TStorage>, TStorage>
		, IDivisionOperators<Volume<TStorage>, LinearDistance<TStorage>, Area<TStorage>>
		, IDivisionOperators<Volume<TStorage>, Area<TStorage>, LinearDistance<TStorage>>
		where TStorage : INumber<TStorage>
	{
		public static Area<TStorage> operator /(Volume<TStorage> left, LinearDistance<TStorage> right) => Divide<Area<TStorage>>(left, right);
		public static LinearDistance<TStorage> operator /(Volume<TStorage> left, Area<TStorage> right) => Divide<LinearDistance<TStorage>>(left, right);
	}

	[TestMethod]
	public void TestMultiplication()
	{
		var distance = SemanticQuantity<int>.Create<LinearDistance<int>>(5);
		var area = SemanticQuantity<int>.Create<Area<int>>(10);
		var volume = SemanticQuantity<int>.Create<Volume<int>>(15);
		var calculatedDistance = distance * 5;
		var calculatedArea = area * 5;
		var calculatedVolume = volume * 5;
		var derivedArea = distance * distance;
		var derivedVolume = area * distance;
		Assert.AreEqual(25, calculatedDistance.Quantity);
		Assert.AreEqual(50, calculatedArea.Quantity);
		Assert.AreEqual(75, calculatedVolume.Quantity);
		Assert.AreEqual(25, derivedArea.Quantity);
		Assert.AreEqual(50, derivedVolume.Quantity);
	}

	[TestMethod]
	public void TestDivision()
	{
		var distance = SemanticQuantity<int>.Create<LinearDistance<int>>(5);
		var area = SemanticQuantity<int>.Create<Area<int>>(10);
		var volume = SemanticQuantity<int>.Create<Volume<int>>(15);
		var calculatedDistance = distance / 5;
		var calculatedArea = area / 5;
		var calculatedVolume = volume / 5;
		var derivedArea = volume / distance;
		var derivedDistance = volume / area;
		int derivedRatio = volume / volume;
		Assert.AreEqual(1, calculatedDistance.Quantity);
		Assert.AreEqual(2, calculatedArea.Quantity);
		Assert.AreEqual(3, calculatedVolume.Quantity);
		Assert.AreEqual(3, derivedArea.Quantity);
		Assert.AreEqual(1, derivedDistance.Quantity);
		Assert.AreEqual(1, derivedRatio);
	}

	[TestMethod]
	public void TestAddition()
	{
		var distance = SemanticQuantity<int>.Create<LinearDistance<int>>(5);
		var area = SemanticQuantity<int>.Create<Area<int>>(10);
		var volume = SemanticQuantity<int>.Create<Volume<int>>(15);
		var calculatedDistance = distance + distance;
		var calculatedArea = area + area;
		var calculatedVolume = volume + volume;
		Assert.AreEqual(10, calculatedDistance.Quantity);
		Assert.AreEqual(20, calculatedArea.Quantity);
		Assert.AreEqual(30, calculatedVolume.Quantity);
	}

	[TestMethod]
	public void TestSubtraction()
	{
		var distance = SemanticQuantity<int>.Create<LinearDistance<int>>(5);
		var area = SemanticQuantity<int>.Create<Area<int>>(10);
		var volume = SemanticQuantity<int>.Create<Volume<int>>(15);
		var calculatedDistance = distance - distance;
		var calculatedArea = area - area;
		var calculatedVolume = volume - volume;
		Assert.AreEqual(0, calculatedDistance.Quantity);
		Assert.AreEqual(0, calculatedArea.Quantity);
		Assert.AreEqual(0, calculatedVolume.Quantity);
	}

	[TestMethod]
	public void TestNegation()
	{
		var distance = SemanticQuantity<int>.Create<LinearDistance<int>>(5);
		var negatedDistance = -distance;
		Assert.AreEqual(-5, negatedDistance.Quantity);
	}
}
