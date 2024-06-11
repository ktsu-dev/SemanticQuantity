namespace Test;

using System.Numerics;
using ktsu.io.SemanticQuantity;

public record LengthBigInt : SemanticQuantity<LengthBigInt, BigInteger>;
public record LengthFloat : SemanticQuantity<LengthFloat, float>;
public record LengthDouble : SemanticQuantity<LengthDouble, double>;
public record LengthInt : SemanticQuantity<LengthInt, int>;

[TestClass]
public class AITests
{
	#region BigInteger Tests

	[TestMethod]
	public void CreateBigInt_ShouldInitializeQuantity()
	{
		var expected = new BigInteger(10);
		var length = LengthBigInt.Create(expected);
		Assert.AreEqual(expected, length.Quantity);
	}

	[TestMethod]
	public void AddBigInt_ShouldReturnCorrectResult()
	{
		var length1 = LengthBigInt.Create(new BigInteger(5));
		var length2 = LengthBigInt.Create(new BigInteger(10));
		var result = length1 + length2;
		Assert.AreEqual(new BigInteger(15), result.Quantity);
	}

	[TestMethod]
	public void SubtractBigInt_ShouldReturnCorrectResult()
	{
		var length1 = LengthBigInt.Create(new BigInteger(10));
		var length2 = LengthBigInt.Create(new BigInteger(5));
		var result = length1 - length2;
		Assert.AreEqual(new BigInteger(5), result.Quantity);
	}

