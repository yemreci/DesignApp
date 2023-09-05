namespace DesignApp
{
    public class InventoryItem
    {
        public Book Book { get; set; }
        public Guid Id { get; set; }
        public RentStatus Status { get; set; }
        public State State { get; set; }
        public InventoryItem(Book book)
        {
            Book = book;
            Id = new Guid();
            Status = RentStatus.Available;
            State = State.Good;
        }
    }
}