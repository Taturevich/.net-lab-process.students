using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MvvmUseCases
{
    public interface IDialogs
    {
        void ShowWindow<T>();

        bool? ShowDialog<T>();
    }

    public class Dialogs : IDialogs
    {
        private readonly IViewModelFactory _viewModelFactory;

        public Dialogs(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void ShowWindow<T>()
        {
            var window = new Window
            {
                Content = LocateViewFor<T>(),
                DataContext = _viewModelFactory.Create<T>(),
            };
            window.Show();
        }

        public bool? ShowDialog<T>()
        {
            var window = LocateViewFor<T>();
            window.DataContext = _viewModelFactory.Create<T>();
            return window.ShowDialog();
        }

        private Window LocateViewFor<T>()
        {
            var typeName = typeof(T).Name;
            var viewModelIndex = typeName.LastIndexOf("ViewModel", StringComparison.Ordinal);
            var pureTypeName = typeName.Remove(viewModelIndex, "ViewModel".Length);
            var viewTypeName = pureTypeName + "View";
            var viewNamespace = "MvvmUseCases.Views.";
            var viewType = Type.GetType(viewNamespace + viewTypeName);
            return Activator.CreateInstance(viewType ?? throw new InvalidOperationException()) as Window;
        }
    }
}
