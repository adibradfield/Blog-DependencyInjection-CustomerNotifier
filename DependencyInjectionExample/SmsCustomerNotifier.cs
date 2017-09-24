using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextmagicRest;

namespace DependencyInjectionExample
{
    class SmsCustomerNotifier : ICustomerNotifier
    {
        public void NotifyCustomer(Customer customer, string Title, string Message)
        {
            var username = ConfigurationManager.AppSettings["SmsUsername"];
            var key = ConfigurationManager.AppSettings["SmsApiKey"];
            var formattedMessage = Title + Environment.NewLine + Message;

            var client = new Client(username, key);
            client.SendMessage(formattedMessage, customer.MobileNumber);
        }
    }
}
