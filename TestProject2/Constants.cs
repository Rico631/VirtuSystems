using TestProject2.App;

namespace TestProject2;
internal static class Constants
{
    public const string ExampleData1_json =
        @"{
          ""Insurer"": {
            ""FirstName"": ""Петрищенко"",
            ""LastName"": ""Федор""
          },
          ""Vehicle"": {
            ""Mark"": ""Volvo"",
            ""Model"": ""XC90""
          },
          ""DateBegin"": ""2016-06-06"",
          ""DateEnd"": ""2017-06-05""
        }";

    public const string ExampleData2_json =
        @"{
          ""InsurerFirstName"": ""Петрищенко"",
          ""InsurerLastName"": ""Федор"",
          ""Vehicle"": {
            ""Mark"": ""Volvo"",
            ""Model"": ""XC90""
          },
          ""EffectiveDate"": ""2016-06-06"",
          ""ExpirationDate"": ""2017-06-05""
        }";
    public const string ExampleData3_json =
        @"{
          ""Insurer"": {
            ""Type"": ""Person"",
            ""Person"": {
              ""InsurerFirstName"": ""Петрищенко"",
              ""InsurerLastName"": ""Федор""
            }
          },
          ""VehicleMark"": ""Volvo"",
          ""VehicleModel"": ""XC90"",
          ""DateBegin"": ""2016-06-06"",
          ""DateEnd"": ""2017-06-05""
        }";

    public const string ExampleData1_Collection_json = 
        @"[
          {
            ""Insurer"": {
              ""FirstName"": ""Петрищенко"",
              ""LastName"": ""Федор""
            },
            ""Vehicle"": {
              ""Mark"": ""Volvo"",
              ""Model"": ""XC90""
            },
            ""DateBegin"": ""2016-06-06"",
            ""DateEnd"": ""2017-06-05""
          },
          {
            ""Insurer"": {
              ""FirstName"": ""FirstName"",
              ""LastName"": ""LastName""
            },
            ""Vehicle"": {
              ""Mark"": ""Mark"",
              ""Model"": ""Model""
            },
            ""DateBegin"": ""2016-06-11"",
            ""DateEnd"": ""2017-06-12""
          } 
        ]";

    public readonly static BasePolicy ExampleData1Result = new BasePolicy()
    {
        Insurer = new Person
        {
            Name = "Петрищенко Федор",
        },
        AcceptationDate = DateTime.Parse("2016-06-06"),
        ExpirationDate = DateTime.Parse("2017-06-05"),
        Vehicle = new Vehicle()
        {
            MarkName = "Volvo",
            ModelName = "XC90"
        }
    };

    public readonly static BasePolicy ExampleData1_Collection_Part = new BasePolicy()
    {
        Insurer = new Person
        {
            Name = "FirstName LastName",
        },
        AcceptationDate = DateTime.Parse("2016-06-11"),
        ExpirationDate = DateTime.Parse("2017-06-12"),
        Vehicle = new Vehicle()
        {
            MarkName = "Mark",
            ModelName = "Model"
        }
    };

    public readonly static List<BasePolicy> ExampleData1_CollectionResult = [ExampleData1Result, ExampleData1_Collection_Part];
}
