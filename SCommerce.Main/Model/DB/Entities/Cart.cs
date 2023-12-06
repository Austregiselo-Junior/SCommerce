namespace SCommerce.Main.Model.Entities
{
    public sealed class Cart : Product
    {
        public int Quantity { get; set; }

        public Cart(int id, string name, float price, string image, int quantity)
            : base(id, name, price, image)
        {
            Quantity = quantity;
        }
    }
}