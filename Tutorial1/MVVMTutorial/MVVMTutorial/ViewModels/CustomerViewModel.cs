namespace MVVMTutorial.ViewModels
{
    using System;
    using Models;
    using System.Diagnostics;
    using System.Windows.Input;
    using Commands;

    /// <summary>
    /// Initializes a new instance of the CustomerViewModel class
    /// </summary>
    internal class CustomerViewModel
    {
        private Customer _Customer;

        public CustomerViewModel()
        {
            _Customer = new Customer("Giedrius");
            UpdateCommand = new CustomerUpdateCommand(this);
        }

        public bool CanUpdate {
            get
            {
                if (Customer == null)
                {
                    return false;
                }
                return !String.IsNullOrWhiteSpace(Customer.Name);
            }
        }

        public Customer Customer
        {
            get
            {
                return _Customer;
            }           
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        public void SaveChanges()
        {
            Debug.Assert(false, String.Format("{0} was updated", Customer.Name));
        }
    }
}
