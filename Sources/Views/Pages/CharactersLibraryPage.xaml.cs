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
        await Navigation.PushAsync(new CharacterPage((ChampionVM)e.Parameter));
    }

}
