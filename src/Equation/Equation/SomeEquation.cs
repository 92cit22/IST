using System.ComponentModel;

namespace Equation;

public class SomeEquation
{
	public double A           { get; private set; }
	public double B           { get; private set; }
	public double C           { get; private set; }
	public double X           { get; private set; }
	public Type   CurrentType { get; private set; }

	public SomeEquation( double a,
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

	public double Calc()
	{
		switch ( A )
		{
			case < 0 when C != 0:
				CurrentType = Type.Parabola;

				return Parabola();

			case > 0 when C == 0:
				CurrentType = Type.Hyperbola;

				return Hyperbola();

			default:
				CurrentType = Type.Linear;

				return Linear();
		}
	}

	private double Linear() => -A / ( X - C );

	private double Hyperbola() => -A / ( X - C );

	private double Parabola() => A * Math.Pow( X, 2 ) + B + C;

	[ DefaultValue( NotSelect ) ]
	public enum Type : byte
	{
		Linear,
		Hyperbola,
		Parabola,
		NotSelect,
	}
}