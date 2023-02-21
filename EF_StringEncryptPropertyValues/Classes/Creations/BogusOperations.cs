using Bogus;
using EF_StringEncryptPropertyValues.Models;

namespace EF_StringEncryptPropertyValues.Classes.Creations;
internal class BogusOperations
{
    public static List<User> MockedUsers(int count = 10)
    {
        Faker<User> fakeTaxpayer = new Faker<User>()
            .RuleFor(t => t.Name, f =>
                f.Person.FirstName)

            .RuleFor(t => t.Password, f =>
                f.Internet.Password());


        return fakeTaxpayer.Generate(count);
    }
}
