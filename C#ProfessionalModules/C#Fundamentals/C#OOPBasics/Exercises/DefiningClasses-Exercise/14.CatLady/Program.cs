using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();

        AddCats(cats);
        Print(cats);
    }

    private static void Print(List<Cat> cats)
    {
        string inputCat = Console.ReadLine();

        var cat = cats.FirstOrDefault(x => x.Name == inputCat);

        Console.WriteLine(cat.ToString());
    }

    private static void AddCats(List<Cat> cats)
    {
        string[] catInfo;

        while ((catInfo = Console.ReadLine().Split(' '))[0] != "End")
        {
            if (catInfo[0] == "StreetExtraordinaire")
            {
                Extraordinaire cat = new Extraordinaire(catInfo[1], int.Parse(catInfo[2]), catInfo[0]);
                cats.Add(cat);
            }
            else if (catInfo[0] == "Siamese")
            {
                Siamese cat = new Siamese(catInfo[1], int.Parse(catInfo[2]), catInfo[0]);
                cats.Add(cat);
            }
            else if (catInfo[0] == "Cymric")
            {
                Cymric cat = new Cymric(catInfo[1], double.Parse(catInfo[2]), catInfo[0]);
                cats.Add(cat);
            }
        }
    }
}

