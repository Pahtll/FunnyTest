using Calculation.Area.Interfaces;

namespace Calculation.Area.Models;

public class Triangle(
	double firstSide, 
	double secondSide, 
	double thirdSide
	) : IAreaCalc
{
	private IEnumerable<double> Sides { get; init; } = new List<double>
	{
		firstSide,
		secondSide,
		thirdSide
	};

	private bool IsTriangleValid()
	{
		if (Sides.Any(side => side <= 0))
			return false;
		
		return Sides.Sum() - Sides.Max() > Sides.Max();
	}

	private bool IsTriangleSquared() => Sides.Any(side => Math.Abs(side * side - (Sides.Sum() - side)) < 0.0001);
	
	public double CalculateArea()
	{
		if (!IsTriangleValid())
			throw new ArgumentException("Invalid triangle sides");
		
		if (IsTriangleSquared())
			return Sides.Aggregate((current, side) => current * side) / 2;
		
		var semiPerimeter = Sides.Sum() / 2;
		var area = Sides.Aggregate(semiPerimeter, (current, side) => 
			current * (semiPerimeter - side));

		return Math.Sqrt(area);
	}
}