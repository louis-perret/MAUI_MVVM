using ViewModel;

namespace Views.Pages;

public partial class CharacterPage : ContentPage
{

    public CharacterPage()
	{
		InitializeComponent();
		BindingContext = (Application.Current as App).AppVM;
	}
}
