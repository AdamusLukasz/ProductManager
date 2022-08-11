namespace ProductManager.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MyProperty { get; set; }
        public Address? Address { get; set; }
    }
}
