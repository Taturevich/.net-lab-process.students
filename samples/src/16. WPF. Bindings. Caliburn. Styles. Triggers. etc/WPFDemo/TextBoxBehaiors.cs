using System;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace WPFDemo
{
    public class TextBoxBehaiors : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.TextChanged += AssociatedObjectOnTextChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= AssociatedObjectOnTextChanged;
            base.OnDetaching();
        }

        private void AssociatedObjectOnTextChanged(object sender, TextChangedEventArgs args)
        {
            var textBox = (TextBox) sender;
            if (textBox.Text == "red")
            {
                textBox.Background = Brushes.Red;
            }
        }
    }
}