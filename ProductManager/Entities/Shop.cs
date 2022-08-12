namespace ProductManager.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual Address? Address { get; set; }
        public int AddressId { get; set; }
    }
}
