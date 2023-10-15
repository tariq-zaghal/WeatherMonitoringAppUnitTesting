using Moq;
using WeatherMonitoringApp.WeatherBotModels;
using WeatherMonitoringApp.WeatherDataModels;

namespace WeatherMonitoringApp.Tests.BotTests
{
    public class RainBotShould : BotShould
    {
        [Fact]
        public void GetInfo_BotIsEnabled_ExceedThreshold_ShouldReturnMessage()
        {
            var sut = new RainBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Humidity).Returns(_threshold + _random.Next());

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(_message, output);
        }

        [Fact]
        public void GetInfo_BotIsEnabled_EqualThreshold_ShouldReturnNull()
        {
            var sut = new RainBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Humidity).Returns(_threshold);

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }

        [Fact]
        public void GetInfo_BotIsEnabled_LessThanThreshold_ShouldReturnNull()
        {
            var sut = new RainBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Humidity).Returns(_threshold - new Random().Next());

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }

        [Fact]
        public void GetInfo_BotIsNotEnabled_ShouldReturnNull()
        {
            var sut = new RainBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }
    }
}