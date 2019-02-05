using System;

class Program
{
    static void Main(string[] args)
    {
        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        AddElements(addCollection, addRemoveCollection, myList);
        RemoveElements(addRemoveCollection, myList);
    }

    private static void RemoveElements(AddRemoveCollection addRemoveCollection, MyList myList)
    {
        int removeOperations = int.Parse(Console.ReadLine());

        for (int i = 0; i < removeOperations; i++)
        {
            if (i == removeOperations - 1)
            {
                Console.Write(addRemoveCollection.Remove());
            }
            else
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }
        }
        Console.WriteLine();

        for (int i = 0; i < removeOperations; i++)
        {
            if (i == removeOperations - 1)
            {
                Console.Write(myList.Remove());
            }
            else
            {
                Console.Write(myList.Remove() + " ");
            }
        }
        Console.WriteLine();
    }

    private static void AddElements(AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList)
    {
        string[] elementsToAdd = Console.ReadLine().Split(' ');

        for (int i = 0; i < elementsToAdd.Length; i++)
        {
            if (i == elementsToAdd.Length - 1)
            {
                Console.Write(addCollection.Add(elementsToAdd[i]));
            }
            else
            {
                Console.Write(addCollection.Add(elementsToAdd[i]) + " ");
            }
        }
        Console.WriteLine();

        for (int i = 0; i < elementsToAdd.Length; i++)
        {
            if (i == elementsToAdd.Length - 1)
            {
                Console.Write(addRemoveCollection.Add(elementsToAdd[i]));
            }
            else
            {
                Console.Write(addRemoveCollection.Add(elementsToAdd[i]) + " ");
            }
        }
        Console.WriteLine();

        for (int i = 0; i < elementsToAdd.Length; i++)
        {
            if (i == elementsToAdd.Length - 1)
            {
                Console.Write(myList.Add(elementsToAdd[i]));
            }
            else
            {
                Console.Write(myList.Add(elementsToAdd[i]) + " ");
            }
        }
        Console.WriteLine();
    }
}

