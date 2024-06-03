namespace Test;

using System.Numerics;
using ktsu.io.SemanticQuantity;

[TestClass]
public class Tests
{
	public record LinearDistance<TStorage>(TStorage BaseQuantity)
		: SemanticQuantity<TStorage>(BaseQuantity)
		, IMultiplyOperators<LinearDistance<TStorage>, TStorage, LinearDistance<TStorage>>
		, IMultiplyOperators<LinearDistance<TStorage>, LinearDistance<TStorage>, Area<TStorage>>
		, IDivisionOperators<LinearDistance<TStorage>, TStorage, LinearDistance<TStorage>>
		, IDivisionOperators<LinearDistance<TStorage>, LinearDistance<TStorage>, TStorage>
		, IAdditionOperators<LinearDistance<TStorage>, LinearDistance<TStorage>, LinearDistance<TStorage>>
		, ISubtractionOperators<LinearDistance<TStorage>, LinearDistance<TStorage>, LinearDistance<TStorage>>
		where TStorage : INumber<TStorage>
	{
		public static LinearDistance<TStorage> operator +(LinearDistance<TStorage> left, LinearDistance<TStorage> right) => Add<LinearDistance<TStorage>>(left, right);
		public static LinearDistance<TStorage> operator -(LinearDistance<TStorage> left, LinearDistance<TStorage> right) => Subtract<LinearDistance<TStorage>>(left, right);
		public static LinearDistance<TStorage> operator *(LinearDistance<TStorage> left, TStorage right) => Multiply<LinearDistance<TStorage>>(left, right);
		public static Area<TStorage> operator *(LinearDistance<TStorage> left, LinearDistance<TStorage> right) => Multiply<Area<TStorage>>(left, right);
		public static LinearDistance<TStorage> operator /(LinearDistance<TStorage> left, TStorage right) => Divide<LinearDistance<TStorage>>(left, right);
		public static TStorage operator /(LinearDistance<TStorage> left, LinearDistance<TStorage> right) => Divide<TStorage>(left, right);
	}

	public record Area<TStorage>(TStorage BaseQuantity)
		: SemanticQuantity<TStorage>(BaseQuantity)
		, IMultiplyOperators<Area<TStorage>, TStorage, Area<TStorage>>
		, IMultiplyOperators<Area<TStorage>, LinearDistance<TStorage>, Volume<TStorage>>
		, IDivisionOperators<Area<TStorage>, TStorage, Area<TStorage>>
		, IDivisionOperators<Area<TStorage>, LinearDistance<TStorage>, LinearDistance<TStorage>>
		, IDivisionOperators<Area<TStorage>, Area<TStorage>, TStorage>
		, IAdditionOperators<Area<TStorage>, Area<TStorage>, Area<TStorage>>
		, ISubtractionOperators<Area<TStorage>, Area<TStorage>, Area<TStorage>>
		where TStorage : INumber<TStorage>
	{
		public static Area<TStorage> operator +(Area<TStorage> left, Area<TStorage> right) => Add<Area<TStorage>>(left, right);
		public static Area<TStorage> operator -(Area<TStorage> left, Area<TStorage> right) => Subtract<Area<TStorage>>(left, right);
		public static Area<TStorage> operator *(Area<TStorage> left, TStorage right) => Multiply<Area<TStorage>>(left, right);
		public static Volume<TStorage> operator *(Area<TStorage> left, LinearDistance<TStorage> right) => Multiply<Volume<TStorage>>(left, right);
		public static Area<TStorage> operator /(Area<TStorage> left, TStorage right) => Divide<Area<TStorage>>(left, right);
		public static LinearDistance<TStorage> operator /(Area<TStorage> left, LinearDistance<TStorage> right) => Divide<LinearDistance<TStorage>>(left, right);
		public static TStorage operator /(Area<TStorage> left, Area<TStorage> right) => Divide<TStorage>(left, right);
	}

