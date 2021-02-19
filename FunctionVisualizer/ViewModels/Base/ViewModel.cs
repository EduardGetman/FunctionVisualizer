using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;

namespace FunctionVisualizer.ViewModels.Base
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string ProperyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ProperyName));
        }
        protected virtual bool Set<T>(ref T fieled, T value, [CallerMemberName] string ProperyName = null)
        {
            if (Equals(fieled, value))
                return false;
            OnPropertyChanged(ProperyName);
            return true;
        }
    }
}
