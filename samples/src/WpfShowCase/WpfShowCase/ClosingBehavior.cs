using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;

namespace WpfShowCase
{
    public class ClosingBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Closing += AssociatedObject_Closing;
        }

        private void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
                AssociatedObject.Height = UserSize;
            }
        }

        public static readonly DependencyProperty UserSizeProperty = DependencyProperty.Register("UserSize", typeof(double), typeof(ClosingBehavior));

        public double UserSize
        {
            get { return (double)GetValue(UserSizeProperty); }
            set { SetValue(UserSizeProperty, value); }
        }
    }
}
