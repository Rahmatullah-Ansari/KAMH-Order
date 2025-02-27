﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KAMH_Order_Sender.Utility
{
    public class BindableBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            // This differs from a mere set. If objects/values are same it doesn't fire property changed.
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
