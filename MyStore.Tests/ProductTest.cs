using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MyStore.Models;

namespace MyStore.Tests
{
    public class ProductTest
    {
        [Fact]
        public void GetSetTest()
        {
            // Arrange
            Product product = new Product
            {
                ProductID = 1,
                Artist = "artist",
                Name = "name",
                Price = 10,
                ImageSourceFileName = "path"
            };

            // Act
            int id = product.ProductID;
            string artist = product.Artist;
            string name = product.Name;
            decimal price = product.Price;
            string imageSourceFileName = product.ImageSourceFileName;

            // Assert
            Assert.Equal(1, id);
            Assert.Equal("artist", artist);
            Assert.Equal("name", name);
            Assert.Equal(10, price);
            Assert.Equal("path", imageSourceFileName);
        }
    }
}
