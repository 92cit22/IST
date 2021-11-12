using System;
using AutoFixture;
using Equation;
using Moq;
using Xunit;
using Range = Moq.Range;

namespace TestProject1;

public class SomeEquationTest
{
	private struct Squad
	{
		public double A;
		public double B;
		public double C;
		public double X;

		public Squad( double a,
					  double b,
					  double c,
					  double x
			)
		{
			A = a;
			B = b;
			C = c;
			X = x;
		}
	}

	private const  int EqualZero = 0;
	private static int NotEqualZero    => new Random().Next( -100, 100 );
	private static int GreaterZero => new Random().Next(1, 100 );
	private static int LessZero    => new Random().Next( -100,1);

	[ Fact ]
	public void NotCalculateTypeTest()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var squad = new Squad( GreaterZero,
							   GreaterZero,
							   GreaterZero,
							   GreaterZero
							 );

		var equation = new SomeEquation( squad.A,
										 squad.B,
										 squad.C,
										 squad.X
									   );

		// Act
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void AGreaterZeroCNotEqualZeroTypeTest()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var equation = new SomeEquation( GreaterZero,
										 GreaterZero,
										 NotEqualZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void AGreaterZeroCNotEqualZeroValueTest()
	{
		// Arrange
		var squad = new Squad( GreaterZero,
							   GreaterZero,
							   NotEqualZero,
							   GreaterZero
							 );

		var expected = squad.A * ( squad.X + squad.C );

		var equation = new SomeEquation( squad.A,
										 squad.B,
										 squad.C,
										 squad.X
									   );

		// Act
		var actual = equation.Calc();

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void AGreaterZeroCEqualZeroTypeTest()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Hyperbola;

		var equation = new SomeEquation( GreaterZero,
										 GreaterZero,
										 EqualZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void AGreaterZeroCEqualZeroValueTest()
	{
		// Arrange
		var squad = new Squad( GreaterZero,
							   GreaterZero,
							   EqualZero,
							   GreaterZero
							 );

		var expected = -squad.A / ( squad.X - squad.C );

		var equation = new SomeEquation( squad.A,
										 squad.B,
										 squad.C,
										 squad.X
									   );

		// Act
		var actual = equation.Calc();

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void ALessZeroCNotEqualZeroTypeTest()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Parabola;

		var equation = new SomeEquation( LessZero,
										 GreaterZero,
										 NotEqualZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void ALessZeroCNotEqualZeroValueTest()
	{
		// Arrange
		var squad = new Squad( LessZero,
							   GreaterZero,
							   NotEqualZero,
							   GreaterZero
							 );

		var expected = squad.A * Math.Pow( squad.X, 2 ) + squad.B + squad.C;

		var equation = new SomeEquation( squad.A,
										 squad.B,
										 squad.C,
										 squad.X
									   );

		// Act
		var actual = equation.Calc();

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void ALessZeroCEqualZeroTypeTest()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var equation = new SomeEquation( LessZero,
										 GreaterZero,
										 EqualZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void ALessZeroCEqualZeroValueTest()
	{
		// Arrange
		var squad = new Squad( LessZero,
							   GreaterZero,
							   EqualZero,
							   GreaterZero
							 );

		var expected = squad.A * ( squad.X + squad.C );

		var equation = new SomeEquation( squad.A,
										 squad.B,
										 squad.C,
										 squad.X
									   );

		// Act
		var actual = equation.Calc();

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void AEqualZeroCNotEqualZeroTypeTest()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var equation = new SomeEquation( EqualZero,
										 GreaterZero,
										 NotEqualZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void AEqualZeroCNotEqualZeroValueTest()
	{
		// Arrange
		var squad = new Squad( EqualZero,
							   GreaterZero,
							   NotEqualZero,
							   GreaterZero
							 );

		var expected = squad.A * ( squad.X + squad.C );

		var equation = new SomeEquation( squad.A,
										 squad.B,
										 squad.C,
										 squad.X
									   );

		// Act
		var actual = equation.Calc();

		// Assert
		Assert.Equal( expected, actual );
	}

	[ Fact ]
	public void AEqualZeroCEqualZeroTypeTest()
	{
		// Arrange
		const SomeEquation.Type expected = SomeEquation.Type.Linear;

		var equation = new SomeEquation( EqualZero,
										 GreaterZero,
										 EqualZero,
										 GreaterZero
									   );

		// Act
		equation.Calc();
		var actual = equation.CurrentType;

		// Assert
		Assert.Equal( expected, actual );
	}
	
	[ Fact ]
	public void AEqualZeroCEqualZeroValueTest()
	{
		// Arrange
		var squad = new Squad( EqualZero,
							   GreaterZero,
							   EqualZero,
							   GreaterZero
							 );

		var expected = squad.A * ( squad.X + squad.C );

		var equation = new SomeEquation( squad.A,
										 squad.B,
										 squad.C,
										 squad.X
									   );

		// Act
		var actual = equation.Calc();

		// Assert
		Assert.Equal( expected, actual );
	}

}