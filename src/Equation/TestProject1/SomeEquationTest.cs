using System;
using Equation;
using Xunit;

namespace TestProject1;

public class SomeEquationTest
{
	private static int GreaterZero => new Random().Next( 100 );
	private static int LessZero    => -new Random().Next( 100 );
	private const  int Zero = 0;

	[ Fact ]
	public void AGreaterZeroCNotEqualZero()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var equation = new SomeEquation( GreaterZero,
										 GreaterZero,
										 GreaterZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}
	[ Fact ]
	public void AGreaterZeroCEqualZero()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Hyperbola;

		var equation = new SomeEquation( GreaterZero,
										 GreaterZero,
										 Zero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}
	[ Fact ]
	public void ALessZeroCNotEqualZero()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Parabola;

		var equation = new SomeEquation( LessZero,
										 GreaterZero,
										 GreaterZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}
	[ Fact ]
	public void ALessZeroCEqualZero()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var equation = new SomeEquation( LessZero,
										 GreaterZero,
										 Zero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}
	[ Fact ]
	public void AEqualZeroCNotEqualZero()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var equation = new SomeEquation( Zero,
										 GreaterZero,
										 GreaterZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}
	[ Fact ]
	public void AEqualZeroCEqualZero()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var equation = new SomeEquation( Zero,
										 GreaterZero,
										 Zero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}
}