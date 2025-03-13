using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace MacroForge.ViewModels;

public class MainViewModel
{
    private readonly INavigationService _navigationService;
    public ICommand NavigationCommand;

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        NavigationCommand = new RelayCommand(() => _navigationService.NavigateTo<CreateMacro>());
    }
}