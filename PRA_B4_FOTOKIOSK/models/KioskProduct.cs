
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;

namespace PRA_B4_FOTOKIOSK.models
{
    public class KioskProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}



namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopManager
    {
        public static List<KioskProduct> Products { get; set; } = new List<KioskProduct>();
        private static List<string> priceList = new List<string>();

        public static void SetShopPriceList(string priceListEntry)
        {
            priceList.Clear();
            priceList.Add(priceListEntry);
        }

        public static void AddShopPriceList(string priceListEntry)
        {
            priceList.Add(priceListEntry);
        }

        public static List<string> GetShopPriceList()
        {
            return priceList;
        }

        // Method to display the price list (for testing purposes)
        public static void DisplayPriceList()
        {
            foreach (var entry in priceList)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public class ProductController
    {
        public void PopulatePriceList()
        {
            foreach (KioskProduct product in ShopManager.Products)
            {
                string priceListEntry = $"{product.Name}: {product.Description} - {product.Price:C}";
                ShopManager.AddShopPriceList(priceListEntry);
            }

            // For demonstration purposes, display the price list
            ShopManager.DisplayPriceList();
        }
    }

    // Example usage
    public class Program
    {
        public static void Main()
        {
            // Add sample products
            ShopManager.Products.Add(new KioskProduct { Name = "Camera", Price = 299.99m, Description = "High-resolution digital camera" });
            ShopManager.Products.Add(new KioskProduct { Name = "Photo Frame", Price = 19.99m, Description = "8x10 inch wooden frame" });

            // Populate the price list
            ProductController productController = new ProductController();
            productController.PopulatePriceList();
        }
    }
}