	[TestMethod]
	public void NegateBigInt_ShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(5));
		var result = -length;
		Assert.AreEqual(new BigInteger(-5), result.Quantity);
	}

	[TestMethod]
	public void MultiplyBigInt_WithSemanticQuantity_ShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(5));
		var multiplier = SemanticQuantity<BigInteger>.Create<LengthBigInt>(new BigInteger(2));
		var result = SemanticQuantity<LengthBigInt, BigInteger>.Multiply<LengthBigInt>(length, multiplier);
		Assert.AreEqual(new BigInteger(10), result.Quantity);
	}

	[TestMethod]
	public void MultiplyBigInt_WithStorageType_ShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(5));
		var multiplier = new BigInteger(2);
		var result = length * multiplier;
		Assert.AreEqual(new BigInteger(10), result.Quantity);
	}

	[TestMethod]
	public void DivideBigInt_WithSemanticQuantity_ShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(10));
		var divisor = SemanticQuantity<BigInteger>.Create<LengthBigInt>(new BigInteger(2));
		var result = SemanticQuantity<LengthBigInt, BigInteger>.Divide<LengthBigInt>(length, divisor);
		Assert.AreEqual(new BigInteger(5), result.Quantity);
	}

	[TestMethod]
	public void DivideBigInt_WithStorageType_ShouldReturnCorrectResult()
	{
		var length = LengthBigInt.Create(new BigInteger(10));
		var divisor = new BigInteger(2);
		var result = length / divisor;
		Assert.AreEqual(new BigInteger(5), result.Quantity);
	}

	[TestMethod]
	public void DivideToStorageBigInt_ShouldReturnCorrectResult()
	{
		var length1 = LengthBigInt.Create(new BigInteger(10));
		var length2 = LengthBigInt.Create(new BigInteger(2));
		var result = length1 / length2;
		Assert.AreEqual(new BigInteger(5), result);
	}

	#endregion

	#region Float Tests

	[TestMethod]
	public void CreateFloat_ShouldInitializeQuantity()
	{
		float expected = 10f;
		var length = LengthFloat.Create(expected);
		Assert.AreEqual(expected, length.Quantity);
	}

	[TestMethod]
	public void AddFloat_ShouldReturnCorrectResult()
	{
		var length1 = LengthFloat.Create(5f);
		var length2 = LengthFloat.Create(10f);
		var result = length1 + length2;
		Assert.AreEqual(15f, result.Quantity);
	}

	[TestMethod]
	public void SubtractFloat_ShouldReturnCorrectResult()
	{
		var length1 = LengthFloat.Create(10f);
		var length2 = LengthFloat.Create(5f);
		var result = length1 - length2;
		Assert.AreEqual(5f, result.Quantity);
	}

	[TestMethod]
	public void NegateFloat_ShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(5f);
		var result = -length;
		Assert.AreEqual(-5f, result.Quantity);
	}

	[TestMethod]
	public void MultiplyFloat_WithSemanticQuantity_ShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(5f);
		var multiplier = SemanticQuantity<float>.Create<LengthFloat>(2f);
		var result = SemanticQuantity<LengthFloat, float>.Multiply<LengthFloat>(length, multiplier);
		Assert.AreEqual(10f, result.Quantity);
	}

	[TestMethod]
	public void MultiplyFloat_WithStorageType_ShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(5f);
		float multiplier = 2f;
		var result = length * multiplier;
		Assert.AreEqual(10f, result.Quantity);
	}

	[TestMethod]
	public void DivideFloat_WithSemanticQuantity_ShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(10f);
		var divisor = SemanticQuantity<float>.Create<LengthFloat>(2f);
		var result = SemanticQuantity<LengthFloat, float>.Divide<LengthFloat>(length, divisor);
		Assert.AreEqual(5f, result.Quantity);
	}

	[TestMethod]
	public void DivideFloat_WithStorageType_ShouldReturnCorrectResult()
	{
		var length = LengthFloat.Create(10f);
		float divisor = 2f;
		var result = length / divisor;
		Assert.AreEqual(5f, result.Quantity);
	}

	[TestMethod]
	public void DivideToStorageFloat_ShouldReturnCorrectResult()
	{
		var length1 = LengthFloat.Create(10f);
		var length2 = LengthFloat.Create(2f);
		float result = length1 / length2;
		Assert.AreEqual(5f, result);
	}

	#endregion

	#region Double Tests

	[TestMethod]
	public void CreateDouble_ShouldInitializeQuantity()
	{
		double expected = 10.0;
		var length = LengthDouble.Create(expected);
		Assert.AreEqual(expected, length.Quantity);
	}

	[TestMethod]
	public void AddDouble_ShouldReturnCorrectResult()
	{
		var length1 = LengthDouble.Create(5.0);
		var length2 = LengthDouble.Create(10.0);
		var result = length1 + length2;
		Assert.AreEqual(15.0, result.Quantity);
	}

	[TestMethod]
	public void SubtractDouble_ShouldReturnCorrectResult()
	{
		var length1 = LengthDouble.Create(10.0);
		var length2 = LengthDouble.Create(5.0);
		var result = length1 - length2;
		Assert.AreEqual(5.0, result.Quantity);
	}

	[TestMethod]
	public void NegateDouble_ShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(5.0);
		var result = -length;
		Assert.AreEqual(-5.0, result.Quantity);
	}

	[TestMethod]
	public void MultiplyDouble_WithSemanticQuantity_ShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(5.0);
		var multiplier = SemanticQuantity<double>.Create<LengthDouble>(2.0);
		var result = SemanticQuantity<LengthDouble, double>.Multiply<LengthDouble>(length, multiplier);
		Assert.AreEqual(10.0, result.Quantity);
	}

	[TestMethod]
	public void MultiplyDouble_WithStorageType_ShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(5.0);
		double multiplier = 2.0;
		var result = length * multiplier;
		Assert.AreEqual(10.0, result.Quantity);
	}

	[TestMethod]
	public void DivideDouble_WithSemanticQuantity_ShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(10.0);
		var divisor = SemanticQuantity<double>.Create<LengthDouble>(2.0);
		var result = SemanticQuantity<LengthDouble, double>.Divide<LengthDouble>(length, divisor);
		Assert.AreEqual(5.0, result.Quantity);
	}

	[TestMethod]
	public void DivideDouble_WithStorageType_ShouldReturnCorrectResult()
	{
		var length = LengthDouble.Create(10.0);
		double divisor = 2.0;
		var result = length / divisor;
		Assert.AreEqual(5.0, result.Quantity);
	}

	[TestMethod]
	public void DivideToStorageDouble_ShouldReturnCorrectResult()
	{
		var length1 = LengthDouble.Create(10.0);
		var length2 = LengthDouble.Create(2.0);
		double result = length1 / length2;
		Assert.AreEqual(5.0, result);
	}

	#endregion

	#region Int Tests

	[TestMethod]
	public void CreateInt_ShouldInitializeQuantity()
	{
		int expected = 10;
		var length = LengthInt.Create(expected);
		Assert.AreEqual(expected, length.Quantity);
	}

	[TestMethod]
	public void AddInt_ShouldReturnCorrectResult()
	{
		var length1 = LengthInt.Create(5);
		var length2 = LengthInt.Create(10);
		var result = length1 + length2;
		Assert.AreEqual(15, result.Quantity);
	}

	[TestMethod]
	public void SubtractInt_ShouldReturnCorrectResult()
	{
		var length1 = LengthInt.Create(10);
		var length2 = LengthInt.Create(5);
		var result = length1 - length2;
		Assert.AreEqual(5, result.Quantity);
	}

	[TestMethod]
	public void NegateInt_ShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(5);
		var result = -length;
		Assert.AreEqual(-5, result.Quantity);
	}

	[TestMethod]
	public void MultiplyInt_WithSemanticQuantity_ShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(5);
		var multiplier = SemanticQuantity<int>.Create<LengthInt>(2);
		var result = SemanticQuantity<LengthInt, int>.Multiply<LengthInt>(length, multiplier);
		Assert.AreEqual(10, result.Quantity);
	}

	[TestMethod]
	public void MultiplyInt_WithStorageType_ShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(5);
		int multiplier = 2;
		var result = length * multiplier;
		Assert.AreEqual(10, result.Quantity);
	}

	[TestMethod]
	public void DivideInt_WithSemanticQuantity_ShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(10);
		var divisor = SemanticQuantity<int>.Create<LengthInt>(2);
		var result = SemanticQuantity<LengthInt, int>.Divide<LengthInt>(length, divisor);
		Assert.AreEqual(5, result.Quantity);
	}

	[TestMethod]
	public void DivideInt_WithStorageType_ShouldReturnCorrectResult()
	{
		var length = LengthInt.Create(10);
		int divisor = 2;
		var result = length / divisor;
		Assert.AreEqual(5, result.Quantity);
	}

	[TestMethod]
	public void DivideToStorageInt_ShouldReturnCorrectResult()
	{
		var length1 = LengthInt.Create(10);
		var length2 = LengthInt.Create(2);
		int result = length1 / length2;
		Assert.AreEqual(5, result);
	}

	#endregion
}
