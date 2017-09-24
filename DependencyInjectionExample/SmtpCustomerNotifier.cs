using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class SmtpCustomerNotifier : ICustomerNotifier
    {
        public void NotifyCustomer(Customer customer, string Title, string Message)
        {
            var host = ConfigurationManager.AppSettings["EmailHost"];
            var username = ConfigurationManager.AppSettings["EmailUsername"];
            var password = ConfigurationManager.AppSettings["EmailPassword"];
            var from = ConfigurationManager.AppSettings["EmailFrom"];

            var client = new SmtpClient(host)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(username, password)
            };

            client.Send(from, customer.Email, Title, Message);

        }
    }
}
