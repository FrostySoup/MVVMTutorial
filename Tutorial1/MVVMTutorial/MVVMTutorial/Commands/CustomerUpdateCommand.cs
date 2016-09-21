namespace MVVMTutorial.Commands
{
    using System.Windows.Input;
    using ViewModels;

    internal class CustomerUpdateCommand : ICommand
    {
        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        private CustomerViewModel _ViewModel;

        #region ICommand Members

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            _ViewModel.SaveChanges();
        }

        #endregion
    }
}
