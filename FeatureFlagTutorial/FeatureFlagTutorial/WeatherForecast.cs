namespace FeatureFlagTutorial
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }       

        public string? Summary { get; set; }
        
        //New Feature
        public int? TemperatureF { get; set; }

        //New Feature for advanced Advanced feature flag
        public string? SnowPercentage { get; set; } 

    }
}