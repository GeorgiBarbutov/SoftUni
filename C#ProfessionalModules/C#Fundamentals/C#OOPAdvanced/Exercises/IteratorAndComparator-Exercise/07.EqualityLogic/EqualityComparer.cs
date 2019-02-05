using System.Collections.Generic;

public class EqualityComparer : IComparer<Person>, IEqualityComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.CompareTo(y.Name);

        if (result == 0)
        {
            result = x.Age.CompareTo(y.Age);
        }

        return result;
    }

    public bool Equals(Person x, Person y)
    {
        return x.Name == y.Name && x.Age == y.Age;
    }

    public int GetHashCode(Person person)
    {
        return person.Age * person.Age * person.Name[0] * person.Name[0];
    }
}


