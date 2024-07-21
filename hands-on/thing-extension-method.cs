

public static int Age(this DateTime date, DateTime birthDate)
{
    int birthYear = birthDate.Year;
    int currentYear = DateTime.Now.Year;

    return currentYear - birthYear - 1;
}

// get me a customized class and a extension method for it
public class Developer
{
    public string Name { get; set; }
    public string Title { get; set; }
}

public static string GetFullName(this Developer developer)
{
    return $"{developer.Name} ({developer.Title})";
}


DateTime birthdate = new DateTime(1988, 5, 3);  // fake though XD
Console.WriteLine($"You are {DateTime.Now.Age(birthdate)} now");

Developer developer = new Developer
{
    Name = "John Doe",
    Title = "Software Developer"
};
Console.WriteLine($"Profile: {developer.GetFullName()}");