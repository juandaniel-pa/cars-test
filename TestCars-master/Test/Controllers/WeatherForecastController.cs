using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICars _cars;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICars cars)
        {
            _logger = logger;
            _cars = cars;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("EnterCar")]
        public async Task<IActionResult> EnterCar(string placa)
        {
            await _cars.EnterCar(placa);
            return Ok("Vehiculo Registrado con Exito");

        }

        [HttpPost("LeaveCar")]
        public async Task<IActionResult> LeaveCar(string placa)
        {
            await _cars.LeaveCar(placa);
            return Ok("Salida de Vehiculo Registrado con Exito");

        }

        [HttpPost("ToOficial")]
        public async Task<IActionResult> UpgradeCartoOficial(string placa)
        {
            await _cars.UpgradeCarOficial(placa);
            return Ok("Actualizado a Oficial con Exito");

        }

        [HttpPost("ToResident")]
        public async Task<IActionResult> UpgradeCartoResident(string placa)
        {
            await _cars.UpgradeCarResident(placa);
            return Ok("Actualizado a Oficial con Exito");

        }

        [HttpGet("GetPay")]
        public async Task<IActionResult> GetPayment()
        {
            var response = await _cars.GetPayStatuts();
            return Ok(response);

        }

    }
}
