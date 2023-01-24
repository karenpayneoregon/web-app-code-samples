
namespace RazorPagesAJAXNamedHandlersDemo.Repositories;

public interface ILocationRepository
{
    List<string> GetContinents();
    List<string> GetCountries(string continent);
}

public class LocationRepository : ILocationRepository
{
    public List<string> GetContinents()
    {
        return new List<string>()
        {
            "North America",
            "Africa",
            "Asia",
            "Europe"
        };
    }

    public List<string> GetCountries(string continent)
    {
        switch(continent)
        {
            case "North America":
                return new List<string>()
                {
                    "Canada",
                    "Mexico",
                    "United States"
                };

            case "Africa":
                return new List<string>()
                {
                    "Nigeria",
                    "Egypt",
                    "Ethiopia",
                    "Botswana",
                    "Mozambique",
                    "Lesotho"
                };

            case "Asia":
                return new List<string>()
                {
                    "China",
                    "Japan",
                    "India",
                    "Nepal",
                    "Thailand",
                    "Pakistan",
                    "Mongolia"
                };

            case "Europe":
                return new List<string>()
                {
                    "Great Britain",
                    "Germany",
                    "Poland",
                    "Czechia",
                    "Italy",
                    "Serbia",
                    "Romania",
                    "Spain",
                    "France",
                    "Sweden",
                    "Estonia"
                };
            default:
                return new List<string>();
        }
    }
}