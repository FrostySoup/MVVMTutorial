namespace MVVMTutorial.ViewModels
{
    using System;
    using Models;
    using System.Diagnostics;
    using System.Windows.Input;
    using Commands;
    using Views;
    using SwitchViewModel;

    /// <summary>
    /// Initializes a new instance of the CustomerViewModel class
    /// </summary>
    internal class CustomerViewModel : BaseViewModel
    {
        private Customer customer;
        private CustomerInfoViewModel childViewModel;
        public BaseViewModel viewModel { get; set; }

        public int CurrentView { get; set; }

        public ICommand LoadHomePageCommand { get; private set; }
        public ICommand LoadSettingsPageCommand { get; private set; }

        public ICommand LoadPlayPageCommand { get; private set; }

        public BaseViewModel ViewModel
        {
            get { return viewModel; }
            set
            {
                viewModel = value;
                this.OnPropertyChanged("ViewModel");
            }
        }

        public CustomerViewModel()
        {
            customer = new Customer("Giedrius", 22);
            UpdateCommand = new CustomerUpdateCommand(this);
            childViewModel = new CustomerInfoViewModel();

            this.LoadHomePageCommand = new DelegateCommand(o => this.LoadHomePage());
            this.LoadSettingsPageCommand = new DelegateCommand(o => this.LoadSettingsPage());
            this.LoadPlayPageCommand = new DelegateCommand(o => this.LoadPlayPage());
        }

        private void LoadPlayPage()
        {
            ViewModel = new PlayViewModel(
               new PlayPage() { Name = "GoodUser3000",
                                IsAlive = true,
                                Level = 99
               });
        }

        private void LoadHomePage()
        {
            ViewModel = new HomeViewModel(
                new HomePage() { Title = "This is the Home Page." });
        }

        private void LoadSettingsPage()
        {
            ViewModel = new WorkViewModel(
                new WorkPage() { Title = "This is the Work Page." ,
                                 Number = 25515426
                });
        }

        public Customer Customer
        {
            get
            {
                return customer;
            }           
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        public void SaveChanges()
        {
            ViewModel = new HomeViewModel(new HomePage());
            CustomerInfoView view = new CustomerInfoView();
            view.DataContext = childViewModel;

            childViewModel.Info = Customer.Name + " was updated in the database";

            view.ShowDialog();
        }
    }
}
