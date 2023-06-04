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

}
