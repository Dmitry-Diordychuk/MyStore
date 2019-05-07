using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MyStore.Controllers;
using MyStore.Models;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace MyStore.Tests
{
    public class RemoveFromCartTest
    {
        [Fact]
        public void CartController_RemoveFromCartTest()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());

            Cart cart = new Cart();
            CartController target = new CartController(mock.Object,cart);

            // Act
            RedirectToActionResult result = target.RemoveFromCart(3, "returnUrl");

            // Assert
            Product[] expected = new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            };
            Assert.True(expected.All(expectedItem => mock.Object.Products.Any(isItem => isItem.ProductID == expectedItem.ProductID && isItem.Name == expectedItem.Name)));
        }
    }
}
