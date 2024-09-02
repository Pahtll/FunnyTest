using Calculation.Area.Interfaces;

namespace Calculation.Area.Models;

public class Circle(double radius) : IAreaCalc
{
	private double Radius { get; init; } = radius;
	
	private bool IsRadiusValid() => Radius > 0;
	
	public double CalculateArea()
	{
		if (!IsRadiusValid())
			throw new ArgumentException("Radius must be greater than 0");
		
		return Math.PI * Math.Pow(Radius, 2);
	}
}