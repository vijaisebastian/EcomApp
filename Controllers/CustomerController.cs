using EcomApp.Models;
using System;
using System.Linq;
using System.Web;

namespace EcomApp.Controllers
{
    public class CustomerController
    {
        private EcomAppDataEntities db = new EcomAppDataEntities();
        public CustomerDetailModel SearchCustomer(CustomerDataModel p_Customer)
        {
            var customer = db.CUSTOMERs.FirstOrDefault(c => c.CUSTOMERID == p_Customer.customerId);

            if (customer == null)
                throw new InvalidOperationException("Customer not found!");

            if (customer.EMAIL != p_Customer.user)
                throw new HttpException(404, "Not found");

            var order = db.Orders
                .Where(o => o.CUSTOMERID == p_Customer.customerId)
                .OrderByDescending(o => o.ORDERDATE)
                .FirstOrDefault();

            var customerModel = new CustomerModel { firstName = customer.FIRSTNAME, lastName = customer.LASTNAME };

            var customerDetail = new CustomerDetailModel { customer = customerModel };

            if (order != null)
            {
                var orderModel = new OrderModel
                {
                    OrderItems = order.OrderItems.Select(oi => new OrderItemModel
                    {
                        priceEach = oi.PRICE,
                        product = order.CONTAINSGIFT == true? "Gift" : oi.Product.PRODUCTNAME,
                        quantity = oi.QUANTITY
                    }).ToList(),
                    orderNumber = order.ORDERID,
                    deliveryExpected = order.DELIVERYEXPECTED,
                    orderDate = order.ORDERDATE,
                    deliveryAddress = customer.ADDRESS
                };

                customerDetail.order = orderModel;
            }

            return customerDetail;
        }
    }
}
