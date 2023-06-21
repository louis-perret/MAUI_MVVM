using ViewModel;

namespace Views.Pages;

/// <summary>
/// Detail d'un champion
/// </summary>
public partial class CharacterPage : ContentPage
{
	/// <summary>
	/// VM applicative
	/// </summary>
    public AppVM AppVM { get; private set; }

    public CharacterPage(AppVM appVM)
	{
		InitializeComponent();
		AppVM = appVM;
		BindingContext = AppVM;
	}
}
