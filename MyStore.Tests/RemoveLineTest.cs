using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using MyStore.Models;
using System.Linq;

namespace MyStore.Tests.Remove
{
    public class RemoveLineTest
    {
        [Fact]
        public void TestRemoving()
        {
            // Arrange
            Cart cart = new Cart();
            Product product1 = new Product
            {
                Artist = "artist1",
                Name = "name1",
                ImageSourceFileName = "path1",
                Price = 10,
                ProductID = 1
            };
            Product product2 = new Product
            {
                Artist = "artist2",
                Name = "name2",
                ImageSourceFileName = "path2",
                Price = 20,
                ProductID = 2
            };
            List<CartLine> testCartLines = new List<CartLine>
            {
                new CartLine { CartLineID = 1, Product = product1, Quantity = 1 },
                new CartLine { CartLineID = 2, Product = product2, Quantity = 2 }
            };
            CartTestClass cartLineTest = new CartTestClass();
            cartLineTest.SetLineCollection(testCartLines);

            // Act
            cartLineTest.RemoveLine(product2);

            // Assert
            List<CartLine> expected = new List<CartLine>
            {
                 new CartLine { CartLineID = 1, Product = product1, Quantity = 1 }
            };

            Assert.True(expected.All(expectedItem => cartLineTest.GetLineCollection().Any(isItem => isItem.Product == expectedItem.Product && isItem.CartLineID == expectedItem.CartLineID && isItem.Quantity == expectedItem.Quantity) ));
            
        }
    }

    class CartTestClass : Cart
    {
        public void SetLineCollection(List<CartLine> cartLines)
        {
            lineCollection = cartLines;
        }
        public List<CartLine> GetLineCollection()
        {
            return lineCollection;
        }
    }
}
