using Bogus;

namespace SimpleModelBinding.Models;

public class Person
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Age { get; set; }
    public string City { get; set; }
    public bool IsActive { get; set; } = true;
}

public class BogusOperations
{
    public static List<Person> People(int count = 1)
    {
        var fakePerson = new Faker<Person>()
            .RuleFor(c => c.Name, f => f.Person.FirstName)
            .RuleFor(c => c.SurName, f => f.Person.LastName)
            .RuleFor(c => c.City, f => f.Address.City())
            .RuleFor(c => c.Age, f => f.Random.Number(8, 90).ToString());

        return fakePerson.Generate(count);

    }
}
