using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MacroForge.Interfaces;
using MacroForge.Views;

namespace MacroForge.ViewModels;

public class MainViewModel
{
    private readonly INavigationService _navigationService;
    public ICommand CreateMacroCommand { get; }
    public ICommand EditMacroCommand { get; }

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        CreateMacroCommand = new RelayCommand(() => _navigationService.NavigateTo<CreateMacro>());
        EditMacroCommand = new RelayCommand(() => _navigationService.NavigateTo<EditMacro>());
    }
}