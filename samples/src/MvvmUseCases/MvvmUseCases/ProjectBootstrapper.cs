using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using Microsoft.Extensions.DependencyInjection;
using MvvmUseCases.ViewModels;

namespace MvvmUseCases
{
    public class ProjectBootstrapper : BootstrapperBase
    {
        private ServiceProvider _serviceProvider;

        public ProjectBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            base.Configure();
            var collection = new ServiceCollection();
            collection.AddHttpClient();
            collection.AddSingleton<IWindowManager, WindowManager>();
            collection.AddSingleton<IEventAggregator, EventAggregator>();
            collection.AddSingleton<IViewModelFactory, ViewModelFactory>();
            collection.AddSingleton<IDialogs, Dialogs>();
            var viewModels = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name.EndsWith("ViewModel") && !x.IsAbstract && !x.IsInterface);
            foreach (var viewModel in viewModels)
            {
                collection.AddTransient(viewModel, viewModel);
            }

            _serviceProvider = collection.BuildServiceProvider();
        }

        protected override object GetInstance(Type serviceType, string key) => _serviceProvider.GetService(serviceType);

        protected override IEnumerable<object> GetAllInstances(Type serviceType) => _serviceProvider.GetServices(serviceType);

        /// <summary>
        /// Override this to add custom behavior to execute after the application starts.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The args.</param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
    }
}
