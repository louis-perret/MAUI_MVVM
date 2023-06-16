using System.Windows.Input;
using ViewModel;

namespace Views.Pages;

public partial class CharactersLibraryPage : ContentPage
{
    public CharactersLibraryPage()
    {
        InitializeComponent();
        var appVM = (Application.Current as App).AppVM;
        appVM.Navigation = this.Navigation;
        BindingContext = appVM;
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
