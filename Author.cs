namespace DesignApp
{
    public class Author
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<Book> Books { get; set; }
        public Author(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Books = new List<Book>();
        }
    }
}
