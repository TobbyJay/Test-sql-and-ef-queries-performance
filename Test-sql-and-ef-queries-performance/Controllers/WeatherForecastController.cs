using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test_sql_and_ef_queries_performance.Data;

namespace Test_sql_and_ef_queries_performance.Controllers
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
		private AppDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
		public IActionResult Get()
		{
			//return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			//{
			//	Date = DateTime.Now.AddDays(index),
			//	TemperatureC = Random.Shared.Next(-20, 55),
			//	Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			//})
			//.ToArray();

			const int Iterations = 100;
			var sw = new Stopwatch();

			sw.Start();
            for (int i = 0; i < Iterations; i++)
            {
				var customers = _context.Customers.FromSqlRaw(@"SELECT c.Id,c.Name, COUNT(o.Id) AS OrderCount FROM Customers c LEFT JOIN Orders o ON o.Id = c.Id GROUP BY c.Id, c.Name").ToList();
            }

			sw.Stop();
            return Ok($"Raw SQL query {sw.ElapsedMilliseconds} ms");
		}
	}
}