using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class CartManager
    {
        private readonly List<CartItem> _cartItems;

        public CartManager()
        {
            _cartItems = new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            var addedCartItem = _cartItems.SingleOrDefault(x => x.Product.ProductId == cartItem.Product.ProductId);
            if (addedCartItem == null)
            {
                _cartItems.Add(cartItem);
            }
            else
            {
                throw new ArgumentException("This product has already been added.");
            }
        }

        public void Remove(int productId)
        {
            var product = _cartItems.FirstOrDefault(x => x.Product.ProductId == productId);
            _cartItems.Remove(product);
        }

        public List<CartItem> CartItems
        {
            get
            {
                return _cartItems;
            }
        }
        
        public void Clear()
        {
            _cartItems.Clear();
        }

        public decimal TotalPrice
        {
            get
            {
                return _cartItems.Sum(x => x.Quantity * x.Product.UnitPrice);
            }
        }

        public int TotalQuantity
        {
            get
            {
                return _cartItems.Sum(x => x.Quantity);
            }
        }

        public int TotalItems
        {
            get
            {
                return _cartItems.Count;
            }
        }
    }
}