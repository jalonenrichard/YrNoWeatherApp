using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace YrNoXmlWeather
{
    class XmlParser
    {
        public List<WeatherInfo> ParseWeatherXml(string url)
        {
            List<WeatherInfo> weatherInfoList = new List<WeatherInfo>();
            try
            {
                XElement xElement = XElement.Load(url);
                foreach (var forecastElement in xElement.Element("forecast")?.Elements())
                {
                    foreach (var timeElement in forecastElement.Elements())
                    {
                        if ((string) timeElement.Attribute("period") == "2")
                        {
                            WeatherInfo weatherInfo = new WeatherInfo();

                            weatherInfo.MeasurementTime = getDateFromString(timeElement.Attribute("from")?.Value);

                            foreach (var timeChildren in timeElement.Elements())
                            {
                                if (timeChildren.Name == "symbol")
                                    weatherInfo.WeatherDescription = timeChildren.Attribute("name")?.Value;
                                if (timeChildren.Name == "precipitation")
                                    weatherInfo.Precipitation = timeChildren.Attribute("value")?.Value;
                                if (timeChildren.Name == "windDirection")
                                    weatherInfo.WindDirection = timeChildren.Attribute("name")?.Value;
                                if (timeChildren.Name == "windSpeed")
                                    weatherInfo.WindSpeed = double.Parse(
                                        timeChildren.Attribute("mps")?.Value ?? throw new InvalidOperationException(),
                                        System.Globalization.CultureInfo.InvariantCulture);
                                if (timeChildren.Name == "temperature")
                                    weatherInfo.DegreesCelsius =
                                        int.Parse(timeChildren.Attribute("value")?.Value ??
                                                  throw new InvalidOperationException());
                            }

                            weatherInfoList.Add(weatherInfo);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }

            return weatherInfoList;
        }

        private DateTime getDateFromString(string dateString)
        {
            DateTime d;
            DateTime.TryParseExact(dateString, "yyyy-MM-ddTHH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out d);
            return d;
        }
    }
}