namespace FeatureFlagTutorial
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }       

        public string? Summary { get; set; }
        
        //New Feature
        public int? TemperatureF { get; set; }

    }
}