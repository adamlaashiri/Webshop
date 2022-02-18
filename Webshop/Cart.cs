using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop
{
    class Cart
    {
        public static List<Item> Items = new();
        public static decimal TotalCost { get; }

        public static int ItemsCount { get => Items.Sum(i => i.Quantity); }

        public static void AddItem(int productId)
        {
            // Using linq to query Items, same principle as with database queries
            var item = Items.Where(i => i.ProductId == productId).FirstOrDefault();

            if (item != null)
            {
                item.Quantity++;
                return;
            } 
            Items.Add(new Item { ProductId = productId, Quantity = 1});
        }

        public static void RemoveItem(int productId)
        {
            var item = Items.Where(i => i.ProductId == productId).FirstOrDefault();

            if (item != null)
            {
                if (item.Quantity < 1)
                {
                    Items.Remove(item);
                    return;
                }
                item.Quantity--;
            }
        }

        public static decimal GetTotalCost()
        {

            using (var db = new webshopContext())
            {
                decimal totalCost = 0.0M;

                foreach (var item in Items)
                {
                    var cost = db.Products.Where(p => p.ProductId == item.ProductId).FirstOrDefault();
                    
                    if (cost != null)
                    {
                        totalCost += cost.Price * item.Quantity;
                    }
                    
                }
                return totalCost;
            }
        }

        public static string ToJson()
        {
            return "";
        }

        public static void Clear()
        {
            Items.Clear();
        }
    }
}
