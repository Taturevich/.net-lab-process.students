using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using WPFDemo.Triggers;

namespace WPFDemo.GridExample
{
    public class PanelExampleViewModel : PropertyChangedBase
    {
        private string _textValue;
        private int _integerValue;
        private bool _isBusy = true;

        public string TextValue
        {
            get { return _textValue; }
            set { Set(ref _textValue, value); }

        }

        public bool CanSomeCommand => true;

        public async void StartDoing()
        {
            IsBusy = false;
            await Task.Run(() => throw new Exception("123"))
                .ContinueWith(task =>
                {
                    throw task.Exception.InnerExceptions[0];
                    return IsBusy = true;
                });
            MessageBox.Show("Im done");
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { Set(ref _isBusy, value); }
        }

        public bool CanTextValue => false;

        public int IntegerValue
        {
            get { return _integerValue; }
            set { Set(ref _integerValue, value); }
        }
    }
}