using Jsontask.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Jsontask
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Chips = new Product { Id = 1, Name = "Lays", Price = 2.30 };
            Product Drink = new Product { Id = 2, Name = "Coca-Cola", Price = 1.70 };
            Product Chocolate = new Product { Id = 3, Name = "Snikers", Price = 1.70 };
            OrderItem item1 = new OrderItem { Id = 2, Product = Drink, Count = 1, TotalPrice = Drink.Price * 1 };
            OrderItem item2 = new OrderItem { Id = 1, Product = Chips, Count = 2, TotalPrice = Chips.Price * 2 };
            OrderItem item3 = new OrderItem { Id = 3, Product = Chocolate, Count = 3, TotalPrice = Chocolate.Price * 3 };
            OrderItem item4 = new OrderItem { Id = 4, Product = Drink, Count = 2, TotalPrice = Drink.Price * 2 };
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(item1);
            orderItems1.Add(item2);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(item3);
            orderItems2.Add(item4);
            Order order1 = new Order { Id = 1, OrderItems = orderItems1 };
            Order order2 = new Order { Id = 3, OrderItems = orderItems2 };
            #region Serialize
            var jsonObj = JsonConvert.SerializeObject(order2);
            Console.WriteLine(jsonObj);
            using (StreamWriter sw=new StreamWriter(@"C:\Users\Admin\Desktop\home work\Jsontask\Jsontask\Files\json.json"))
            {
                sw.WriteLine(jsonObj);
            }
            #endregion
            #region Deserialize
            string result;
            using (StreamReader sr = new StreamReader(@"C:\Users\Admin\Desktop\home work\Jsontask\Jsontask\Files\json.json"))
            {
                result = sr.ReadToEnd();
            }
            Order or1 = JsonConvert.DeserializeObject<Order>(result);
            Console.WriteLine(or1.OrderItems[1].Product.Name);

            #endregion
        }
    }
}
