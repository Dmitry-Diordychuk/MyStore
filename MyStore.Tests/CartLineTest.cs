using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MyStore.Models;

namespace MyStore.Tests.Remove
{
    public class CartLineTest
    {
        [Fact]
        public void GetSetTest()
        {
            // Arrange
            Product product = new Product();
            CartLine cartLine = new CartLine
            {
                CartLineID = 1,
                Product = product,
                Quantity = 10
            };

            // Act
            int id = cartLine.CartLineID;
            Product newPrduct = cartLine.Product;
            int quantity = cartLine.Quantity;

            // Assert
            Assert.Equal(1, id);
            Assert.Equal(product, newPrduct);
            Assert.Equal(10, quantity);
        }
    }
}
