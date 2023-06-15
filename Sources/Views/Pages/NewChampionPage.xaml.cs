using ViewModel;

namespace Views.Pages;

public partial class NewChampionPage : ContentPage
{

    public AppVM AppVM { get; private set; }

    public NewChampionPage(AppVM appVM)
	{
        this.AppVM = appVM;
        BindingContext = AppVM;
        InitializeComponent();
    }
}
