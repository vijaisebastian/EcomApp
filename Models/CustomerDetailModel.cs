using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcomApp.Models
{
    public class CustomerDetailModel
    {
        public CustomerModel customer { get; set; }
        public OrderModel order { get; set; }
    }

    public class CustomerModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    public class OrderModel
    {
        public int orderNumber { get; set; }
        public DateTime? orderDate { get; set; }
        public string deliveryAddress { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
        public DateTime? deliveryExpected { get; set; }
    }
    public class OrderItemModel
    {
        public string product { get; set; }
        public int? quantity { get; set; }
        public decimal? priceEach { get; set; }
    }
}