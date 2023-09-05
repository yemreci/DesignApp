namespace DesignApp
{
    public interface IRentable
    {
        public void AddRentIssue(InventoryItem book, User user, int duration);
    }
}
