using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringApp.Tests.BotTests
{
    public class BotShould
    {
        protected Random _random;
        protected string _message;
        protected decimal _threshold;

        public BotShould()
        {
            _random = new Random();
            _message = "message";
            _threshold = _random.Next();
        }
    }
}
