using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using ViewModel;
using Views.ContentViews;

namespace Views.Pages;

/// <summary>
/// Page d'ajout d'un champion
/// </summary>
public partial class NewChampionPage : ContentPage
{
    /// <summary>
    /// VM Applicative
    /// </summary>
    public AppVM AppVM { get; private set; }

    /// <summary>
    /// Command pour afficher la pop up pour ajouter les skills. Doit être géré dans cette fenêtre et non par la VM applicative.
    /// </summary>
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
