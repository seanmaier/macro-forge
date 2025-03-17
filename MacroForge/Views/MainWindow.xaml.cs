using System.Collections.ObjectModel;
using System.Windows;
using MacroForge.Services;
using MacroForge.ViewModels;

namespace MacroForge.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainViewModel(new NavigationService());
        
        // TODO aufrauemen wenn wir weiter sind
        MacroDataList mdl = new MacroDataList();

        FileHandler fileHandler = new FileHandler();
        fileHandler.LoadMacrosFromFiles(mdl);


        MacroDataGrid.ItemsSource = mdl.Macros;

        // zu testzwecken direktes speichern muss natuerlich weg spaeter
        //fileHandler.SaveMacrosToFiles(mdl);
    }
}