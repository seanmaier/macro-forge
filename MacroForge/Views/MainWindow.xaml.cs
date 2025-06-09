using System.Runtime.InteropServices;
using System.Windows;
using MacroForge.Recorder;
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



    public void testinputs()
    {
        MacroData macro = new MacroData("inputtest");

        MacroStep mstep = new MacroStep(CommandType.MouseEvent, 0);
        mstep.NewInput(InputType.Mouse, 100, 100, (MouseEventF.Move | MouseEventF.LeftDown));
        macro.MacroSteps.Add(mstep);

        mstep = new MacroStep(CommandType.MouseEvent, 0);
        mstep.NewInput(InputType.Mouse, -100, -100, MouseEventF.LeftUp);
        macro.MacroSteps.Add(mstep);

        MacroStep step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x23, (KeyEventF.KeyDown | (KeyEventF.KeyDown | KeyEventF.KeyUp)));
        macro.MacroSteps.Add(step);
        step.NewInput(InputType.Keyboard, 0x23, (KeyEventF.KeyDown | KeyEventF.KeyUp));
        step = new MacroStep(CommandType.KeyboardEvent, 0);
        macro.MacroSteps.Add(step);

        step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x1e, (KeyEventF.KeyDown | (KeyEventF.KeyDown | KeyEventF.KeyUp)));
        macro.MacroSteps.Add(step);
        step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x1e, (KeyEventF.KeyDown | KeyEventF.KeyUp));
        macro.MacroSteps.Add(step);

        step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x26, (KeyEventF.KeyDown | (KeyEventF.KeyDown | KeyEventF.KeyUp)));
        macro.MacroSteps.Add(step);
        step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x26, (KeyEventF.KeyDown | KeyEventF.KeyUp));
        macro.MacroSteps.Add(step);

        step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x26, (KeyEventF.KeyDown | (KeyEventF.KeyDown | KeyEventF.KeyUp)));
        macro.MacroSteps.Add(step);
        step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x26, (KeyEventF.KeyDown | KeyEventF.KeyUp));
        macro.MacroSteps.Add(step);

        step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x18, (KeyEventF.KeyDown | (KeyEventF.KeyDown | KeyEventF.KeyUp)));
        macro.MacroSteps.Add(step);
        step = new MacroStep(CommandType.KeyboardEvent, 0);
        step.NewInput(InputType.Keyboard, 0x18, (KeyEventF.KeyDown | KeyEventF.KeyUp));
        macro.MacroSteps.Add(step);


        


        Player player = new Player();
        player.PlayMacro(macro);
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        testinputs();

    }
}
