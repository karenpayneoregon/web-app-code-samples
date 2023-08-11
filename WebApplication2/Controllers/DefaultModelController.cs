using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[ApiController]
[Route("[controller]")]
public class DefaultModelController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching!!!"
    };


    [HttpGet(Name = "DefaultModelController.")]
    public IEnumerable<DefaultModel> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new DefaultModel
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
    }


    [HttpGet("GetById/{Id}")]
    public DefaultModel GetById(int id)
    {
        return new DefaultModel()
        {
            Date = new DateOnly(2023, 7, 4),
            TemperatureC = 80,
            Summary = "Testing"
        };
    }

    [HttpGet("GetByName/{summary}")]
    public DefaultModel GetByName(string summary)
    {
        List<DefaultModel> list = new List<DefaultModel>
        {
            new() { Date = new DateOnly(2023, 6, 4), TemperatureC = 81, Summary = "A" },
            new() { Date = new DateOnly(2023, 7, 4), TemperatureC = 82, Summary = "B" },
            new() { Date = new DateOnly(2023, 8, 4), TemperatureC = 83, Summary = "C" }
        };
        return list.FirstOrDefault(x => x.Summary == summary)!;
    }
}
