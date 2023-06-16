using System.Windows.Input;
using ViewModel;

namespace Views.Pages;

public partial class CharactersLibraryPage : ContentPage
{
    public AppVM AppVM { get; private set; }

    public CharactersLibraryPage(AppVM appVM)
    {
        InitializeComponent();
        AppVM = appVM;
        AppVM.Navigation = this.Navigation;
        BindingContext = AppVM;
    }

    /*async void ImageCell_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ChampionManagerVM.CurrentChampionVM = (ChampionVM)e.Parameter;
        await Navigation.PushAsync(new CharacterPage(ChampionManagerVM));
    }

    async void OnClickAddNewChampion(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ChampionManagerVM.IsNewChampion = true;
        await Navigation.PushAsync(new NewChampionPage(ChampionManagerVM));
    }*/

    /*private async Task DeleteChampionAsync(ChampionVM champion)
    {
        bool answer = await DisplayAlert("Attention", "Ëtes-vous sûr(e) de vouloir supprimer le champion ?", "Oui", "Non");
        AppVM.DeleteChampion(champion, answer);
    }*/
}
