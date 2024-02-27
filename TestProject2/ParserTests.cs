using FluentAssertions;
using TestProject2.App;

namespace TestProject2;

public class ParserTests
{
    [Fact]
    public void Example_data_1_Test()
    {
        var result = Parser.Deserialize(Constants.ExampleData1_json, o => new BasePolicy
        {
            Insurer = new Person { Name = $"{o.Insurer.FirstName} {o.Insurer.LastName}" },
            Vehicle = new Vehicle { MarkName = o.Vehicle.Mark, ModelName = o.Vehicle.Model },
            AcceptationDate = DateTime.Parse(o.DateBegin.ToString()),
            ExpirationDate = DateTime.Parse(o.DateEnd.ToString()),
        });

        result.Should().BeEquivalentTo(Constants.ExampleData1Result);

    }

    [Fact]
    public void Example_data_1_collection_Test()
    {
        var result = Parser.DeserializeCollection(Constants.ExampleData1_Collection_json, o => new BasePolicy
        {
            Insurer = new Person { Name = $"{o.Insurer.FirstName} {o.Insurer.LastName}" },
            Vehicle = new Vehicle { MarkName = o.Vehicle.Mark, ModelName = o.Vehicle.Model },
            AcceptationDate = DateTime.Parse(o.DateBegin.ToString()),
            ExpirationDate = DateTime.Parse(o.DateEnd.ToString()),
        });

        result.Should().BeEquivalentTo(Constants.ExampleData1_CollectionResult);
    }

    [Fact]
    public void Example_data_2_Test()
    {
        var result = Parser.Deserialize(Constants.ExampleData2_json, o => new BasePolicy
        {
            Insurer = new Person { Name = $"{o.InsurerFirstName} {o.InsurerLastName}" },
            Vehicle = new Vehicle { MarkName = o.Vehicle.Mark, ModelName = o.Vehicle.Model },
            AcceptationDate = DateTime.Parse(o.EffectiveDate.ToString()),
            ExpirationDate = DateTime.Parse(o.ExpirationDate.ToString()),
        });

        result.Should().BeEquivalentTo(Constants.ExampleData1Result);
    }

    [Fact]
    public void Example_data_3_Test()
    {
        var result = Parser.Deserialize(Constants.ExampleData3_json, o => new BasePolicy
        {
            Insurer = new Person { Name = $"{o.Insurer.Person.InsurerFirstName} {o.Insurer.Person.InsurerLastName}" },
            Vehicle = new Vehicle { MarkName = o.VehicleMark, ModelName = o.VehicleModel },
            AcceptationDate = DateTime.Parse(o.DateBegin.ToString()),
            ExpirationDate = DateTime.Parse(o.DateEnd.ToString()),
        });

        result.Should().BeEquivalentTo(Constants.ExampleData1Result);
    }

}