	public record Volume<TStorage>(TStorage BaseQuantity)
		: SemanticQuantity<TStorage>(BaseQuantity)
		, IMultiplyOperators<Volume<TStorage>, TStorage, Volume<TStorage>>
		, IDivisionOperators<Volume<TStorage>, TStorage, Area<TStorage>>
		, IDivisionOperators<Volume<TStorage>, LinearDistance<TStorage>, Area<TStorage>>
		, IDivisionOperators<Volume<TStorage>, Area<TStorage>, LinearDistance<TStorage>>
		, IDivisionOperators<Volume<TStorage>, Volume<TStorage>, TStorage>
		, IAdditionOperators<Volume<TStorage>, Volume<TStorage>, Volume<TStorage>>
		, ISubtractionOperators<Volume<TStorage>, Volume<TStorage>, Volume<TStorage>>
		where TStorage : INumber<TStorage>
	{
		public static Volume<TStorage> operator +(Volume<TStorage> left, Volume<TStorage> right) => Add<Volume<TStorage>>(left, right);
		public static Volume<TStorage> operator -(Volume<TStorage> left, Volume<TStorage> right) => Subtract<Volume<TStorage>>(left, right);
		public static Volume<TStorage> operator *(Volume<TStorage> left, TStorage right) => Multiply<Volume<TStorage>>(left, right);
		public static Area<TStorage> operator /(Volume<TStorage> left, LinearDistance<TStorage> right) => Divide<Area<TStorage>>(left, right);
		public static LinearDistance<TStorage> operator /(Volume<TStorage> left, Area<TStorage> right) => Divide<LinearDistance<TStorage>>(left, right);
		public static TStorage operator /(Volume<TStorage> left, Volume<TStorage> right) => Divide<TStorage>(left, right);
		public static Area<TStorage> operator /(Volume<TStorage> left, TStorage right) => Divide<Area<TStorage>>(left, right);
	}

	[TestMethod]
	public void TestMultiplication()
	{
		var distance = new LinearDistance<int>(5);
		var area = new Area<int>(10);
		var volume = new Volume<int>(15);
		var calculatedDistance = distance * 5;
		var calculatedArea = area * 5;
		var calculatedVolume = volume * 5;
		var derivedArea = distance * distance;
		var derivedVolume = area * distance;
		Assert.AreEqual(25, calculatedDistance.BaseQuantity);
		Assert.AreEqual(50, calculatedArea.BaseQuantity);
		Assert.AreEqual(75, calculatedVolume.BaseQuantity);
		Assert.AreEqual(25, derivedArea.BaseQuantity);
		Assert.AreEqual(50, derivedVolume.BaseQuantity);
	}

	[TestMethod]
	public void TestDivision()
	{
		var distance = new LinearDistance<int>(5);
		var area = new Area<int>(10);
		var volume = new Volume<int>(15);
		var calculatedDistance = distance / 5;
		var calculatedArea = area / 5;
		var calculatedVolume = volume / 5;
		var derivedArea = volume / distance;
		var derivedDistance = volume / area;
		int derivedRatio = volume / volume;
		Assert.AreEqual(1, calculatedDistance.BaseQuantity);
		Assert.AreEqual(2, calculatedArea.BaseQuantity);
		Assert.AreEqual(3, calculatedVolume.BaseQuantity);
		Assert.AreEqual(3, derivedArea.BaseQuantity);
		Assert.AreEqual(1, derivedDistance.BaseQuantity);
		Assert.AreEqual(1, derivedRatio);
	}

	[TestMethod]
	public void TestAddition()
	{
		var distance = new LinearDistance<int>(5);
		var area = new Area<int>(10);
		var volume = new Volume<int>(15);
		var calculatedDistance = distance + distance;
		var calculatedArea = area + area;
		var calculatedVolume = volume + volume;
		Assert.AreEqual(10, calculatedDistance.BaseQuantity);
		Assert.AreEqual(20, calculatedArea.BaseQuantity);
		Assert.AreEqual(30, calculatedVolume.BaseQuantity);
	}

	[TestMethod]
	public void TestSubtraction()
	{
		var distance = new LinearDistance<int>(5);
		var area = new Area<int>(10);
		var volume = new Volume<int>(15);
		var calculatedDistance = distance - distance;
		var calculatedArea = area - area;
		var calculatedVolume = volume - volume;
		Assert.AreEqual(0, calculatedDistance.BaseQuantity);
		Assert.AreEqual(0, calculatedArea.BaseQuantity);
		Assert.AreEqual(0, calculatedVolume.BaseQuantity);
	}
}
