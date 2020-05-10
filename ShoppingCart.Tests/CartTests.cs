using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartTests
    {
        private static CartItem _cartItem;
        private static CartManager _cartManager;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product()
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };
            _cartManager.Add(_cartItem);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _cartManager.Clear();
        }

        [TestMethod]
        public void When_a_different_product_is_added_to_the_cart_total_number_of_the_products_and_total_item_number_must_increase()
        {
            // Arrange
            int totalQuantity = _cartManager.TotalQuantity;
            int totalItemNumber = _cartManager.TotalItems;

            // Act
            _cartManager.Add(new CartItem
            {
                Product = new Product
                {
                    ProductId = 2,
                    ProductName = "Mouse",
                    UnitPrice = 30
                },
                Quantity = 1
            });

            // Assert
            Assert.AreEqual(totalQuantity + 1, _cartManager.TotalQuantity);
            Assert.AreEqual(totalItemNumber + 1, _cartManager.TotalItems);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        // [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void When_one_of_the_products_in_the_cart_is_added_it_must_show_error()
        {
            _cartManager.Add(_cartItem);
        }
    }
}