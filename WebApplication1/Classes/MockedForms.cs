using Bogus;
using WebApplication1.Models;

namespace WebApplication1.Classes;

#pragma warning disable CS8618
public class MockedForms
{
    public static List<FormType> AvailableFormTypes()
    {
        Randomizer.Seed = new Random(8675309);

        int identifier = 1;
        var fakes = new Faker<FormType>()
            .RuleFor(x => x.Id, f => identifier++)
            .RuleFor(x => x.FormName, f => f.Commerce.ProductName());

        return fakes.Generate(10).ToList();
    }
}