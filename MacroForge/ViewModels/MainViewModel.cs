using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MacroForge.Interfaces;
using MacroForge.Views;

namespace MacroForge.ViewModels;

public class MainViewModel
{
    private readonly INavigationService _navigationService;
    public ICommand NavigationCommand { get; }

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        NavigationCommand = new RelayCommand(() => _navigationService.NavigateTo<CreateMacro>());
    }
}