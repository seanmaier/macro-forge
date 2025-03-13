using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MacroForge.Views
{
    public partial class TitleBarControl : UserControl
    {
        public TitleBarControl()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window? window = Window.GetWindow(this); // Get current window
            
            window?.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Window? window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }
        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window? window = Window.GetWindow(this);
            window?.Close();
        }
    }
}