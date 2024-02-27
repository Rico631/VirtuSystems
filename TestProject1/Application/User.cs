namespace TestProject1.Application;

public class User
{
    public int Id { get; set; }
    public required string FIO { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Phone { get; set; }
}
