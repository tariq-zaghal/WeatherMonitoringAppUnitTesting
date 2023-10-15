using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringApp.WeatherBotModels;
using WeatherMonitoringApp.WeatherDataModels;

namespace WeatherMonitoringApp.Tests.BotTests
{
    public class SnowBotShould : BotShould
    {
        [Fact]
        public void GetInfo_BotIsEnabled_LessThanThreshold_ShouldReturnMessage()
        {
            var sut = new SnowBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Temperature).Returns(_threshold - _random.Next());

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(_message, output);
        }

        [Fact]
        public void GetInfo_BotIsEnabled_EqualThreshold_ShouldReturnNull()
        {
            var sut = new SnowBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Temperature).Returns(_threshold);

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }

        [Fact]
        public void GetInfo_BotIsEnabled_ExceedThreshold_ShouldReturnNull()
        {
            var sut = new SnowBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Temperature).Returns(_threshold + _random.Next());

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }

        [Fact]
        public void GetInfo_BotIsNotEnabled_ShouldReturnNull()
        {
            var sut = new SnowBot(false, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }
    }
}
