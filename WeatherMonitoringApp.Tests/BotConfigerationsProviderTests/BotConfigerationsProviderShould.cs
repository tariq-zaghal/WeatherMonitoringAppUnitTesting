using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringApp.WeatherBotModels;
using WeatherMonitoringApp.WeatherDataModels;
using Xunit.Abstractions;

namespace WeatherMonitoringApp.Tests
{
    public class BotConfigerationsProviderShould
    {
        [Fact]
        void ProvideWeatherBots_ProvidesAllBots()
        {
            string jsonFileContent = "{\r\n  \"RainBot\": {\r\n    \"enabled\": true,\r\n    \"humidityThreshold\": 70,\r\n    \"message\": \"It looks like it's about to pour down!\"\r\n  },\r\n  \"SunBot\": {\r\n    \"enabled\": true,\r\n    \"temperatureThreshold\": 30,\r\n    \"message\": \"Wow, it's a scorcher out there!\"\r\n  },\r\n  \"SnowBot\": {\r\n    \"enabled\": false,\r\n    \"temperatureThreshold\": 0,\r\n    \"message\": \"Brrr, it's getting chilly!\"\r\n  }\r\n}";

            var sut = new BotConfigerationsProvider();

            sut = BotConfigerationsProvider.ProvideWeatherBots(jsonFileContent);

            Assert.NotNull(sut.RainBot);
            Assert.NotNull(sut.SunBot);
            Assert.NotNull(sut.SnowBot);
        }

        [Fact]
        void ProvideWeatherBots_FailToProvideProvideBots()
        {
            string jsonFileContent = "";
            var sut = new BotConfigerationsProvider();

            sut = BotConfigerationsProvider.ProvideWeatherBots(jsonFileContent);

            Assert.Throws<NullReferenceException>(() => sut.SunBot);
            Assert.Throws<NullReferenceException>(() => sut.SnowBot);
            Assert.Throws<NullReferenceException>(() => sut.RainBot);
        }
    }
}
