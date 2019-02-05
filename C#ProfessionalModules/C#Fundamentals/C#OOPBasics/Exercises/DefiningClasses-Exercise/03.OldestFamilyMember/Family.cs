using System.Collections.Generic;

class Family
{
    List<Person> peopleList;

    public Family()
    {
        peopleList = new List<Person>();
    }

    public void AddMember(Person member)
    {
        peopleList.Add(member);
    }

    public Person GetOldestMember()
    {
        Person oldestPerson = peopleList[0];

        for (int i = 0; i < peopleList.Count; i++)
        {
            if(peopleList[i].Age > oldestPerson.Age)
            {
                oldestPerson = peopleList[i];
            }
        }

        return oldestPerson;
    }

}

