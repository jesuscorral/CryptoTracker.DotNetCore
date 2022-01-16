using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptoTracker.API.WebAPI.Features.Trades
{
    [ApiController]
    [Route("[controller]")]
    public class TradesController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TradesController> _logger;

        public TradesController(ILogger<TradesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTrades")]
        public IEnumerable<TradeDTO> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new TradeDTO
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

