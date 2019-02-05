using System;

public class Book
{
    protected string author;
    protected string title;
    protected decimal price;

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" + Environment.NewLine +
            $"Title: {this.Title}" + Environment.NewLine +
            $"Author: {this.Author}" + Environment.NewLine +
            $"Price: {this.Price:f2}";
    }

    protected virtual decimal Price
    {
        get { return price; }

        set
        {
            if (value <= 0)
                throw new ArgumentException("Price not valid!");

            price = value;
        }
    }

    protected string Title
    {
        get { return title; }

        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Title not valid!");

            title = value;
        }
    }

    protected string Author
    {
        get { return author; }

        set
        {
            if (value.Split(' ').Length > 1 && Char.IsDigit(value.Split(' ')[1][0]))
                throw new ArgumentException("Author not valid!");

            author = value;
        }
    }

}

