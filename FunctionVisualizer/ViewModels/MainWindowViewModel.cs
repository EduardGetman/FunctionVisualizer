using System;
using FunctionVisualizer.ViewModels.Base;

namespace FunctionVisualizer.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Визуализатор математических функций";
        public string Title 
        {
            get => _Title;
            set => Set(ref _Title, value);     
        }
    }
}
