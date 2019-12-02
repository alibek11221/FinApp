using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinAppUI.ViewModels
{
    public class TransitionViewModel : Screen
    {
        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public TransitionViewModel()
        {
        }
    }
}
