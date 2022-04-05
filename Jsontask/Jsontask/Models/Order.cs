using System;
using System.Collections.Generic;
using System.Text;

namespace Jsontask.Models
{
    class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
