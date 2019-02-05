public class Person
{
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Person()
    {
        this.age = 1;
        this.name = "No name";
    }

    public Person(int age)
    {
        this.age = age;
        this.name = "No name";
    }

    public Person(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

