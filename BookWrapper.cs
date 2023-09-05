namespace DesignApp
{
    public class BookWrapper : IRentable
    {
        public List<RentInfo> Rents;
        public string Location { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
        public BookWrapper()
        {
            Rents = new List<RentInfo>();
            Location = "SomeUniqueLocation";
            InventoryItems = new List<InventoryItem>();
        }

        public void FillBookWrapper(Book book)
        {
            InventoryItems.Add(new InventoryItem(book));
        }

        public void AddRentIssue(InventoryItem item, User user, int duration)
        {
            RentInfo currentRentInfo = new RentInfo(user, item, duration);
            Rents.Add(currentRentInfo);
            user.Rents.Add(currentRentInfo);
            item.Status = RentStatus.Rented;
        }
        public void TakeReturnIssue(User user, Guid id)
        {
            var currentRentInfo = user.Rents.FirstOrDefault(rent => rent.Item.Id == id);
            if (currentRentInfo == null)
            {
                Console.WriteLine("User don't have a book to return with that id");
                return;
            }
            currentRentInfo.Item.Status = RentStatus.Available;
            Rents.Remove(currentRentInfo);
            user.Rents.Remove(currentRentInfo);
        }
    }
}
