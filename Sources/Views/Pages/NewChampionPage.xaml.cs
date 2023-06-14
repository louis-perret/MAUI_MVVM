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

    async void AddChampion(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        AppVM.ManagerVM.AddChampion();
        await Navigation.PopAsync();
    }

    async void CancelAddChampion(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        AppVM.ManagerVM.AddChampion(true);
        await Navigation.PopAsync();
    }
}
