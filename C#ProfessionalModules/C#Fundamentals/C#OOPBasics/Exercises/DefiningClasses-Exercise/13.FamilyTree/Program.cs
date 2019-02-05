using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> familyTree = new List<Person>();
        Person originalPerson = CreateFirstPerson(familyTree);
        SetConnections(familyTree);
        PrintFamily(familyTree, originalPerson);
    }

    private static void PrintFamily(List<Person> familyTree, Person originalPerson)
    {
        int index = 0;

        if (originalPerson.Name != null)
        {
            for (int i = 0; i < familyTree.Count; i++)
            {
                if (familyTree[i].Name == originalPerson.Name)
                {
                    index = i;
                }
            }
        }
        else
        {
            for (int i = 0; i < familyTree.Count; i++)
            {
                if (familyTree[i].Birthday == originalPerson.Birthday)
                {
                    index = i;
                }
            }
        }

        familyTree[index].Print();
    }

    private static void SetConnections(List<Person> familyTree)
    {
        string[] connections;

        while ((connections = Console.ReadLine().Split(" - "))[0] != "End")
        {
            if (connections.Length == 1)
            {
                UpdateSInglePerson(familyTree, connections);
            }
            else
            {
                CreateConection(familyTree, connections);
            }
        }
    }

    private static void CreateConection(List<Person> familyTree, string[] connections)
    {
        string parentInfo = connections[0];
        string childInfo = connections[1];

        bool parentIsName = false;
        bool parentIsBirthday = false;
        bool childIsName = false;
        bool childIsBirthday = false;

        FindDataType(parentInfo, childInfo, ref parentIsName, ref parentIsBirthday, ref childIsName, ref childIsBirthday);

        if (parentIsName && childIsName)
        {
            NameAndNameConection(familyTree, parentInfo, childInfo);
        }
        else if (parentIsName && childIsBirthday)
        {
            NameAndBirthdayConnection(familyTree, parentInfo, childInfo);
        }
        else if (parentIsBirthday && childIsName)
        {
            BirthdayAndNameConnection(familyTree, parentInfo, childInfo);
        }
        else if (parentIsBirthday && childIsBirthday)
        {
            BirthdayAndBirthdayConnection(familyTree, parentInfo, childInfo);
        }
    }

    private static void BirthdayAndBirthdayConnection(List<Person> familyTree, string parentInfo, string childInfo)
    {
        Person tryParent = familyTree.FirstOrDefault(x => x.Birthday == parentInfo);

        if (tryParent != null)
        {
            Person tryChild = familyTree.FirstOrDefault(x => x.Birthday == childInfo);

            if (tryChild != null)
            {
                familyTree[familyTree.IndexOf(tryChild)].Parents.Add(tryParent);
                familyTree[familyTree.IndexOf(tryParent)].Children.Add(tryChild);
            }
            else
            {
                Person newChild = new Person(childInfo);

                newChild.Parents.Add(tryParent);
                familyTree[familyTree.IndexOf(tryParent)].Children.Add(newChild);
                familyTree.Add(newChild);
            }
        }
        else
        {
            Person newPerant = new Person(parentInfo);

            Person tryChild = familyTree.FirstOrDefault(x => x.Birthday == childInfo);

            if (tryChild != null)
            {
                familyTree[familyTree.IndexOf(tryChild)].Parents.Add(newPerant);
                newPerant.Children.Add(tryChild);
            }
            else
            {
                Person newChild = new Person(childInfo);

                newChild.Parents.Add(newPerant);
                newPerant.Children.Add(newChild);
                familyTree.Add(newChild);
            }

            familyTree.Add(newPerant);
        }
    }

    private static void BirthdayAndNameConnection(List<Person> familyTree, string parentInfo, string childInfo)
    {
        Person tryParent = familyTree.FirstOrDefault(x => x.Birthday == parentInfo);

        if (tryParent != null)
        {
            Person tryChild = familyTree.FirstOrDefault(x => x.Name == childInfo);

            if (tryChild != null)
            {
                familyTree[familyTree.IndexOf(tryChild)].Parents.Add(tryParent);
                familyTree[familyTree.IndexOf(tryParent)].Children.Add(tryChild);
            }
            else
            {
                Person newChild = new Person(childInfo);

                newChild.Parents.Add(tryParent);
                familyTree[familyTree.IndexOf(tryParent)].Children.Add(newChild);
                familyTree.Add(newChild);
            }
        }
        else
        {
            Person newPerant = new Person(parentInfo);

            Person tryChild = familyTree.FirstOrDefault(x => x.Name == childInfo);

            if (tryChild != null)
            {
                familyTree[familyTree.IndexOf(tryChild)].Parents.Add(newPerant);
                newPerant.Children.Add(tryChild);
            }
            else
            {
                Person newChild = new Person(childInfo);

                newChild.Parents.Add(newPerant);
                newPerant.Children.Add(newChild);
                familyTree.Add(newChild);
            }

            familyTree.Add(newPerant);
        }
    }

    private static void NameAndBirthdayConnection(List<Person> familyTree, string parentInfo, string childInfo)
    {
        Person tryParent = familyTree.FirstOrDefault(x => x.Name == parentInfo);

        if (tryParent != null)
        {
            Person tryChild = familyTree.FirstOrDefault(x => x.Birthday == childInfo);

            if (tryChild != null)
            {
                familyTree[familyTree.IndexOf(tryChild)].Parents.Add(tryParent);
                familyTree[familyTree.IndexOf(tryParent)].Children.Add(tryChild);
            }
            else
            {
                Person newChild = new Person(childInfo);

                newChild.Parents.Add(tryParent);
                familyTree[familyTree.IndexOf(tryParent)].Children.Add(newChild);
                familyTree.Add(newChild);
            }
        }
        else
        {
            Person newPerant = new Person(parentInfo);

            Person tryChild = familyTree.FirstOrDefault(x => x.Birthday == childInfo);

            if (tryChild != null)
            {
                familyTree[familyTree.IndexOf(tryChild)].Parents.Add(newPerant);
                newPerant.Children.Add(tryChild);
            }
            else
            {
                Person newChild = new Person(childInfo);

                newChild.Parents.Add(newPerant);
                newPerant.Children.Add(newChild);
                familyTree.Add(newChild);
            }

            familyTree.Add(newPerant);
        }
    }

    private static void NameAndNameConection(List<Person> familyTree, string parentInfo, string childInfo)
    {
        Person tryParent = familyTree.FirstOrDefault(x => x.Name == parentInfo);

        if (tryParent != null)
        {
            Person tryChild = familyTree.FirstOrDefault(x => x.Name == childInfo);

            if (tryChild != null)
            {
                familyTree[familyTree.IndexOf(tryChild)].Parents.Add(tryParent);
                familyTree[familyTree.IndexOf(tryParent)].Children.Add(tryChild);
            }
            else
            {
                Person newChild = new Person(childInfo);

                newChild.Parents.Add(tryParent);
                familyTree[familyTree.IndexOf(tryParent)].Children.Add(newChild);
                familyTree.Add(newChild);
            }
        }
        else
        {
            Person newPerant = new Person(parentInfo);

            Person tryChild = familyTree.FirstOrDefault(x => x.Name == childInfo);

            if (tryChild != null)
            {
                familyTree[familyTree.IndexOf(tryChild)].Parents.Add(newPerant);
                newPerant.Children.Add(tryChild);
            }
            else
            {
                Person newChild = new Person(childInfo);

                newChild.Parents.Add(newPerant);
                newPerant.Children.Add(newChild);
                familyTree.Add(newChild);
            }

            familyTree.Add(newPerant);
        }
    }

    private static void UpdateSInglePerson(List<Person> familyTree, string[] connections)
    {
        string personName = connections[0].Split(' ')[0] + " " + connections[0].Split(' ')[1];
        string personBirthday = connections[0].Split(' ')[2];

        Person tryPersonByName = familyTree.FirstOrDefault(x => x.Name == personName);

        if (tryPersonByName != null)
        {
            Person tryPersonByBirtday = familyTree.FirstOrDefault(x => x.Birthday == personBirthday);

            if (tryPersonByBirtday != null)
            {
                CopyAndRemovePerson(familyTree, personBirthday, tryPersonByName, tryPersonByBirtday);
            }
            else
            {
                familyTree[familyTree.IndexOf(tryPersonByName)].Birthday = personBirthday;
            }
        }
        else
        {
            Person tryPersonByBirtday = familyTree.FirstOrDefault(x => x.Birthday == personBirthday);

            if (tryPersonByBirtday != null)
            {
                familyTree[familyTree.IndexOf(tryPersonByBirtday)].Name = personName;
            }
            else
            {
                Person newPerson = new Person(personName);
                newPerson.Birthday = personBirthday;
                familyTree.Add(newPerson);
            }
        }
    }

    private static void CopyAndRemovePerson(List<Person> familyTree, string personBirthday, Person tryPersonByName, Person tryPersonByBirtday)
    {
        familyTree[familyTree.IndexOf(tryPersonByName)].Birthday = personBirthday;
        foreach (var parent in familyTree[familyTree.IndexOf(tryPersonByBirtday)].Parents)
        {
            familyTree[familyTree.IndexOf(tryPersonByName)].Parents.Add(parent);
        }
        foreach (var child in familyTree[familyTree.IndexOf(tryPersonByBirtday)].Children)
        {
            familyTree[familyTree.IndexOf(tryPersonByName)].Children.Add(child);
        }

        foreach (var person in familyTree)
        {
            for (int i = 0; i < person.Children.Count; i++)
            {
                if (person.Children[i] == familyTree[familyTree.IndexOf(tryPersonByBirtday)])
                {
                    person.Children[i] = familyTree[familyTree.IndexOf(tryPersonByName)];
                }
            }

            for (int i = 0; i < person.Parents.Count; i++)
            {
                if (person.Parents[i] == familyTree[familyTree.IndexOf(tryPersonByBirtday)])
                {
                    person.Parents[i] = familyTree[familyTree.IndexOf(tryPersonByName)];
                }
            }
        }

        familyTree.RemoveAt(familyTree.IndexOf(tryPersonByBirtday));
    }

    private static void FindDataType(string parentInfo, string childInfo, ref bool parentIsName, ref bool parentIsBirthday, ref bool childIsName, ref bool childIsBirthday)
    {
        if (Char.IsDigit(parentInfo[0]))
        {
            parentIsBirthday = true;
        }
        else
        {
            parentIsName = true;
        }

        if (Char.IsDigit(childInfo[0]))
        {
            childIsBirthday = true;
        }
        else
        {
            childIsName = true;
        }
    }

    private static Person CreateFirstPerson(List<Person> familyTree)
    {
        string firstPersonInfo = Console.ReadLine();

        Person originalPerson;
        originalPerson = new Person(firstPersonInfo);

        return originalPerson;
    }
}

