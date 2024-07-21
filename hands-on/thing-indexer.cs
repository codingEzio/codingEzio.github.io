var pWithIndexer = new PersonCollectionWithIndexer();
pWithIndexer["00001"] = new Person { Name = "John", SSN = "00001" };
pWithIndexer["00002"] = new Person { Name = "Hugh", SSN = "00002" };

var pWithoutIndexer = new PersonCollection();
pWithoutIndexer.Add(new Person { Name = "John", SSN = "00001" });
pWithoutIndexer.Add(new Person { Name = "Hugh", SSN = "00002" });

Console.WriteLine(pWithIndexer["00001"]);
Console.WriteLine(pWithoutIndexer.GetBySSN("00001"));


public class Person
{
    public string Name { get; set; }
    public string SSN { get; set; }

    public override string ToString()
    {
        return $"{Name} ({SSN})";
    }
}


public class PersonCollectionWithIndexer
{
    private List<Person> _people = new List<Person>();

    public Person this[string ssn]
    {
        get
        {
            return _people.FirstOrDefault(p => p.SSN == ssn);
        }
        set
        {
            var person = _people.FirstOrDefault(p => p.SSN == ssn);
            if (person != null)
            {
                _people[_people.IndexOf(person)] = value;
            }
            else
            {
                _people.Add(value);
            }
        }
    }
}

public class PersonCollection
{
    private List<Person> _people = new List<Person>();

    public void Add(Person person)
    {
        _people.Add(person);
    }

    public Person GetBySSN(string ssn)
    {
        return _people.FirstOrDefault(p => p.SSN == ssn);
    }

    public void UpdateBySSN(string ssn, Person newPerson)
    {
        var person = GetBySSN(ssn);
        if (person != null)
        {
            _people[_people.IndexOf(person)] = newPerson;
        }
        else
        {
            _people.Add(newPerson);
        }
    }
}