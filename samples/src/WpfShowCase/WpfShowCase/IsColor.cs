using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfShowCase
{
    public static class IsColor
    {
        public static readonly DependencyProperty IsBubbleSourceProperty = DependencyProperty.RegisterAttached(
            "IsColorRed",
            typeof(bool),
            typeof(IsColor),
            new PropertyMetadata(null));

        public static void SetIsColorRed(UIElement element, bool value)
        {
            element.SetValue(IsBubbleSourceProperty, value);
        }

        public static bool GetIsColorRed(UIElement element)
        {
            return (bool)element.GetValue(IsBubbleSourceProperty);
        }
    }
}
