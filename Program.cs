namespace DesignApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book(
                "newbook",
                new List<Author> {
                    new Author("Ali"),
                    new Author("Veli")
                },
                new List<Genre>
                {
                    new Genre("Horror"),
                    new Genre("Thriller")
                },
                "123123123"
                );
            Console.WriteLine(book1.Authors[1].Books[0].Title);
            Library library1 = new();
            library1.AddBookToLibrary(book1);
            Console.WriteLine(library1.BookWrappers["123123123"].InventoryItems[0].Book.Title);
            User user1 = new User("Aliveli");
            library1.RentBookFromLibrary("123123123",user1,7);
            Console.WriteLine(library1.BookWrappers["123123123"].Rents[0]);
            Console.WriteLine(user1.Rents[0]);
            Console.WriteLine(library1.BookWrappers["123123123"].InventoryItems[0].Status);
            library1.ReturnBookToLibrary(user1, user1.Rents[0].Item);
        }
        
    }
}
