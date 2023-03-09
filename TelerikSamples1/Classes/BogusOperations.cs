using Bogus;
using TelerikSamples1.Models;
using Person = TelerikSamples1.Models.Person;

namespace TelerikSamples1.Classes;

public class BogusOperations
{
    public static List<Person> People(int count = 10)
    {
        int identifier = 1;
            
        Faker<Person> fakePerson = new Faker<Person>()
                .CustomInstantiator(f => new Person(identifier++))
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.BirthDate, f => f.Date.Past(10));
        
        return fakePerson.Generate(count);

    }

    public static List<Country> Countries(int count = 100)
    {
        int identifier = 1;

        Faker<Country> fakeCountry = new Faker<Country>()
                .CustomInstantiator(f => new Country(identifier++))
                .RuleFor(p => p.Text, f => f.Address.Country());

        return fakeCountry.Generate(count).OrderBy(x => x.Text).DistinctBy(x => x.Text).ToList();
    }
}