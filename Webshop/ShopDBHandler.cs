using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;
using System.Net.Http;

namespace Webshop
{
    /* This class will handle every requests made from the shop towards the database, 
    * this was so the code don't get messy. Unlike the Admin part of the project, where
    * CRUD JOINS and data aggregation is directly incorporated in the different windows, 
    * the shop will have all database operations encapsulated in this class for the sake of organisation
    */
    class ShopDBHandler
    {

        public static Product GetProduct(int productId)
        {


            Product product = null;
            using (var db = new webshopContext())
            {
                var result = from prod in db.Products
                             where prod.ProductId == productId
                             select prod;
                product ??= result.FirstOrDefault();
            }
                return product;
        }

        public static int GetProductStockQuantity(int productId)
        {
            using (var db = new webshopContext())
            {
                var result = from stock in db.StockBalances
                             where stock.ProductId == productId
                             select stock.Quantity;
                return result.FirstOrDefault();
            }
        }

        public static bool UpdateProductStock(int productId, int quantity)
        {
            using (var db = new webshopContext())
            {
                var result = db.StockBalances.Where(p => p.ProductId == productId);
                var product = result.FirstOrDefault();
                if (product != null)
                {
                    product.Quantity = quantity;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static List<Product> GetTopFeaturedProducts(int quantity)
        {
            using (var db = new webshopContext())
            {
                var result = (from featured in db.Products
                              where featured.Featured == true
                              select featured).Take(quantity); // we only want "quantity" amount of featured products

                return (result.ToList() != null) ? result.ToList() : null;
            }
        }

        public static List<ProductGroupCategoryQuery> GetAllProductsGroupedByCategory()
        {
            List<ProductGroupCategoryQuery> groups = new List<ProductGroupCategoryQuery>();
            using (var db = new webshopContext())
            {
                // Inner join and then group the result by categoryId
                var groupedResult = ((from category in db.Categories
                                      select category).ToList()
                                     ).GroupJoin((from product in db.Products select product).ToList(), cat => cat.CategoryId, prod => prod.CategoryId,
                                     (cat, prod) => new { cat, prod }
                                     );


                foreach (var item in groupedResult)
                {

                    groups.Add(new ProductGroupCategoryQuery
                    {
                        CategoryName = item.cat.Name,
                        ChildProducts = item.prod.ToList()
                    });
                }

            }
            return groups;
        }

        public static List<ProductGroupCategoryQuery> Search(string input)
        {
            bool isNumeric = int.TryParse(input, out _);
            List<ProductGroupCategoryQuery> group = new();

            using (var db = new webshopContext())
            {
                // Söka genom id
                if (isNumeric)
                {
                    var result = from prod in db.Products
                                 where prod.ProductId == int.Parse(input)
                                 select prod;
                    // Om id matchar
                    if (result.Count() > 0)
                    {
                        // hämta kategori
                        var catResult = db.Categories.Where(c => c.CategoryId == result.First().CategoryId);

                        group.Add(new ProductGroupCategoryQuery
                        {
                            CategoryName = catResult.First().Name,
                            ChildProducts = new List<Product>(result),
                        });
                    }
                }
                // Search category / product
                else
                {
                    // Select category
                    var catResult = db.Categories.Where(c => c.Name.ToLower().Contains(input.ToLower()));
                    if (catResult.Count() > 0)
                    {
                        var result = catResult.First();
                        var resultChildProducts = db.Products.Where(p => p.CategoryId == result.CategoryId).ToList();

                        group.Add(new ProductGroupCategoryQuery
                        {
                            CategoryName = result.Name,
                            ChildProducts = resultChildProducts,
                        }); ;
                    }
                    else
                    {
                        // select product name
                        var prodResult = db.Products.Where(p => p.Name.ToLower().Contains(input.ToLower())).ToList();
                        if (prodResult.Count() > 0)
                        {
                            var result = prodResult.First();
                            var resultCategory = db.Categories.Where(c => c.CategoryId == result.CategoryId).First();

                            group.Add(new ProductGroupCategoryQuery
                            {
                                CategoryName = resultCategory.Name,
                                ChildProducts = prodResult,
                            }); ;
                        }
                    }
                }
                
                return group;
            }
        }

        // Get Payment methods 
        public static List<PaymentMethod> GetPaymentMethods()
        {
            List<PaymentMethod> methods = new();
            // Select all
            using (var db = new webshopContext())
            {
                var result = from method in db.PaymentMethods
                             select method;

                foreach (var item in result)
                {
                    methods.Add(item);
                }
                
            }

            return methods;
        }

        // Get all shipping methods
        public static List<ShippingMethod> GetShippingMethods()
        {
            List<ShippingMethod> methods = new();
            // Select all
            using (var db = new webshopContext())
            {
                var result = from method in db.ShippingMethods
                             select method;

                foreach (var item in result)
                {
                    methods.Add(item);
                }
            }
            return methods;
        }

        public static decimal GetShippingCost(int shippingMethodId)
        {
            // Select where
            using (var db = new webshopContext())
            {
                var result = from shipping in db.ShippingMethods
                             where shipping.ShippingMethodId == shippingMethodId
                             select shipping.Price;

                return result.FirstOrDefault();
            }
        }

        // Create the order in the database
        public static bool CreateOrder(string name, string adress, string telephone, string mail, int sex, string paymentDetails, int paymentMethodId, int shippingMethodId)
        {
            using (var db = new webshopContext())
            {
                try
                {
                    // Create the customer
                    Customer customer = new Customer();
                    customer.Name = name;
                    customer.Address = adress;
                    customer.Telephone = telephone;
                    customer.Mail = mail;
                    customer.Sex = sex switch
                    {
                        0 => false,
                        1 => true,
                        _ => false
                    };

                    db.Customers.Add(customer);
                    db.SaveChanges();

                    // Create the payment detail
                    PaymentDetail paymentDetail = new PaymentDetail();
                    paymentDetail.PaymentMethodId = paymentMethodId;
                    paymentDetail.Value = paymentDetails;

                    db.PaymentDetails.Add(paymentDetail);
                    db.SaveChanges();

                    // Create the order
                    Order order = new Order();
                    order.OrderDate = DateTime.Now;
                    order.ShippingMethodId = shippingMethodId;
                    order.PaymentDetailId = paymentDetail.PaymentDetailId;
                    order.CustomerId = customer.CustomerId;
                    order.Complete = false;

                    db.Orders.Add(order);
                    db.SaveChanges();

                    // Iterate through every product, add that to database and subtract from stock balance
                    foreach (var item in Cart.Items)
                    {
                        OrderDetail newOrderDetail = new OrderDetail();
                        newOrderDetail.OrderId = order.OrderId;
                        newOrderDetail.ProductId = item.ProductId;
                        newOrderDetail.Quantity = item.Quantity;
                        db.OrderDetails.Add(newOrderDetail);
                        db.SaveChanges();
                        RemoveFromStock(item.ProductId, item.Quantity);
                        
                    }
                    return true;
                } catch (Exception)
                {
                    return false;
                }
            }
        }

        // Get complete order info with joined tables
        public static OrderQuery getOrder(int orderId)
        {
            using (var db = new webshopContext())
            {
                var ordered = db.OrderDetails.Where(o => o.OrderId == orderId);

                var result = from
                                order in db.Orders
                             where
                                order.OrderId == orderId
                             join
                                shippingMethod in db.ShippingMethods on order.ShippingMethodId equals shippingMethod.ShippingMethodId
                             join
                                paymentDetail in db.PaymentDetails on order.PaymentDetailId equals paymentDetail.PaymentDetailId
                             join
                                customer in db.Customers on order.CustomerId equals customer.CustomerId
                             join
                                orderDetails in db.OrderDetails on order.OrderId equals orderDetails.OrderId

                             select new OrderQuery { Order = order, ShippingMethod = shippingMethod, PaymentDetail = paymentDetail, Customer = customer, OrderDetails = ordered.ToList()};

                var orderQuery = result.FirstOrDefault();

                return orderQuery;
            }
        }

        public static void RemoveFromStock(int productId, int qtyRemoved)
        {
            using (var db = new webshopContext())
            {
                var result = db.StockBalances.Where(s => s.ProductId == productId).FirstOrDefault();

                if (result != null)
                {
                    result.Quantity -= qtyRemoved;
                    db.SaveChanges();
                }
            }
        }

        // Return tuple of both bool value (if enough is in stock) and the quantity so we don't have to make another db request (of quantity) when displaying error message to the customer
        public static (bool, int) CheckProductQtyInStock(int productId, int qty)
        {
            using (var db = new webshopContext())
            {
                var result = db.StockBalances.Where(s => s.ProductId == productId).FirstOrDefault();

                if (result != null)
                {
                    return result.Quantity >= qty ? (true, result.Quantity) : (false, result.Quantity);
                }
            }
            return (false, 0);
        }
    }

}
