using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private IList<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private IReadOnlyList<Book> books;
        private int index;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.books = new List<Book>(books);
            this.index = -1;
        }

        public Book Current => this.books[index];

        object IEnumerator.Current => this.Current;

        public void Dispose() {}

        public bool MoveNext()
        {
            this.index++;
            return this.index < books.Count;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}