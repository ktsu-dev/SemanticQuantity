namespace Test;

using System.Numerics;
using ktsu.SemanticQuantity;

public record LengthBigInt : SemanticQuantity<LengthBigInt, BigInteger>;
public record LengthFloat : SemanticQuantity<LengthFloat, float>;
public record LengthDouble : SemanticQuantity<LengthDouble, double>;
public record LengthInt : SemanticQuantity<LengthInt, int>;

[TestClass]
public class AITests
{
	#region BigInteger Tests

	[TestMethod]
	public void CreateBigIntShouldInitializeQuantity()
	{
		var expected = new BigInteger(10);
		var length = LengthBigInt.Create(expected);
		Assert.AreEqual(expected, length.Quantity);
	}

	[TestMethod]
	public void AddBigIntShouldReturnCorrectResult()
	{
		var length1 = LengthBigInt.Create(new BigInteger(5));
		var length2 = LengthBigInt.Create(new BigInteger(10));
		var result = length1 + length2;
		Assert.AreEqual(new BigInteger(15), result.Quantity);
	}

	[TestMethod]
	public void SubtractBigIntShouldReturnCorrectResult()
	{
		var length1 = LengthBigInt.Create(new BigInteger(10));
		var length2 = LengthBigInt.Create(new BigInteger(5));
		var result = length1 - length2;
		Assert.AreEqual(new BigInteger(5), result.Quantity);
	}

