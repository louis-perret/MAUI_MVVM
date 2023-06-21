using System.Windows.Input;
using ViewModel;

namespace Views.Pages;

/// <summary>
/// Master de l'application
/// </summary>
public partial class CharactersLibraryPage : ContentPage
{
    /// <summary>
    /// VM applicative
    /// </summary>
    public AppVM AppVM { get; private set; }

    public CharactersLibraryPage(AppVM appVM)
    {
        InitializeComponent();
        AppVM = appVM;
        AppVM.Navigation = this.Navigation;
        BindingContext = AppVM;
    }
}
