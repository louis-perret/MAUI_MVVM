using ViewModel;

namespace Views.Pages;

public partial class NewChampionPage : ContentPage
{

    public NewChampionPage()
	{
        BindingContext = (Application.Current as App).AppVM;
        InitializeComponent();
    }
}
