using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FinAppUI.Models
{
    public class WalletDisplayModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string WalletName { get; set; }
        private decimal _currentAmount;

        public decimal CurrentAmount
        {
            get 
            { 
                return _currentAmount; 
            }
            set
            {
                _currentAmount = value;
                CallPropertyChanged(nameof(CurrentAmount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
