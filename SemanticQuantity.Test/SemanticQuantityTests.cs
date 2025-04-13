namespace ktsu.SemanticQuantity.Test;

using System;

[TestClass]
public class SemanticQuantityTests
{
	// Test types for SemanticQuantity<TStorage>
	public record TestQuantity : SemanticQuantity<double> { }
	public record TestIntQuantity : SemanticQuantity<int> { }

	// Test types for SemanticQuantity<TSelf, TStorage>
	public record Distance : SemanticQuantity<Distance, double> { }
	public record Time : SemanticQuantity<Time, double> { }
	public record Speed : SemanticQuantity<Speed, double> { }

	[TestMethod]
	public void BaseQuantity_CreateMethod_ReturnsInstanceWithCorrectValue()
	{
		// Arrange
		const double expected = 42.0;

		// Act
		var quantity = SemanticQuantity<double>.Create<TestQuantity>(expected);

		// Assert
		Assert.AreEqual(expected, quantity.Quantity);
	}

	[TestMethod]
	public void BaseQuantity_CreateWithIntType_ReturnsInstanceWithCorrectValue()
	{
		// Arrange
		const int expected = 100;

		// Act
		var quantity = SemanticQuantity<int>.Create<TestIntQuantity>(expected);

		// Assert
		Assert.AreEqual(expected, quantity.Quantity);
	}

	[TestMethod]
	public void DerivedQuantity_Create_ReturnsInstanceWithCorrectValue()
	{
		// Arrange
		const double expected = 10.0;

		// Act
		var distance = Distance.Create(expected);

		// Assert
		Assert.AreEqual(expected, distance.Quantity);
		Assert.IsInstanceOfType<Distance>(distance);
	}

	[TestMethod]
	public void DerivedQuantity_AddOperator_ReturnsSumOfQuantities()
	{
		// Arrange
		var distance1 = Distance.Create(10.0);
		var distance2 = Distance.Create(5.0);

		// Act
		var sum = distance1 + distance2;

		// Assert
		Assert.AreEqual(15.0, sum.Quantity);
	}

	[TestMethod]
	public void DerivedQuantity_SubtractOperator_ReturnsDifferenceOfQuantities()
	{
		// Arrange
		var distance1 = Distance.Create(10.0);
		var distance2 = Distance.Create(3.0);

		// Act
		var difference = distance1 - distance2;

		// Assert
		Assert.AreEqual(7.0, difference.Quantity);
	}

	[TestMethod]
	public void DerivedQuantity_NegateOperator_ReturnsNegatedQuantity()
	{
		// Arrange
		var distance = Distance.Create(5.0);

		// Act
		var negated = -distance;

		// Assert
		Assert.AreEqual(-5.0, negated.Quantity);
	}

	[TestMethod]
	public void DerivedQuantity_MultiplyOperator_ReturnsProductWithScalar()
	{
		// Arrange
		var distance = Distance.Create(10.0);
		const double factor = 2.5;

		// Act
		var product = distance * factor;

		// Assert
		Assert.AreEqual(25.0, product.Quantity);
	}

	[TestMethod]
	public void DerivedQuantity_DivideOperator_ReturnsQuotientWithScalar()
	{
		// Arrange
		var distance = Distance.Create(20.0);
		const double divisor = 4.0;

		// Act
		var quotient = distance / divisor;

		// Assert
		Assert.AreEqual(5.0, quotient.Quantity);
	}

	[TestMethod]
	public void DerivedQuantity_DivideOperator_ReturnsDimensionlessValue()
	{
		// Arrange
		var distance1 = Distance.Create(20.0);
		var distance2 = Distance.Create(5.0);

		// Act
		double ratio = distance1 / distance2;

		// Assert
		Assert.AreEqual(4.0, ratio);
		Assert.IsInstanceOfType<double>(ratio);
	}

	[TestMethod]
	public void StaticAdd_ReturnsCorrectSum()
	{
		// Arrange
		var distance1 = Distance.Create(10);
		var distance2 = Distance.Create(5);

		// Act
		var sum = SemanticQuantity<Distance, double>.Add<Distance>(distance1, distance2);

		// Assert
		Assert.AreEqual(15.0, sum.Quantity);
	}

	[TestMethod]
	public void StaticSubtract_ReturnsCorrectDifference()
	{
		// Arrange
		var distance1 = Distance.Create(15);
		var distance2 = Distance.Create(7);

		// Act
		var difference = SemanticQuantity<Distance, double>.Subtract<Distance>(distance1, distance2);

		// Assert
		Assert.AreEqual(8.0, difference.Quantity);
	}

	[TestMethod]
	public void StaticMultiply_WithTwoQuantities_ReturnsCorrectProduct()
	{
		// Arrange
		var distance = Distance.Create(100);
		var time = Time.Create(0.5);

		// Act
		var speed = SemanticQuantity<Distance, double>.Multiply<Speed>(distance, time);

		// Assert
		Assert.AreEqual(50.0, speed.Quantity);
	}

	[TestMethod]
	public void StaticMultiply_WithQuantityAndScalar_ReturnsCorrectProduct()
	{
		// Arrange
		var distance = Distance.Create(10);
		const double factor = 3.0;

		// Act
		var result = SemanticQuantity<Distance, double>.Multiply<Distance>(distance, factor);

		// Assert
		Assert.AreEqual(30.0, result.Quantity);
	}

	[TestMethod]
	public void StaticDivide_WithTwoQuantities_ReturnsCorrectQuotient()
	{
		// Arrange
		var distance = Distance.Create(100);
		var time = Time.Create(25);

		// Act
		var speed = SemanticQuantity<Distance, double>.Divide<Speed>(distance, time);

		// Assert
		Assert.AreEqual(4.0, speed.Quantity);
	}

	[TestMethod]
	public void StaticDivide_WithQuantityAndScalar_ReturnsCorrectQuotient()
	{
		// Arrange
		var distance = Distance.Create(50);
		const double divisor = 5.0;

		// Act
		var result = SemanticQuantity<Distance, double>.Divide<Distance>(distance, divisor);

		// Assert
		Assert.AreEqual(10.0, result.Quantity);
	}

	[TestMethod]
	public void StaticDivideToStorage_ReturnsCorrectValue()
	{
		// Arrange
		var distance1 = Distance.Create(30);
		var distance2 = Distance.Create(6);

		// Act
		double ratio = SemanticQuantity<Distance, double>.DivideToStorage(distance1, distance2);

		// Assert
		Assert.AreEqual(5.0, ratio);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentNullException))]
	public void StaticMethods_WithNullArguments_ThrowArgumentNullException()
	{
		// We can't actually pass null to value types, so this test is a bit artificial
		// It mainly tests that the null check code paths exist and run
		// Arrange
		Distance? nullDistance = null;

		// Act - should throw
		SemanticQuantity<Distance, double>.Add<Distance>(nullDistance!, new Distance());
	}
}
