using InsuranceApi.Controllers;
using Microsoft.Extensions.Logging.Abstractions;

namespace InsuranceApi.Tests.Controllers;

public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsFiveWeatherForecasts()
    {
        // Arrange
        var controller = new WeatherForecastController(
            NullLogger<WeatherForecastController>.Instance);

        // Act
        var result = controller.Get().ToArray();

        // Assert
        Assert.Equal(5, result.Length);
        Assert.All(result, forecast =>
        {
            Assert.NotEqual(default, forecast.Date);
            Assert.InRange(forecast.TemperatureC, -20, 54);
            Assert.False(string.IsNullOrWhiteSpace(forecast.Summary));
        });
    }
}