using ViewModel;

namespace Views.Pages;

public partial class NewChampionPage : ContentPage
{

    public ChampionManagerVM ChampionManagerVM;

    
    public NewChampionPage(ChampionManagerVM championManagerVM)
	{
        ChampionManagerVM = championManagerVM;
        BindingContext = ChampionManagerVM.CurrentChampionVM;
        InitializeComponent();
    }

    async void AddChampion(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ChampionManagerVM.AddChampion();
        await Navigation.PopAsync();
    }

    async void CancelAddChampion(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ChampionManagerVM.AddChampion(true);
        await Navigation.PopAsync();
    }
}
