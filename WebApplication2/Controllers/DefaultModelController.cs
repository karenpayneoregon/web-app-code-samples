using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[ApiController]
[Route("[controller]")]
public class DefaultModelController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
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

    [HttpGet("GetByName/{name}")]
    public DefaultModel GetByName(string name)
    {
        return new DefaultModel()
        {
            Date = new DateOnly(2023, 7, 4),
            TemperatureC = 80,
            Summary = "Testing"
        };
    }
}
