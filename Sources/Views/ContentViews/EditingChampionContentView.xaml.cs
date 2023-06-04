using ViewModel;

namespace Views.ContentViews;

public partial class EditingChampionContentView : ContentView
{
    public static readonly BindableProperty ChampionManagerVMProperty = BindableProperty.Create(nameof(ChampionManagerVM), typeof(ChampionManagerVM), typeof(EditingChampionContentView), null);

    public ChampionManagerVM ChampionManagerVM
    {
        get => (ChampionManagerVM)GetValue(ChampionManagerVMProperty);
        set => SetValue(ChampionManagerVMProperty, value);
    }

	public EditingChampionContentView()
	{
		InitializeComponent();
        BindingContext = ChampionManagerVM.CurrentChampionVM;
	}
}
