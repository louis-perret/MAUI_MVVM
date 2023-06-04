using System.Windows.Input;
using ViewModel;

namespace Views.Pages;

public partial class CharactersLibraryPage : ContentPage
{
    public ChampionManagerVM ChampionManagerVM { get; private set; }

    public CharactersLibraryPage(ChampionManagerVM championManagerVM)
    {
        InitializeComponent();
        ChampionManagerVM = championManagerVM;
        ChampionManagerVM.PageNumber = 0;
        BindingContext = ChampionManagerVM;
    }

    async void ImageCell_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ChampionManagerVM.CurrentChampionVM = (ChampionVM)e.Parameter;
        await Navigation.PushAsync(new CharacterPage(ChampionManagerVM));
    }

    async void OnClickAddNewChampion(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ChampionManagerVM.IsNewChampion = true;
        await Navigation.PushAsync(new NewChampionPage(ChampionManagerVM));
    }
}
