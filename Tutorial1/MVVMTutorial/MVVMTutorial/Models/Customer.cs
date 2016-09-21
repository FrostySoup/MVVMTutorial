using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTutorial.Models
{
    public class Customer : INotifyPropertyChanged
    {
        public Customer(string customerName)
        {
            Name = customerName;
        }

        private string _Name;

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
