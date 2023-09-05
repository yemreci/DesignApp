namespace DesignApp
{
    public class RentInfo
    {
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int RentDuration { get; set; }
        public InventoryItem Item { get; set; }
        public State Status { get; set; }
        public RentInfo(User user,InventoryItem item, int rentDuration)
        {
            User = user;
            Date = DateTime.Now;
            Item = item;
            Status = Item.State;
            RentDuration = rentDuration;
        }
    }
}
