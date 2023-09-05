namespace DesignApp
{
    public class Book
    {
        public string Title { get;}
        public List<Author> Authors { get;}
        public List<Genre> Genres { get; }
        public string Isbn { get; }

        public Book(string title, List<Author> authors, List<Genre> genres,string isbn)
        {
            Title = title;
            Authors = authors;
            Genres = genres;
            Isbn = isbn;
            foreach (var author in authors)
            {
                author.Books.Add(this);
            }
        }
    }
}
