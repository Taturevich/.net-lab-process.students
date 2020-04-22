using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace MvvmUseCases
{
    public interface IViewModelFactory
    {
        T Create<T>();
    }

    public class ViewModelFactory : IViewModelFactory
    {
        public T Create<T>() => IoC.Get<T>();
    }
}
