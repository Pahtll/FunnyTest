using Calculation.Area.Models;
using Xunit;

namespace Calculation.Area.Tests;

public class AreaCalcTest
{
	[Fact]
	public void CalculateArea_Triangle_ValidSides_ReturnsCorrectArea()
	{
		var triangle = new Triangle(3, 4, 5);

		var area = triangle.CalculateArea();

		Assert.Equal(6, area, precision: 5);
	}

	[Fact]
	public void CalculateArea_Triangle_InvalidSides_ThrowsArgumentException()
	{
		var triangle = new Triangle(1, 1, 10);

		Assert.Throws<ArgumentException>(() => triangle.CalculateArea());
	}

	[Fact]
	public void CalculateArea_Circle_ValidRadius_ReturnsCorrectArea()
	{
		var circle = new Circle(3);

		var area = circle.CalculateArea();

		Assert.Equal(Math.PI * 9, area, precision: 5);
	}

	[Fact]
	public void CalculateArea_Circle_InvalidRadius_ThrowsArgumentException()
	{
		var circle = new Circle(-1);

		Assert.Throws<ArgumentException>(() => circle.CalculateArea());
	}
}