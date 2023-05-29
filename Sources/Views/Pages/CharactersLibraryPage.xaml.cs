using System.Windows.Input;
using ViewModel;

namespace Views.Pages;

public partial class CharactersLibraryPage : ContentPage
{
    public ChampionManagerVM ChampionManagerVM { get; private set; }

    public ICommand ShowCharacterDetail => new Command(ShowCharacterDetailEvent);

    public CharactersLibraryPage(ChampionManagerVM championManagerVM)
    {
        InitializeComponent();
        ChampionManagerVM = championManagerVM;
        ChampionManagerVM.PageNumber = 0;
        BindingContext = this;
        ChampionManagerVM.NotifyChangementOfSelectedChampion = ShowCharacterDetailEvent;
    }

    private async void ShowCharacterDetailEvent()
    {
        await Navigation.PushAsync(new CharacterPage(ChampionManagerVM));
    }
}
