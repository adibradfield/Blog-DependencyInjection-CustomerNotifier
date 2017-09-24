using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class PreferentialCustomerNotifier : ICustomerNotifier
    {
        private SmtpCustomerNotifier smtpNotifier;
        private SmsCustomerNotifier smsNotifier;

        public PreferentialCustomerNotifier(SmtpCustomerNotifier smtpCustomerNotifier, SmsCustomerNotifier smsCustomerNotifier)
        {
            this.smtpNotifier = smtpCustomerNotifier ?? throw new ArgumentNullException("smtpCustomerNotifier");
            this.smsNotifier = smsCustomerNotifier ?? throw new ArgumentNullException("smsCustomerNotifier");
        }

        public void NotifyCustomer(Customer customer, string Title, string Message)
        {
            if (customer.SendNotificationsByEmail)
            {
                this.smtpNotifier.NotifyCustomer(customer, Title, Message);
            }

            if (customer.SendNotificationsByText)
            {
                this.smsNotifier.NotifyCustomer(customer, Title, Message);
            }
        }
    }
}
