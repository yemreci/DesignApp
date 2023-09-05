using System.Linq;

namespace DesignApp
{
    public class Library
    {
        public Dictionary<string, BookWrapper> BookWrappers { get; set; }
        public Library()
        {
            BookWrappers = new Dictionary<string, BookWrapper>();
        }
        public void AddBookToLibrary(Book book)
        {
            if (!BookWrappers.ContainsKey(book.Isbn))
            {
                BookWrappers.Add(book.Isbn, new BookWrapper());
            }
            BookWrappers[book.Isbn].FillBookWrapper(book);
        }
        public void RemoveBookFromLibrary(Book book, Guid id)
        {
            BookWrappers[book.Isbn].InventoryItems.RemoveAll(b => b.Id == id);
        }
        public void RemoveBookWrapperFromLibrary(Book book)
        {
            BookWrappers.Remove(book.Isbn);
        }
        public void RentBookFromLibrary(string isbn, User user, int duration)
        {
            if (!BookWrappers.ContainsKey(isbn))
            {
                Console.WriteLine("Book does not exist in Library");
                return;
            }
            BookWrappers[isbn].AddRentIssue(BookWrappers[isbn].InventoryItems.Last(), user, duration);
        }
        public void ReturnBookToLibrary(User user, InventoryItem inventoryItem)
        {
            var currentRentInfo = BookWrappers[inventoryItem.Book.Isbn].Rents.Find(rent => rent.Item == inventoryItem);
            if (currentRentInfo == null)
            {
                Console.WriteLine("Library do not have such rent issue");
            }
            if (!user.Rents.Contains(currentRentInfo))
            {
                Console.WriteLine("User do not have such rent issue this book actually rented by {0}", currentRentInfo.User.Name);
                return;
            }
            Console.WriteLine("Person {0} need to pay {1}", user.Name, CalculateRentCostAfterReturn(user, inventoryItem.Id));
            BookWrappers[inventoryItem.Book.Isbn].TakeReturnIssue(user, inventoryItem.Id);
        }
        private float CalculateRentCostAfterReturn(User user, Guid id)
        {
            var currentRent = user.Rents.FirstOrDefault(rent => rent.Item.Id == id);
            var totaldays = DateTime.Now - currentRent.Date;
            if (totaldays.Days < currentRent.RentDuration)
            {
                return totaldays.Days * 5;
            }
            else
            {
                return (currentRent.RentDuration * 5) + (totaldays.Days - currentRent.RentDuration) * 10;
            }

        }
    }
}
