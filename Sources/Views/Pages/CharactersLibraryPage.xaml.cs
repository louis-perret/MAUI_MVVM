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
}
