using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class OrderProcessor
    {
        private ICustomerNotifier _customerNotifier;

        public OrderProcessor(ICustomerNotifier customerNotifier)
        {
            this._customerNotifier = customerNotifier ?? throw new ArgumentNullException("customerNotifier");
        }

        public void SendConfirmation(Customer customer, string orderNumber)
        {
            var body = $"Order number {orderNumber} has been confirmed";

            _customerNotifier.NotifyCustomer(customer, "Order Confirmation", body);
        }
    }
}
