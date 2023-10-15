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
    public class SunBotShould : BotShould
    {
        [Fact]
        public void GetInfo_BotIsEnabled_ExceedThreshold_ShouldReturnMessage()
        {
            var sut = new SunBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Temperature).Returns(_threshold + _random.Next());

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(_message, output);
        }

        [Fact]
        public void GetInfo_BotIsEnabled_EqualThreshold_ShouldReturnNull()
        {
            var sut = new SunBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Temperature).Returns(_threshold);

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }

        [Fact]
        public void GetInfo_BotIsEnabled_LessThanThreshold_ShouldReturnNull()
        {
            var sut = new SunBot(true, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();
            mockIWeatherData.Setup(w => w.Temperature).Returns(_threshold - _random.Next());

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }

        [Fact]
        public void GetInfo_BotIsNotEnabled_ShouldReturnNull()
        {
            var sut = new SunBot(false, _message, _threshold);

            var mockIWeatherData = new Mock<IWeatherData>();

            string? output = sut.GetInfo(mockIWeatherData.Object);

            Assert.Equal(null, output);
        }
    }
}
