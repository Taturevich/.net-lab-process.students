using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace MvvmUseCases.ViewModels
{
    public class SecondTabViewModel : Screen
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private BitmapImage _internetImage;
        private string _inputText;

        public SecondTabViewModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>Called when activating.</summary>
        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await base.OnActivateAsync(cancellationToken);
            await using var imageStream = await _httpClientFactory.CreateClient().GetStreamAsync(
                "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.AuEEM_Ss5G9zAHEX6p9ndgHaD1%26pid%3DApi&f=1");
            await using var memoryStream = new MemoryStream();
            await imageStream.CopyToAsync(memoryStream, cancellationToken).ConfigureAwait(false);
            memoryStream.Position = 0;
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = memoryStream;
            bitmap.EndInit();
            InternetImage = bitmap;
        }

        public BitmapImage InternetImage
        {
            get => _internetImage;
            set => Set(ref _internetImage, value);
        }

        public string InputText
        {
            get => _inputText;
            set => Set(ref _inputText, value);
        }
    }
}
