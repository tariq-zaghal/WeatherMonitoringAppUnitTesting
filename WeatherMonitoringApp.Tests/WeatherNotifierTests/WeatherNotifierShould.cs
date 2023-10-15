using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringApp.WeatherBotModels;
using WeatherMonitoringApp.WeatherDataModels;
using WeatherMonitoringApp.WeatherNotifierModels;

namespace WeatherMonitoringApp.Tests.WeatherNotifierTests
{
    public class WeatherNotifierShould
    {
        public WeatherNotifierShould() { }

        [Fact]
        void NotifyBot_AllBotsActive_AllBotsNotify_ReturnsListOfAllMessages()
        {
            var botConfigerationsProviderMock = new Mock<IBotConfigerationsProvider>();

            var snowMessage = "snow message";
            var sunMessage = "sun message";
            var rainMessage = "rain message";

            botConfigerationsProviderMock.Setup(x => x.SnowBot.GetInfo(It.IsAny<IWeatherData>())).Returns(snowMessage);
            botConfigerationsProviderMock.Setup(x => x.SunBot.GetInfo(It.IsAny<IWeatherData>())).Returns(sunMessage);
            botConfigerationsProviderMock.Setup(x => x.RainBot.GetInfo(It.IsAny<IWeatherData>())).Returns(rainMessage);

            var weatherDataMock = new Mock<IWeatherData>();

            var sut = new WeatherNotifier(botConfigerationsProviderMock.Object);

            var Notifications = sut.NotifyBots(weatherDataMock.Object);

            Assert.Equal(3, Notifications.Count);
            Assert.Contains(snowMessage, Notifications);
            Assert.Contains(sunMessage, Notifications);
            Assert.Contains(rainMessage, Notifications);
        }
    }
}
