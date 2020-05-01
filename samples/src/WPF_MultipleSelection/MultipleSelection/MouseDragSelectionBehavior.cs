using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MultipleSelection
{
    public class MouseDragSelectionBehavior : Behavior<Grid>
    {
        private bool _isMouseDown;
        private Point _mouseDownPos; // The point where the mouse button was clicked down
        private Canvas _itemsCanvas;
        private Canvas _selectionCanvas;
        private Rectangle _selectionBox;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseDown += AssociatedObjectOnMouseDown;
            AssociatedObject.MouseUp += AssociatedObjectOnMouseUp;
            AssociatedObject.MouseMove += AssociatedObjectOnMouseMove;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseDown -= AssociatedObjectOnMouseDown;
            AssociatedObject.MouseUp -= AssociatedObjectOnMouseUp;
            AssociatedObject.MouseMove -= AssociatedObjectOnMouseMove;
        }

        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMouseDown)
            {
                return;
            }

            // When the mouse is held down, reposition the drag selection box.
            var selectionBox = GetSelectionBox(AssociatedObject);
            var mousePosition = e.GetPosition(AssociatedObject);

            if (_mouseDownPos.X < mousePosition.X)
            {
                Canvas.SetLeft(selectionBox, _mouseDownPos.X);
                selectionBox.Width = mousePosition.X - _mouseDownPos.X;
            }
            else
            {
                Canvas.SetLeft(selectionBox, mousePosition.X);
                selectionBox.Width = _mouseDownPos.X - mousePosition.X;
            }

            if (_mouseDownPos.Y < mousePosition.Y)
            {
                Canvas.SetTop(selectionBox, _mouseDownPos.Y);
                selectionBox.Height = mousePosition.Y - _mouseDownPos.Y;
            }
            else
            {
                Canvas.SetTop(selectionBox, mousePosition.Y);
                selectionBox.Height = _mouseDownPos.Y - mousePosition.Y;
            }
        }

        private void AssociatedObjectOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Release the mouse capture and stop tracking it.
            _isMouseDown = false;
            AssociatedObject?.ReleaseMouseCapture();

            // Hide the drag selection box.
            var selectionBox = GetSelectionBox(AssociatedObject);
            selectionBox.Visibility = Visibility.Collapsed;

            // Finding intersection between 2 areas in grid (it will be our selected element)
            var selectionGeometry = GetGeometry(selectionBox);
            var itemsCanvas = _itemsCanvas ??= FindElementByName<Canvas>(AssociatedObject, "ItemsArea");
            foreach (Rectangle child in itemsCanvas.Children)
            {
                var childItemGeometry = GetGeometry(child);
                var intersection = selectionGeometry.FillContainsWithDetail(childItemGeometry);

                // Here you can perform all actions necessary in order to handle selection or un-selection
                child.Fill = intersection != IntersectionDetail.Empty ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.Aqua);
            }
        }

        private void AssociatedObjectOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Capture and track the mouse.
            _isMouseDown = true;
            _mouseDownPos = e.GetPosition(AssociatedObject);
            AssociatedObject.CaptureMouse();
            var selectionBox = GetSelectionBox(AssociatedObject);

            // Initial placement of the drag selection box.         
            Canvas.SetLeft(selectionBox, _mouseDownPos.X);
            Canvas.SetTop(selectionBox, _mouseDownPos.Y);
            selectionBox.Width = 0;
            selectionBox.Height = 0;

            // Make the drag selection box visible.
            selectionBox.Visibility = Visibility.Visible;
        }

        private Rectangle GetSelectionBox(DependencyObject parentPanel)
        {
            _selectionCanvas ??= FindElementByName<Canvas>(parentPanel, "SelectionArea");
            return _selectionBox ??= FindElementByName<Rectangle>(_selectionCanvas, "SelectionBox");
        }

        private static T FindElementByName<T>(DependencyObject element, string childName)
            where T : FrameworkElement
        {
            T childElement = null;
            var childCount = VisualTreeHelper.GetChildrenCount(element);
            for (var i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(element, i) as FrameworkElement;
                if (child == null)
                {
                    continue;
                }

                if (child is T frameworkElement && frameworkElement.Name.Equals(childName))
                {
                    childElement = frameworkElement;
                    break;
                }

                childElement = FindElementByName<T>(child, childName);

                if (childElement != null)
                {
                    break;
                }
            }

            return childElement;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/46758647/wpf-how-to-detect-geometry-intersection-on-canvas
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static Geometry GetGeometry(Shape s)
        {
            var geometry = s.RenderedGeometry.Clone();
            geometry.Transform = GetFullTransform(s);
            return geometry;
        }

        private static Transform GetFullTransform(UIElement e)
        {
            // The order in which transforms are applied is important!
            var transforms = new TransformGroup();

            if (e.RenderTransform != null)
            {
                transforms.Children.Add(e.RenderTransform);
            }

            var xTranslate = (double)e.GetValue(Canvas.LeftProperty);
            if (double.IsNaN(xTranslate))
            {
                xTranslate = 0D;
            }

            var yTranslate = (double)e.GetValue(Canvas.TopProperty);
            if (double.IsNaN(yTranslate))
            {
                yTranslate = 0D;
            }

            var translateTransform = new TranslateTransform(xTranslate, yTranslate);
            transforms.Children.Add(translateTransform);

            return transforms;
        }
    }
}
