using System;
using System.Collections.Generic;

namespace YrNoXmlWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintWeatherInfo();
            Console.ReadKey();
        }

        private static void PrintWeatherInfo()
        {
            XmlParser xmlParser = new XmlParser();
            List<WeatherInfo> weatherInfoList =
                xmlParser.ParseWeatherXml("https://www.yr.no/place/Estonia/Harjumaa/Tallinn/forecast.xml");
            foreach (var weatherInfo in weatherInfoList)
            {
                Console.WriteLine(weatherInfo);
            }
        }
    }
}