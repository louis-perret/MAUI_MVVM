using ViewModel;

namespace Views.Pages;

public partial class CharacterPage : ContentPage
{

	public ChampionVM ChampionVM { get; set; }

	public CharacterPage(ChampionVM championVM)
	{
		InitializeComponent();
		ChampionVM = championVM;
		BindingContext = ChampionVM;
	}
}
