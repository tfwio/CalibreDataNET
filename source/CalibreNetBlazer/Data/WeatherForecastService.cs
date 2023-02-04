using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalibreNetBlazer.Data
{
  public class WeatherForecastService
  {
    private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };


    public Task<List<NodeRow>> GetBookInfoService()
    {
         return Task.FromResult(JSONLoader.JsonIndex111("e:/serve/book/non-fiction/metadata.db", false));
    }
//{
//"libroot":"e:/serve/book",
//"imgroot":"e:/serve/book-cover",
//	"dirs": [
//		"Artwork",
//		"Channel9",
//		"Codex",
//		"Dev",
//		"Do",
//		"Ebook",
//		"Fiction",
//		"Free Masonic",
//		"Images",
//		"Mag",
//		"Mathematics",
//		"Mediumship and Divination",
//		"Music",
//		"New",
//		"Non-Fiction",
//		"She",
//		"SSOC",
//		"Theology",
//		"Unicorns and Rainbows"
//	]
//    }
    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
      var rng = new Random();
      return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = startDate.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      }).ToArray());
    }
  }
}
