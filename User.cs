namespace DesignApp
{
    public class User
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<RentInfo> Rents { get; set; }
        public User(string name)
        {
            Name = name;
            Id = new Guid();
            Rents = new List<RentInfo>();
        }
    }
}
