using ViewModel;

namespace Views.Pages;

public partial class CharacterPage : ContentPage
{

	public ChampionManagerVM ChampionManagerVM { get; set; }

	public CharacterPage(ChampionManagerVM championManagerVM)
	{
		InitializeComponent();
		ChampionManagerVM = championManagerVM;
		BindingContext = ChampionManagerVM.SelectedChampionVM;
	}
}
