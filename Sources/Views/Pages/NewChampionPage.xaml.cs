using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using ViewModel;
using Views.ContentViews;

namespace Views.Pages;

public partial class NewChampionPage : ContentPage
{

    public AppVM AppVM { get; private set; }
    public ICommand ShowPopSkillCommand { get; private set; }

    public NewChampionPage(AppVM appVM)
	{
        this.AppVM = appVM;
        BindingContext = AppVM;
        ShowPopSkillCommand = new Command(
            execute: async () => await ShowPopSkill());
        InitializeComponent();
    }


    async Task ShowPopSkill()
    {
        var popup = new AddSkill();

        var result = await this.ShowPopupAsync(popup);

        if (result is SkillVM && result != null)
        {
            AppVM.ManagerVM.CurrentChampionVM.AddSkillCommand.Execute(result);
        }
    }
}
