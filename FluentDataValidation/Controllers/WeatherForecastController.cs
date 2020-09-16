using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentDataValidation.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FluentDataValidation.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            var res = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                // Summary = Summaries[rng.Next(Summaries.Length)]
                Summary = ""
            })
            .ToArray();

            //Manual way of validating the model
            //var validator = new WeatherForecastValidator();

            //foreach (var a in res)
            //{
            //    var results = validator.Validate(a);
            //}
            return res;
        }

        [HttpPost]
        public ActionResult POST(WeatherForecast a)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("something wrong!");
            }
            return Ok();
        }
    }
}
