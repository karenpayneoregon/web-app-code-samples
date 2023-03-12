using Microsoft.AspNetCore.Mvc;

namespace LinkGenerator1.Controllers;
public class ValuesController : Controller
{

    [HttpGet("GetValue")]
    public IEnumerable<string> GetValue()
    {
        return new[] { "value1", "value2" };
    }
}
