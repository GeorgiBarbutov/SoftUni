using System.Collections.Generic;

public static class Swaper<T>
{
    public static List<T> Swap(int index1, int index2, List<T> collection)
    {
        T temp = collection[index1];
        collection[index1] = collection[index2];
        collection[index2] = temp;

        return collection;
    }
}

