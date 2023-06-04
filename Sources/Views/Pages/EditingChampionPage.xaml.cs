using ViewModel;

namespace Views.Pages;

public partial class EditingChampionPage : ContentPage
{
    public ChampionManagerVM ChampionManagerVM { get; set; }

    public EditingChampionPage(ChampionManagerVM championManagerVM)
	{
		InitializeComponent();
        ChampionManagerVM = championManagerVM;
        BindingContext = ChampionManagerVM.CurrentChampionVM;
    }
}
