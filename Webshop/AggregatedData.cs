using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;
using Dapper;

namespace Webshop
{
    class AggregatedData
    {
        // We will use dapper in this class for the sake of variation

        private static string dbHost = "newtonwebshop.database.windows.net";
        private static string dbName = "webshop";
        private static string dbUsername = "webshopAdmin";
        private static string dbPassword = "very%secure%password%for%a%database00";

        private static string connString { get => $"Server=tcp:{dbHost},1433;Initial Catalog={dbName};Persist Security Info=False;User ID={dbUsername};Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; }


        // Most sold product
        public static TopProductQuery GetTopProduct()
        {

            string sql = $@"SELECT TOP 1 Name, sum(Quantity) as 'Sold'
                            FROM Products
                            JOIN OrderDetails on Products.ProductId = OrderDetails.ProductId
                            group by Products.Name
                            order by sold desc";
            using (var connection = new SqlConnection(connString))
            {
                TopProductQuery topProduct = connection.Query<TopProductQuery>(sql).FirstOrDefault();
                return topProduct;
            }
        }

        // Least sold product
        public static LeastSoldProductQuery GetLeastSoldProduct()
        {

            string sql = $@"SELECT TOP 1 Name, sum(Quantity) as 'Sold'
                            FROM Products
                            JOIN OrderDetails on Products.ProductId = OrderDetails.ProductId
                            group by Products.Name
                            order by sold asc";
            using (var connection = new SqlConnection(connString))
            {
                LeastSoldProductQuery leastSoldProduct = connection.Query<LeastSoldProductQuery>(sql).FirstOrDefault();
                return leastSoldProduct;
            }
        }

        // Average products per order, value is automatically rounded (same datatype as Quantity)
        public static int GetAverageOrderPerCustomer()
        {

            string sql = $@"SELECT AVG(CAST(Quantity AS FLOAT))
                            FROM OrderDetails as subOrder
                            JOIN Orders on Orders.OrderId = subOrder.OrderId";

            using (var connection = new SqlConnection(connString))
            {
                int average = connection.Query<int>(sql).FirstOrDefault();
                return average;
            }
        }

        // Most popular category
        public static MostPopularCategoryQuery MostPopularCategory()
        {
            string sql = $@"SELECT TOP 1 Categories.Name as 'CategoryName', SUM(od.Quantity) as [Sold]
                            FROM Categories
                            JOIN Products as p on p.CategoryId = Categories.CategoryId
                            JOIN OrderDetails as od on od.ProductId = p.ProductId
                            GROUP BY Categories.Name
                            ORDER BY [Sold] desc";

            using (var connection = new SqlConnection(connString))
            {
                MostPopularCategoryQuery topCategory = connection.Query<MostPopularCategoryQuery>(sql).FirstOrDefault();
                return topCategory;
            }
        }

        // Stock valuation
        public static decimal GetStockValuation()
        {
            string sql = $@"SELECT SUM(p.Price * sb.Quantity)
                            FROM Products as p
                            JOIN StockBalance as sb ON p.ProductId = sb.ProductId";

            using (var connection = new SqlConnection(connString))
            {
                decimal stockValuation = connection.Query<decimal>(sql).FirstOrDefault();
                return stockValuation;
            }
        }

        // Variation on return type
        public static (string, int) GetProductWithLeastStock()
        {
            string sql = $@"SELECT TOP 1 p.Name as 'ProductName', sb.Quantity as 'Balance'
                            FROM Products as p
                            JOIN Stockbalance as sb on p.ProductId = sb.ProductId
                            ORDER BY Balance ASC";

            using (var connection = new SqlConnection(connString))
            {
                (string, int) product = connection.Query<(string, int)>(sql).FirstOrDefault();
                return product;
            }
        }

        // Product with most stock
        public static (string, int) GetProductWithMostStock()
        {
            string sql = $@"SELECT TOP 1 p.Name as 'ProductName', sb.Quantity as 'Balance'
                            FROM Products as p
                            JOIN Stockbalance as sb on p.ProductId = sb.ProductId
                            ORDER BY Balance DESC";

            using (var connection = new SqlConnection(connString))
            {
                (string, int) product = connection.Query<(string, int)>(sql).FirstOrDefault();
                return product;
            }
        }

        public static (string, int) GetMostPopularShipper()
        {
            string sql = $@"SELECT TOP 1 s.Name, COUNT(s.ShippingMethodId) as 'Popularity'
                            FROM ShippingMethods as s
                            JOIN Orders as o on s.ShippingMethodId = o.ShippingMethodId
                            GROUP BY s.Name
                            ORDER BY Popularity DESC";

            using (var connection = new SqlConnection(connString))
            {
                (string, int) shipper = connection.Query<(string, int)>(sql).FirstOrDefault();
                return shipper;
            }
        }

        // Get most popular product by women
        public static (string, int) GetMostPopularWomensProduct()
        {
            string sql = $@"SELECT TOP 1 p.Name as 'ProductName', sum(od.Quantity) as Sold
                            FROM Products as p
                            JOIN OrderDetails as od on p.ProductId = od.ProductId
                            JOIN Orders as o on o.OrderId = od.OrderId 
                            JOIN Customers as c on o.CustomerId = c.CustomerId
                            WHERE c.Sex = 1
                            GROUP BY p.Name
                            ORDER BY 'Sold' DESC";

            using (var connection = new SqlConnection(connString))
            {
                (string, int) product = connection.Query<(string, int)>(sql).FirstOrDefault();
                return product;
            }
        }

        // Get most popular product by women
        public static (string, int) GetMostPopularMensProducts()
        {
            string sql = $@"SELECT TOP 1 p.Name as 'ProductName', sum(od.Quantity) as Sold
                            FROM Products as p
                            JOIN OrderDetails as od on p.ProductId = od.ProductId
                            JOIN Orders as o on o.OrderId = od.OrderId 
                            JOIN Customers as c on o.CustomerId = c.CustomerId
                            WHERE c.Sex = 0
                            GROUP BY p.Name
                            ORDER BY 'Sold' DESC";

            using (var connection = new SqlConnection(connString))
            {
                (string, int) product = connection.Query<(string, int)>(sql).FirstOrDefault();
                return product;
            }
        }
    }
}
