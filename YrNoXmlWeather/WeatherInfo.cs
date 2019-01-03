using System;

namespace YrNoXmlWeather
{
    class WeatherInfo
    {
        public DateTime MeasurementTime { get; set; }
        public string WeatherDescription { get; set; }
        public int DegreesCelsius { get; set; }
        public string Precipitation { get; set; }
        public string WindDirection { get; set; }
        public double WindSpeed { get; set; }

        public override string ToString()
        {
            return $"Day: {MeasurementTime.DayOfWeek} {MeasurementTime:dd/MM/yyyy}" +
                   $"\nDescription: {WeatherDescription}" +
                   $"\nDegrees Celsius: {DegreesCelsius}" +
                   $"\nPrecipitation: {Precipitation}" +
                   $"\nWind direction: {WindDirection}" +
                   $"\nWind speed: {convertMphToKmh(WindSpeed):0.0} km/h" +
                   $"\n";
        }

        private double convertMphToKmh(double mphSpeed)
        {
            return mphSpeed * 1.61;
        }
    }
}