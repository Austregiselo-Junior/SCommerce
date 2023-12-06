using SCommerce.Main.Model.Entities;
using System.Linq;
using System.Collections.Generic;

namespace SCommerce.Main.Model.Services.CartService
{
    public class CartService
    {
        private static CartService _instance;
        public Dictionary<int, int> cart { get; private set; }
        private List<Cart> _itemToCart = new List<Cart>();

        private CartService()
        {
            cart = new Dictionary<int, int>();
        }

        public static CartService GetInstance() => _instance ?? (_instance = new CartService());
     

        public void AddProductinCart(int productId, int quantity)
        {
            if (cart.ContainsKey(productId))
            {
                cart[productId] += quantity;
                AddCartToPageatDB(productId, quantity);
            }
            else
            {
                cart.Add(productId, quantity);
                AddCartToPageatDB(productId, quantity);
            }
        }

        private void AddCartToPageatDB(int productId, int quantity)
        {
            _itemToCart.Add(new Cart(productId,
                            ServiceConnection.GetInstance().GetTitleProduct(),
                            ServiceConnection.GetInstance().GetPriceProduct(),
                            ServiceConnection.GetInstance().GetImageProduct()[0].ToString(), quantity));
        }

        public List<Cart> GetProductsFromCart()
        {
            return  _itemToCart;
        }
    }
}

