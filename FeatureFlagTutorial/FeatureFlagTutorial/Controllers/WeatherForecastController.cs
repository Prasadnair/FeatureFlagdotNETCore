using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlagTutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

       
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFeatureManager _featureManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IFeatureManager featureManager )
        {
            _logger = logger;
            this._featureManager = featureManager;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            //Feature Flag - this needs to be configure in AppSettings.json
            var isTemperatureFEnabled = await _featureManager.IsEnabledAsync("TemperatureF");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                //check whether the Feature Flag is enabled
                TemperatureF = isTemperatureFEnabled ? (int) (Random.Shared.Next(-20, 55) * 1.8) + 32 : null,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("newfeature")]
        [FeatureGate("NewFeature")]
       public async Task<IEnumerable<WeatherForecast>> GetNewFeature()
        {
            //Feature Flag - this needs to be configure in AppSettings.json
            var isTemperatureFEnabled = await _featureManager.IsEnabledAsync("TemperatureF");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                //check whether the Feature Flag is enabled
                TemperatureF = isTemperatureFEnabled ? (int)(Random.Shared.Next(-20, 55) * 1.8) + 32 : null,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}