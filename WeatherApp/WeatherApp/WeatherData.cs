using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class WeatherData
    {
        public ForecastData[] Forecast { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Temperature { get; set; }
    }
}