	[TestMethod]
	public void NegateBigIntShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(5));
		var result = -length;
		Assert.AreEqual(new BigInteger(-5), result.Quantity);
	}

	[TestMethod]
	public void MultiplyBigIntWithSemanticQuantityShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(5));
		var multiplier = SemanticQuantity<BigInteger>.Create<LengthBigInt>(new BigInteger(2));
		var result = SemanticQuantity<LengthBigInt, BigInteger>.Multiply<LengthBigInt>(length, multiplier);
		Assert.AreEqual(new BigInteger(10), result.Quantity);
	}

	[TestMethod]
	public void MultiplyBigIntWithStorageTypeShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(5));
		var multiplier = new BigInteger(2);
		var result = length * multiplier;
		Assert.AreEqual(new BigInteger(10), result.Quantity);
	}

	[TestMethod]
	public void DivideBigIntWithSemanticQuantityShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(10));
		var divisor = SemanticQuantity<BigInteger>.Create<LengthBigInt>(new BigInteger(2));
		var result = SemanticQuantity<LengthBigInt, BigInteger>.Divide<LengthBigInt>(length, divisor);
		Assert.AreEqual(new BigInteger(5), result.Quantity);
	}

	[TestMethod]
	public void DivideBigIntWithStorageTypeShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(10));
		var divisor = new BigInteger(2);
		var result = length / divisor;
		Assert.AreEqual(new BigInteger(5), result.Quantity);
	}

	[TestMethod]
	public void DivideToStorageBigIntShouldReturnCorrectResult()
	{
		var length1 = LengthBigInt.Create(new BigInteger(10));
		var length2 = LengthBigInt.Create(new BigInteger(2));
		var result = length1 / length2;
		Assert.AreEqual(new BigInteger(5), result);
	}

	#endregion

	#region Float Tests

	[TestMethod]
	public void CreateFloatShouldInitializeQuantity()
	{
		float expected = 10f;
		var length = LengthFloat.Create(expected);
		Assert.AreEqual(expected, length.Quantity);
	}

	[TestMethod]
	public void AddFloatShouldReturnCorrectResult()
	{
		var length1 = LengthFloat.Create(5f);
		var length2 = LengthFloat.Create(10f);
		var result = length1 + length2;
		Assert.AreEqual(15f, result.Quantity);
	}

	[TestMethod]
	public void SubtractFloatShouldReturnCorrectResult()
	{
		var length1 = LengthFloat.Create(10f);
		var length2 = LengthFloat.Create(5f);
		var result = length1 - length2;
		Assert.AreEqual(5f, result.Quantity);
	}

	[TestMethod]
	public void NegateFloatShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(5f);
		var result = -length;
		Assert.AreEqual(-5f, result.Quantity);
	}

	[TestMethod]
	public void MultiplyFloatWithSemanticQuantityShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(5f);
		var multiplier = SemanticQuantity<float>.Create<LengthFloat>(2f);
		var result = SemanticQuantity<LengthFloat, float>.Multiply<LengthFloat>(length, multiplier);
		Assert.AreEqual(10f, result.Quantity);
	}

	[TestMethod]
	public void MultiplyFloatWithStorageTypeShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(5f);
		float multiplier = 2f;
		var result = length * multiplier;
		Assert.AreEqual(10f, result.Quantity);
	}

	[TestMethod]
	public void DivideFloatWithSemanticQuantityShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(10f);
		var divisor = SemanticQuantity<float>.Create<LengthFloat>(2f);
		var result = SemanticQuantity<LengthFloat, float>.Divide<LengthFloat>(length, divisor);
		Assert.AreEqual(5f, result.Quantity);
	}

	[TestMethod]
	public void DivideFloatWithStorageTypeShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(10f);
		float divisor = 2f;
		var result = length / divisor;
		Assert.AreEqual(5f, result.Quantity);
	}

	[TestMethod]
	public void DivideToStorageFloatShouldReturnCorrectResult()
	{
		var length1 = LengthFloat.Create(10f);
		var length2 = LengthFloat.Create(2f);
		float result = length1 / length2;
		Assert.AreEqual(5f, result);
	}

	#endregion

	#region Double Tests

	[TestMethod]
	public void CreateDoubleShouldInitializeQuantity()
	{
		double expected = 10.0;
		var length = LengthDouble.Create(expected);
		Assert.AreEqual(expected, length.Quantity);
	}

	[TestMethod]
	public void AddDoubleShouldReturnCorrectResult()
	{
		var length1 = LengthDouble.Create(5.0);
		var length2 = LengthDouble.Create(10.0);
		var result = length1 + length2;
		Assert.AreEqual(15.0, result.Quantity);
	}

	[TestMethod]
	public void SubtractDoubleShouldReturnCorrectResult()
	{
		var length1 = LengthDouble.Create(10.0);
		var length2 = LengthDouble.Create(5.0);
		var result = length1 - length2;
		Assert.AreEqual(5.0, result.Quantity);
	}

	[TestMethod]
	public void NegateDoubleShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(5.0);
		var result = -length;
		Assert.AreEqual(-5.0, result.Quantity);
	}

	[TestMethod]
	public void MultiplyDoubleWithSemanticQuantityShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(5.0);
		var multiplier = SemanticQuantity<double>.Create<LengthDouble>(2.0);
		var result = SemanticQuantity<LengthDouble, double>.Multiply<LengthDouble>(length, multiplier);
		Assert.AreEqual(10.0, result.Quantity);
	}

	[TestMethod]
	public void MultiplyDoubleWithStorageTypeShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(5.0);
		double multiplier = 2.0;
		var result = length * multiplier;
		Assert.AreEqual(10.0, result.Quantity);
	}

	[TestMethod]
	public void DivideDoubleWithSemanticQuantityShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(10.0);
		var divisor = SemanticQuantity<double>.Create<LengthDouble>(2.0);
		var result = SemanticQuantity<LengthDouble, double>.Divide<LengthDouble>(length, divisor);
		Assert.AreEqual(5.0, result.Quantity);
	}

	[TestMethod]
	public void DivideDoubleWithStorageTypeShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(10.0);
		double divisor = 2.0;
		var result = length / divisor;
		Assert.AreEqual(5.0, result.Quantity);
	}

	[TestMethod]
	public void DivideToStorageDoubleShouldReturnCorrectResult()
	{
		var length1 = LengthDouble.Create(10.0);
		var length2 = LengthDouble.Create(2.0);
		double result = length1 / length2;
		Assert.AreEqual(5.0, result);
	}

	#endregion

	#region Int Tests

	[TestMethod]
	public void CreateIntShouldInitializeQuantity()
	{
		int expected = 10;
		var length = LengthInt.Create(expected);
		Assert.AreEqual(expected, length.Quantity);
	}

	[TestMethod]
	public void AddIntShouldReturnCorrectResult()
	{
		var length1 = LengthInt.Create(5);
		var length2 = LengthInt.Create(10);
		var result = length1 + length2;
		Assert.AreEqual(15, result.Quantity);
	}

	[TestMethod]
	public void SubtractIntShouldReturnCorrectResult()
	{
		var length1 = LengthInt.Create(10);
		var length2 = LengthInt.Create(5);
		var result = length1 - length2;
		Assert.AreEqual(5, result.Quantity);
	}

	[TestMethod]
	public void NegateIntShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(5);
		var result = -length;
		Assert.AreEqual(-5, result.Quantity);
	}

	[TestMethod]
	public void MultiplyIntWithSemanticQuantityShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(5);
		var multiplier = SemanticQuantity<int>.Create<LengthInt>(2);
		var result = SemanticQuantity<LengthInt, int>.Multiply<LengthInt>(length, multiplier);
		Assert.AreEqual(10, result.Quantity);
	}

	[TestMethod]
	public void MultiplyIntWithStorageTypeShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(5);
		int multiplier = 2;
		var result = length * multiplier;
		Assert.AreEqual(10, result.Quantity);
	}

	[TestMethod]
	public void DivideIntWithSemanticQuantityShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(10);
		var divisor = SemanticQuantity<int>.Create<LengthInt>(2);
		var result = SemanticQuantity<LengthInt, int>.Divide<LengthInt>(length, divisor);
		Assert.AreEqual(5, result.Quantity);
	}

	[TestMethod]
	public void DivideIntWithStorageTypeShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(10);
		int divisor = 2;
		var result = length / divisor;
		Assert.AreEqual(5, result.Quantity);
	}

	[TestMethod]
	public void DivideToStorageIntShouldReturnCorrectResult()
	{
		var length1 = LengthInt.Create(10);
		var length2 = LengthInt.Create(2);
		int result = length1 / length2;
		Assert.AreEqual(5, result);
	}

	#endregion
}
