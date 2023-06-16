using ViewModel;

namespace Views.Pages;

public partial class EditingChampionPage : ContentPage
{
    public AppVM AppVM { get; private set; }


    public EditingChampionPage(AppVM appVM)
	{
        this.AppVM = appVM;
        BindingContext = AppVM.ManagerVM.CurrentChampionVM.CopyForEdition;
        InitializeComponent();
    }
}
