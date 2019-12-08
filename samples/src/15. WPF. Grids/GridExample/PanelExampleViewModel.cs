using Caliburn.Micro;
using WPFDemo.Triggers;

namespace WPFDemo.GridExample
{
    public class PanelExampleViewModel : PropertyChangedBase
    {
        private string _textValue;
        private int _integerValue;

        public string TextValue
        {
            get { return _textValue; }
            set { Set(ref _textValue, value); }

        }

        public bool CanSomeCommand => true;

        public void SomeCommand()
        {
        }

        public bool CanTextValue => false;

        public int IntegerValue
        {
            get { return _integerValue; }
            set { Set(ref _integerValue, value); }
        }
    }
}