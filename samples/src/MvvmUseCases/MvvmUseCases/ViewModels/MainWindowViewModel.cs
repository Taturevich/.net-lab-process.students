using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace MvvmUseCases.ViewModels
{
    public class MainWindowViewModel : Conductor<Screen>.Collection.AllActive, IHandle<SimpleMessage>
    {
        private readonly IDialogs _dialogs;
        private readonly IEventAggregator _eventAggregator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        public MainWindowViewModel(
            IDialogs dialogs,
            IEventAggregator eventAggregator,
            IViewModelFactory viewModelFactory,
            IHttpClientFactory httpClientFactory)
        {
            _dialogs = dialogs;
            _eventAggregator = eventAggregator;
            _viewModelFactory = viewModelFactory;
            _httpClientFactory = httpClientFactory;
            _eventAggregator.SubscribeOnPublishedThread(this);
        }

        /// <summary>Called when initializing.</summary>
        protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            await base.OnInitializeAsync(cancellationToken);
            Items.Add(_viewModelFactory.Create<FirstTabViewModel>());
            Items.Add(_viewModelFactory.Create<SecondTabViewModel>());
        }

        /// <summary>Called when activating.</summary>
        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await base.OnActivateAsync(cancellationToken);
        }

        public void ShowChildCommand()
        {
            _dialogs.ShowDialog<ChildWindowViewModel>();
        }

        public Task HandleAsync(SimpleMessage message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
