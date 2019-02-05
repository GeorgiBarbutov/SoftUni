using System;

public class Smartphone : IBrowseable, ICallable
{
    public string[] Phones { get; private set; }
    public string[] Sites { get; private set; }

    public Smartphone(string[] phones, string[] sites)
    {
        this.Phones = phones;
        this.Sites = sites;
    }

    public void BrowseWeb()
    {
        foreach (var site in Sites)
        {
            try
            {
                TryPrintSite(site);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void TryPrintSite(string site)
    {
        for (int i = 0; i < site.Length; i++)
        {
            if ((int)site[i] >= 48 && (int)site[i] <= 57)
                throw new ArgumentException("Invalid URL!");
        }

        Console.WriteLine($"Browsing: {site}!");
    }

    public void CallPhones()
    {
        foreach (var phone in Phones)
        {
            try
            {
                TryPrintPhone(phone);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void TryPrintPhone(string phone)
    {
        for (int i = 0; i < phone.Length; i++)
        {
            if ((int)phone[i] < 48 || (int)phone[i] > 57)
                throw new ArgumentException("Invalid number!");
        }

        Console.WriteLine($"Calling... {phone}");
    }
}