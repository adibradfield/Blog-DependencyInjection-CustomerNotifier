using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<OrderProcessor>();
            container.RegisterType<SmtpCustomerNotifier>();
            container.RegisterType<SmsCustomerNotifier>();
            container.RegisterType<ICustomerNotifier, PreferentialCustomerNotifier>();

            var root = container.Resolve<OrderProcessor>();
            var customer = new Customer()
            {
                Name = "Joe Bloggs",
                Email = "j.bloggs@example.com",
                MobileNumber = "441234567899",
                SendNotificationsByEmail = false,
                SendNotificationsByText = true
            };

            root.SendConfirmation(customer, "ABCD123");
        }
    }
}
