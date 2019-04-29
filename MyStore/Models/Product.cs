using System;
using System.Drawing;

namespace MyStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageSourceFileName { get; set; }
    }
}
