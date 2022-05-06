using EcomApp.Models;
using System.Web.Http;

namespace EcomApp.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomerApiController : ApiController
    {
        /// <summary>
        /// Gets the customer with latest order
        /// </summary>
        /// <param name="p_Customer">A model contains customerID and customer email</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public CustomerDetailModel GetLatestOrder([FromBody] CustomerDataModel p_Customer)
        {
            CustomerController objCustomerController = new CustomerController();
            return objCustomerController.SearchCustomer(p_Customer);
        }
    }
}
