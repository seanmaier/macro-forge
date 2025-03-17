using System.Windows;

namespace MacroForge.Views;

public partial class EditMacro : Window
{
    public EditMacro()
    {
        InitializeComponent();
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);
        window?.Close();
    }
}