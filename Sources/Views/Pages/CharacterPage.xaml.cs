using ViewModel;

namespace Views.Pages;

public partial class CharacterPage : ContentPage
{

    public AppVM AppVM { get; private set; }

    public CharacterPage(AppVM appVM)
	{
		InitializeComponent();
		AppVM = appVM;
		BindingContext = AppVM;
	}
}
